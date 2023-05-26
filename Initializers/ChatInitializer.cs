using DAL;
using DTO.Models;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Initializers
{
    public class ChatInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {


        protected override void Seed(DatabaseContext context)
        {
            Chat Chat1 = new Chat
            {
                ChatName = "Coozy Chat"
            };

            Chat1.Users.Add(context.Users.FirstOrDefault());
            Chat1.Users.Add(context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault());

            Chat1.Messages.Add(context.Messages.FirstOrDefault());
            Chat1.Messages.Add(context.Messages.OrderBy(x => x.MessageId).Skip(1).FirstOrDefault());
            Chat1.Messages.Add(context.Messages.OrderBy(x => x.MessageId).Skip(2).FirstOrDefault());
            Chat1.Messages.Add(context.Messages.OrderBy(x => x.MessageId).Skip(3).FirstOrDefault());

            context.Chats.Add(Chat1);

            context.SaveChanges();
        }

        public void SeedChats(DatabaseContext context)
        {
            Seed(context);
        }
    }
}
