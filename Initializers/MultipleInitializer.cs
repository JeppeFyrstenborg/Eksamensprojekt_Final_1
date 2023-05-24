using DAL;
using System.Collections.Generic;
using System.Data.Entity;

namespace Initializers
{
    internal class MultipleInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        
        protected override void Seed(DatabaseContext context)
        {
            UserInitializer x2 = new UserInitializer();
            x2.SeedUsers(context);

            UserAuthInitializer x3 = new UserAuthInitializer();
            x3.SeedUserAuths(context);

            MessageInitializer x1 = new MessageInitializer();
            x1.SeedMessages(context);

            ChatInitializer x4 = new ChatInitializer();
            x4.SeedChats(context);

            context.SaveChanges();
        }
    }
}
