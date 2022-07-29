
using Microsoft.EntityFrameworkCore;
using TestContactsApi.Models;

namespace TestContactsApi.Data
{
    public class ContactsContext:DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                    new Contact { ContactId = 1, Name = "Karina", Phone = "5579032321" },
                    new Contact { ContactId = 2, Name = "Antonio", Phone = "7123129809" },
                    new Contact { ContactId = 3, Name = "Maria", Phone = "987654322" },
                    new Contact { ContactId = 4, Name = "Felipe", Phone = "987654323" }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, AddressName = "Santa Fe 1", ContactId = 1 },
                new Address { Id = 2, AddressName = "Santa Fe 2", ContactId = 1 },
                new Address { Id = 3, AddressName = "Santa Fe 3", ContactId = 2 },
                new Address { Id = 4, AddressName = "Santa Fe 4", ContactId = 3 },
                new Address { Id = 5, AddressName = "Santa Fe 5", ContactId = 4 },
                new Address { Id = 6, AddressName = "Santa Fe 6", ContactId = 1 },
                new Address { Id = 7, AddressName = "Santa Fe 7", ContactId = 2 }
                );

            modelBuilder.Entity<Contact>()
                .HasMany<Address>(g => g.Addresses)
                .WithOne(s => s.Contact)
                .HasForeignKey(s => s.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
