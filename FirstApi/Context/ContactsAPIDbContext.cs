using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Context
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts {get; set;}
    }
}
