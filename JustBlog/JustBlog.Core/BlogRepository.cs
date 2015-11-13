using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core
{
    class BlogRepository : IBlogRepository
    {
        //NHibernate object
        private readonly ISession _session ;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        /*
         * All the calls to the database has to be made through the NHibernate's ISession object. 
         * When we read the collection of posts using ISession, the dependencies Category and Tags are not populated by default. 
         * Fetch and FetchMany methods are used to tell NHibernate to populate them eagerly.
         */
        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _session.Query<Post>()
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo*pageSize)
                .Fetch(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _session.Query<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PostedOn)
                .FetchMany(p => p.Tags)
                .ToList();
        }

        public int TotalPosts()
        {
            return _session.Query<Post>().Count(p => p.Published);
        }
    }
}
