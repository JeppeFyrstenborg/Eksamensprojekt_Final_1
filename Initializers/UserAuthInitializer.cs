using BLL.Services;
using DAL;
using DTO.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Initializers
{
    public class UserAuthInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {

            Security _security = new Security();

            string plainPassword = "123456";
            SecureString secureString = new NetworkCredential("", plainPassword).SecurePassword;

            // UserAuth for User1
            UserAuth UserAuth1 = new UserAuth
            {
                User = context.Users.FirstOrDefault()
            };
            Tuple<string, string> UserAuth1PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth1.HashedPassword = UserAuth1PassAndSalt.Item1;
            UserAuth1.Salt = UserAuth1PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth1);

            // UserAuth for User2
            UserAuth UserAuth2 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault()
            };
            Tuple<string, string> UserAuth2PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth2.HashedPassword = UserAuth2PassAndSalt.Item1;
            UserAuth2.Salt = UserAuth2PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth2);

            // UserAuth for User3
            UserAuth UserAuth3 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(2).FirstOrDefault()
            };
            Tuple<string, string> UserAuth3PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth3.HashedPassword = UserAuth3PassAndSalt.Item1;
            UserAuth3.Salt = UserAuth3PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth3);

            // UserAuth for User4
            UserAuth UserAuth4 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(3).FirstOrDefault()
            };
            Tuple<string, string> UserAuth4PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth4.HashedPassword = UserAuth4PassAndSalt.Item1;
            UserAuth4.Salt = UserAuth4PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth4);

            // UserAuth for User5
            UserAuth UserAuth5 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(4).FirstOrDefault()
            };
            Tuple<string, string> UserAuth5PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth5.HashedPassword = UserAuth5PassAndSalt.Item1;
            UserAuth5.Salt = UserAuth5PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth5);

            // UserAuth for User6
            UserAuth UserAuth6 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(5).FirstOrDefault()
            };
            Tuple<string, string> UserAuth6PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth6.HashedPassword = UserAuth6PassAndSalt.Item1;
            UserAuth6.Salt = UserAuth6PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth6);

            // UserAuth for User7
            UserAuth UserAuth7 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(6).FirstOrDefault()
            };
            Tuple<string, string> UserAuth7PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth7.HashedPassword = UserAuth7PassAndSalt.Item1;
            UserAuth7.Salt = UserAuth7PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth7);

            // UserAuth for User8
            UserAuth UserAuth8 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(7).FirstOrDefault()
            };
            Tuple<string, string> UserAuth8PassAndSalt = _security.GetHashedPasswordAndSaltFrom(secureString);
            UserAuth8.HashedPassword = UserAuth8PassAndSalt.Item1;
            UserAuth8.Salt = UserAuth8PassAndSalt.Item2;
            context.UsersAuth.Add(UserAuth8);

            context.SaveChanges();
        }
        public void SeedUserAuths(DatabaseContext context)
        {
            Seed(context);
        }

    }
}
