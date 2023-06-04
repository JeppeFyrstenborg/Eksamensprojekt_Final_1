using DTO.Models;
using System.Data.Entity;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Database") { }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAuth> UsersAuth { get; set; }

        public DbSet<Chat> Chats { get; set; }

    }
}
