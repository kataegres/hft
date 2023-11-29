using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    class ActiveProjectMemberDbContext : DbContext
    {
        public DbSet<ActiveProjectMember> Members { get; set; }

        public ActiveProjectMemberDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename=|DataDirectory|\ActiveProjectMember.mdf;" +
                    @"Integrated Security=True";

                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connStr);
            }
        }
    }
}
