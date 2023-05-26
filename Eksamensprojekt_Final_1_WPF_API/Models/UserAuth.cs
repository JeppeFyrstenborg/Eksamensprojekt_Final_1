using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_Final_1_WPF_API.Models
{
    public class UserAuth
    {
        public int UserAuthId { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public User User { get; set; }

        public UserAuth() { }

        public UserAuth(string hashedPassword, string salt, User user)
        {
            this.HashedPassword = hashedPassword;
            this.Salt = salt;
            this.User = user;
        }
    }
}
