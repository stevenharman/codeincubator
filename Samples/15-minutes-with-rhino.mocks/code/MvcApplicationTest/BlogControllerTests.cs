using System.Collections.Generic;
using CodeInc.Commons.Testing;
using MbUnit.Framework;
using MvcApplication.Controllers;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest
{
    [TestFixture]
    public class When_BlogController_ready_for_action_call
    {
        private MockRepository mocks;
        private BlogControllerDouble controller;
        private IPostRepository repository;
        private List<Post> posts;

        [SetUp]
        public void Setup()
        {
            mocks = new MockRepository();
            repository = mocks.DynamicMock<IPostRepository>();

            controller = new BlogControllerDouble(repository);
            posts = new List<Post> {new Post(), new Post()};
        }

        [Test]
        public void Then_Recent_should_pass_the_posts_to_the_view()
        {
            using (mocks.Record())
            {
                Expect
                    .Call(repository.ListRecentPosts(10))
                    .Return(posts);
            }

            using (mocks.Playback())
            {
                controller.Recent();
            }

            IList<Post> renderedPosts = (IList<Post>)controller.RenderedViewData;

            renderedPosts.Count.ShouldEqual(2);
        }

        [Test]
        public void Then_Recent_should_render_the_correct_view()
        {
            using (mocks.Record())
            {
                SetupResult
                    .For(repository.ListRecentPosts(0))
                    .IgnoreArguments()
                    .Return(posts);
            }

            using (mocks.Playback())
            {
                controller.Recent();
            }

            controller.SelectedView.ShouldEqual("Recent");
        }

        // This private class is known as a Test-Specific subclass.
        public class BlogControllerDouble : BlogController
        {
            public BlogControllerDouble(IPostRepository repository)
                : base(repository)
            {
            }

            public string SelectedView { get; private set; }
            public object RenderedViewData { get; private set; }

            protected override void RenderView(string viewName, string masterName , object viewData)
            {
                this.SelectedView = viewName;
                //I don't care about masterName at this point.
                this.RenderedViewData = viewData;
            }
        }
    }
}