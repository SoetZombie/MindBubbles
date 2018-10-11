using Microsoft.AspNet.Identity.EntityFramework;
using MindBubbles3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MindBubbles3.Context
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext() : base("myConnectionString")
        { }
        public DbSet<ExistingBubbles> ExistingBubbles { get; set; }
    }
}