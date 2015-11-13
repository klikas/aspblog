using System.Collections.Generic;
using JustBlog.Core.Objects;

namespace JustBlog.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
    }
}
