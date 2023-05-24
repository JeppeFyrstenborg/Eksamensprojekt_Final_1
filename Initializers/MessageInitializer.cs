using DAL;
using DTO.Models;
using System.Data.Entity;
using System.Linq;

namespace Initializers
{
    public class MessageInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            //if (context.Users.FirstOrDefault() == null)
            //{
            //    var userInitializer = new UserInitializer();
            //    userInitializer.SeedUsers(context);
            //}

            Message message1 = new Message
            {
                MessageText = "Hejsa 1",
                User = context.Users.FirstOrDefault()
            };

            Message message2 = new Message
            {
                MessageText = "Hejsa 2",
                User = context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault()
            };

            context.Messages.Add(message1);
            context.Messages.Add(message2);

            context.SaveChanges();
        }

        public void SeedMessages(DatabaseContext context)
        {
            Seed(context);
        }
    }
}
