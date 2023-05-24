using DAL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initializers
{
    public class UserInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User User1 = new User
            {
                Username = "Alice",
                Email = "alice@email.com"
            };
            User User2 = new User
            {
                Username = "Bob",
                Email = "bob@email.com"
            };
            User User3 = new User
            {
                Username = "Charlie",
                Email = "charlie@email.com"
            };
            User User4 = new User
            {
                Username = "David",
                Email = "david@email.com"
            };
            User User5 = new User
            {
                Username = "Emily",
                Email = "emily@email.com"
            };
            User User6 = new User
            {
                Username = "Frank",
                Email = "frank@email.com"
            };
            User User7 = new User
            {
                Username = "Grace",
                Email = "grace@email.com"
            };
            User User8 = new User
            {
                Username = "Henry",
                Email = "henry@email.com"
            };

            context.Users.Add(User1);
            context.Users.Add(User2);
            context.Users.Add(User3);
            context.Users.Add(User4);
            context.Users.Add(User5);
            context.Users.Add(User6);
            context.Users.Add(User7);
            context.Users.Add(User8);

            context.SaveChanges();
        }

        public void SeedUsers(DatabaseContext context)
        {
            Seed(context);
        }
    }
}
