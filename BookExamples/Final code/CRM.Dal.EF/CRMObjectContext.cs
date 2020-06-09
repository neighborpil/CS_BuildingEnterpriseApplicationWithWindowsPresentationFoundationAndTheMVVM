using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CRM.Domain.Domain;

namespace CRM.Dal.EF
{
    public class CrmObjectContext : DbContext
    {

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>The employees.</value>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(x => x.PrimaryKey);
            modelBuilder.Entity<Contact>()
                .HasKey(x => x.PrimaryKey);
            base.OnModelCreating(modelBuilder);
        }
    }
}