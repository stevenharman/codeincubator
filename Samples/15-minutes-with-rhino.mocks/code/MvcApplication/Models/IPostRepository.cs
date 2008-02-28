using System;
using System.Collections.Generic;

namespace MvcApplication.Models
{
    public interface IPostRepository
    {
        void Create(Post post);

        IList<Post> ListRecentPosts(int retrievalCount);
    }
}
