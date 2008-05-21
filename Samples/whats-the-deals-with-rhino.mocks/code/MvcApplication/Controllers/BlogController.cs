using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostRepository repository;

        public BlogController(IPostRepository repository)
        {
            this.repository = repository;
        }

        [ControllerAction]
        public void Recent()
        {
            IList<Post> posts = this.repository.ListRecentPosts(10); //Doh! Magic Number!

            RenderView("Recent", posts);
        }

        [ControllerAction]
        public void Index(int? id)
        {
            Post thePost = null;

            if (id.HasValue)
                thePost = repository.GetById(id.Value);

            if (thePost == null)
                RenderView("Index");
            else
                RenderView("Entry", thePost);
        }
    }
}