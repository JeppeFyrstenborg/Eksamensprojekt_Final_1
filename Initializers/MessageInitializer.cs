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

            Message message1 = new Message
            {
                MessageText = "Hello",
                User = context.Users.FirstOrDefault()
            };

            Message message3 = new Message
            {
                MessageText = "Nice ny chat :D",
                User = context.Users.FirstOrDefault()
            };

            Message message2 = new Message
            {
                MessageText = "Hello!",
                User = context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault()
            };

            Message message4 = new Message
            {
                MessageText = "E9",
                User = context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault()
            };

            context.Messages.Add(message1);
            context.Messages.Add(message2);
            context.Messages.Add(message3);
            context.Messages.Add(message4);

            context.SaveChanges();
        }

        public void SeedMessages(DatabaseContext context)
        {
            Seed(context);
        }
    }
}
