using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserAuthRepository
    {
        string GetHashedPasswordFromUserId(int userId);

        void SetHashedPasswordForUserId(int userId);

        string GetSaltFromUserId(int userId);

        void SetSaltForUserId(int userId);

    }
}
