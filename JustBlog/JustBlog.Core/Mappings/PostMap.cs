using FluentNHibernate.Mapping;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Mappings
{
    /* 
    * To create a mapping class we should inherit it from the Fluent NHibernate's generic class ClassMap. 
    * All the mappings has to be done in the constructor.
    * As default, Fluent NHibernate assumes the table name as same as the class name and column name as same as the property name. 
    * If the table name is different then we should map the table with the class using the Table extension method.
    * [e.g Table("tbl_posts");]
    */
    class PostMap: ClassMap<Post>
    {
        public PostMap()
        {
            /* The Id extension method is used to represent the property name that has to be set as the primary key column of the table. */
            Id(x => x.Id);
            /* 
             * The Map extension method is used to map a property with a table column. 
             * While mapping a property we can specify the size of the column, whether it's nullable or not and other details. 
             * If the generated column name has to be different from the property name then we should pass the column name using the Column extension method.
             * 
             * [e.g Map(x => x.Title).Column("post_title")]
             * 
             */
            Map(x => x.Title)
                .Length(500)
                .Not.Nullable();

            Map(x => x.ShortDescription)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(5000)
                .Not.Nullable();

            Map(x => x.Meta)
                .Length(1000)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Published)
                .Not.Nullable();

            Map(x => x.PostedOn)
               .Not.Nullable();

            Map(x => x.Modified);

            /*
             * The References method is used to represent the many-to-one relationship between Post and Category 
             * through a foreign key column Category in the Post table. 
             * HasManyToMany method is used to represent many-to-many relationship between Post and Tag 
             * and this is achieved through an intermediate table called PostTagMap.
             */
            References(x => x.Category)
               .Column("Category")
               .Not.Nullable();

            HasManyToMany(x => x.Tags)
              .Table("PostTagMap");
        }
    }
}
