using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComicBookStore.Data
{
    public class ComicBookStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ComicBookStoreContext() : base("name=ComicBookStoreContext")
        {
        }

        public System.Data.Entity.DbSet<ComicBookStore.Models.Authored> Authoreds { get; set; }

        public System.Data.Entity.DbSet<ComicBookStore.Models.ComicBook> ComicBooks { get; set; }

        public System.Data.Entity.DbSet<ComicBookStore.Models.Writer> Writers { get; set; }

        public System.Data.Entity.DbSet<ComicBookStore.Models.Publisher> Publishers { get; set; }
    }
}
