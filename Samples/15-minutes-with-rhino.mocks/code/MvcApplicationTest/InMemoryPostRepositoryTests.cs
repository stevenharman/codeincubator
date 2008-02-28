using System;
using System.Collections.Generic;
using MbUnit.Framework;
using MvcApplication.Models;

namespace MvcApplicationTest
{
    [TestFixture]
    public class InMemoryPostRepositoryTests
    {
        [Test]
        public void CanGetEmptyCollectionWhenNoPosts()
        {
            InMemoryPostRepository.Clear();

            InMemoryPostRepository repository = new InMemoryPostRepository();

            IList<Post> posts = repository.ListRecentPosts(3);
            Assert.AreEqual(0, posts.Count, "0 total, requested 3, should get 0");
        }

        [Test]
        public void RequestingNegativeThrowsArgumentOutOfRangeException()
        {
            InMemoryPostRepository.Clear();

            InMemoryPostRepository repository = new InMemoryPostRepository();
            try
            {
                IList<Post> posts = repository.ListRecentPosts(-1);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail("Expected an argument out of range exception.");
        }

        [Test]
        public void CanGetRecentPostsWhenCountLessThanTotal()
        {
            InMemoryPostRepository.Clear();

            InMemoryPostRepository repository = new InMemoryPostRepository();
            for (int i = 0; i < 5; i++)
                repository.Create(new Post());

            IList<Post> posts = repository.ListRecentPosts(3);
            Assert.AreEqual(3, posts.Count, "5 total, requested 3, should get 3");
        }

        [Test]
        public void CanGetRecentPostsWhenCountGreaterThanTotal()
        {
            InMemoryPostRepository.Clear();

            InMemoryPostRepository repository = new InMemoryPostRepository();
            for (int i = 0; i < 3; i++)
                repository.Create(new Post());

            IList<Post> posts = repository.ListRecentPosts(5);
            Assert.AreEqual(3, posts.Count, "Requested 5, but there's only 3. Should retrieve 3");
        }

        [Test]
        public void CanGetRecentExactNumberOfPosts()
        {
            InMemoryPostRepository.Clear();

            InMemoryPostRepository repository = new InMemoryPostRepository();
            for (int i = 0; i < 3; i++)
                repository.Create(new Post());

            IList<Post> posts = repository.ListRecentPosts(3);
            Assert.AreEqual(3, posts.Count, "Requested 3, and there's only 3. Should retrieve 3");
        }
    }
}