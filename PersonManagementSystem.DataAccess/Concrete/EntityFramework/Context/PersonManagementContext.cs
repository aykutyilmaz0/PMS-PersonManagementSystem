namespace PersonManagementSystem.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonManagementContext : DbContext
    {
        public PersonManagementContext()
            : base("name=PersonManagementContext")
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Persons)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Persons)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
