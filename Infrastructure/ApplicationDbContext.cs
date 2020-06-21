using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public override int SaveChanges()
        {
            // Borrado Suave 
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties()
                .Any(x => x.Name == "EstaBorrado"))
                .ToList();

            foreach (var entity in entities)
            {
                entity.State = EntityState.Unchanged;
                entity.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChanges();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<TeachersIdentity> Teachers { get; set; }
        public DbSet<StudentsIdentity> Students { get; set; }
    }
}
