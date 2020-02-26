using System;
using System.Collections.Generic;
using System.Text;
using ExamenAconcagua.Models;
using ExamenAconcaguaIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenAconcaguaIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });


            modelBuilder.Entity<Prestamo>()
                .HasMany(x => x.Pagos);

            modelBuilder.Entity<Solicitante>()
                .HasAlternateKey(x => x.Dni);

            base.OnModelCreating(modelBuilder);
        }
    }
}
