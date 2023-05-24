using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO.Models;

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
