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
                Email = "alice@email.com",
                Birthday = DateTime.Now.AddYears(-20).AddDays(-15)
            };

            User User2 = new User
            {
                Username = "Bob",
                Email = "bob@email.com",
                Birthday = DateTime.Now.AddYears(-25).AddDays(-40)
            };

            User User3 = new User
            {
                Username = "Charlie",
                Email = "charlie@email.com",
                Birthday = DateTime.Now.AddYears(-22).AddDays(-60)
            };

            User User4 = new User
            {
                Username = "David",
                Email = "david@email.com",
                Birthday = DateTime.Now.AddYears(-30).AddDays(-10)
            };

            User User5 = new User
            {
                Username = "Emily",
                Email = "emily@email.com",
                Birthday = DateTime.Now.AddYears(-18).AddDays(-20)
            };

            User User6 = new User
            {
                Username = "Frank",
                Email = "frank@email.com",
                Birthday = DateTime.Now.AddYears(-27).AddDays(-30)
            };

            User User7 = new User
            {
                Username = "Grace",
                Email = "grace@email.com",
                Birthday = DateTime.Now.AddYears(-23).AddDays(-5)
            };

            User User8 = new User
            {
                Username = "Henry",
                Email = "henry@email.com",
                Birthday = DateTime.Now.AddYears(-28).AddDays(-25)
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
