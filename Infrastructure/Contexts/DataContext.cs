using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public override int SaveChanges()
        {
            // Borrado Suave 
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && e.Metadata.GetProperties()
                .Any(x => x.Name == "deleted"))
                .ToList();

            foreach (var entity in entities)
            {
                entity.State = EntityState.Unchanged;
                entity.CurrentValues["deleted"] = true;
            }

            return base.SaveChanges();
        }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<TeachersIdentity> Teachers { get; set; }
        public DbSet<StudentsIdentity> Students { get; set; }
       
    }

}