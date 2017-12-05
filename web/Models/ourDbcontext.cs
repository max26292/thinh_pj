using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace web.Models
{
    public class ourDbcontext :DbContext
    {
       
            public DbSet<User> user { get; set; }
            public DbSet<Item> item { get; set; }
            public DbSet<Category> category { get; set; }
       
    }
    public class itemdb : DbContext
    {

       
        public DbSet<Item> items { get; set; }
        public DbSet<Category> category { get; set; }

    }
    
}