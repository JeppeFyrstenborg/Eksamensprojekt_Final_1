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
                Username = "Bob",
                Email = "bob@email.com"
            };

            User User2 = new User
            {
                Username = "Alice",
                Email = "alice@email.com"
            };

            context.Users.Add(User1);
            context.Users.Add(User2);

            context.SaveChanges();
        }

        public void SeedUsers(DatabaseContext context)
        {
            Seed(context);
        }
    }
}
