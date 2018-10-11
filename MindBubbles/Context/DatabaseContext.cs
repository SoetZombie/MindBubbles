using MindBubbles.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MindBubbles.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("myConnectionString")
        { }
        public DbSet<ExistingBubbles> ExistingBubbles { get; set; }
      
    }
}