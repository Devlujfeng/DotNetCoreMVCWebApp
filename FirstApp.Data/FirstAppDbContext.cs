using FirstApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Data
{
    /// <summary>
    ///     Create this class to talk to EF
    /// </summary>
    public class FirstAppDbContext : DbContext
    {
        public FirstAppDbContext(DbContextOptions<FirstAppDbContext> options) :base(options)
        {

        }
        public DbSet<RestaurantDS> Restaurants { get; set; }
        public DbSet<EntityTest> EntityTest { get; set; }
        public DbSet<RelationshipTest> RelationshipTest { get; set; }

    }
}
