using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Context
{
    public class GlobCartOrderServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public GlobCartOrderServiceContext(DbContextOptions<GlobCartOrderServiceContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRegisterMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
