using System.Collections.Generic;

namespace MvcApplication.Models
{
    public interface IPostRepository
    {
        void Create(Post post);

        Post GetById(int id);

        IList<Post> ListRecentPosts(int retrievalCount);
    }
}