using System;
using System.Web.Mvc;
using MvcApplication.Models;
using System.Collections.Generic;

namespace MvcApplication.Controllers
{
    public class BlogController : Controller
    {
        IPostRepository repository;

        public BlogController(IPostRepository repository)
        {
            this.repository = repository;
        }

        [ControllerAction]
        public void Recent()
        {
            IList<Post> posts = 
                this.repository.ListRecentPosts(10); //Doh! Magic Number!
            RenderView("Recent", posts);
        }
    }
}
