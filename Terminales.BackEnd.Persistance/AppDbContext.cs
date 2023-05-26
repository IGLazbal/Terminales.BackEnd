using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Models;
using Terminales.Backend.Persistence.Configurations;

namespace Terminales.Backend.Persistence
{

    public class AppDbContext : DbContext
    {
        public DbSet<Terminal> Terminales { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TerminalConfiguration());
        }
    }
}