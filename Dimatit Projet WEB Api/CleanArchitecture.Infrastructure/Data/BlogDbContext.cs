using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOption) : base(dbContextOption)
        { }
        public DbSet<Code_Analytique> code_Analytique { get; set; }
        public DbSet<Frais_Deplacement> frais_Deplacement { get; set; }
        public DbSet<Personnel> personnel { get; set; }
        public DbSet<Facture> Facture { get; set; }
        public DbSet<Achat> Achat { get; set; }
        public DbSet<Chef_Comptabilite> Chef_Comptabilite { get; set; }
        public DbSet<Comptabilite> Comptabilite { get; set; }
        public DbSet<Assistate_DAF> Assistate_DAF { get; set; }
        public DbSet<Bureau_Ordre> Bureau_Ordre { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Frais_Deplacement>().ToTable(tb => tb.HasTrigger("TR_fRAIS_UPDATE"));
            base.OnModelCreating(modelBuilder);
        }

    }
}
