using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication.Controllers;
using MvcApplication.Models;
using Rhino.Mocks;

namespace MvcApplicationTest
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public void BlogControllerSelectsCorrectView()
        {
            MockRepository mocks = new MockRepository();
            IPostRepository repository = mocks.DynamicMock<IPostRepository>();
            SetupResult
                .For(repository.ListRecentPosts(10))
                .IgnoreArguments()
                .Return(new List<Post>(new Post[] {new Post(), new Post()}));
            mocks.ReplayAll();

            BlogControllerDouble controller = new BlogControllerDouble(repository);
            controller.Recent();
            Assert.AreEqual("Recent", controller.SelectedView);
        }

        [TestMethod]
        public void BlogControllerPassesCorrectViewData()
        {
            MockRepository mocks = new MockRepository();
            IPostRepository repository = mocks.DynamicMock<IPostRepository>();
            SetupResult
                .For(repository.ListRecentPosts(10))
                .IgnoreArguments()
                .Return(new List<Post>(new Post[] {new Post(), new Post()}));
            mocks.ReplayAll();
            
            BlogControllerDouble controller = new BlogControllerDouble(repository);
            controller.Recent();
            IList<Post> posts = (IList<Post>)controller.RenderedViewData;
            Assert.AreEqual(2, posts.Count, "Expected two posts");
        }

        private class BlogControllerDouble : BlogController
        {
            public BlogControllerDouble(IPostRepository repository)
                : base(repository)
            { }

            public string SelectedView { get; private set; }
            public object RenderedViewData { get; private set; }
            
            protected override void RenderView(string viewName
                , string masterName
                , object viewData)
            {
                this.SelectedView = viewName;
                //I don't care about masterName at this point.
                this.RenderedViewData = viewData;
            }
        }
    }
}
