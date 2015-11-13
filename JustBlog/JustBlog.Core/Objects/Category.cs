using System.Collections.Generic;

namespace JustBlog.Core.Objects
{
    /* All properties need to be virtual since NHibernate creates a runtime proxy for the class (possibly overriding some?) */
    class Category
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string UrlSlug { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Post> Posts { get; set; } 
    }
}
