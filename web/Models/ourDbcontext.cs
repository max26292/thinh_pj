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
            
       
    }
}