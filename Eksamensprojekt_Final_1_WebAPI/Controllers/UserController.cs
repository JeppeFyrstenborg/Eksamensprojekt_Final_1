using BLL.Services;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Security;
using System.Web.Helpers;
using System.Web.Http;

namespace Eksamensprojekt_Final_1_WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository _userRepository = new UserRepository();
        private IUserAuthRepository _userAuthRepository = new UserAuthRepository();


        [HttpGet]
        public List<User> GetAll()
        {
            return _userRepository.GetAllUsers();
        }     

        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUserWithId(id);
        }

        [HttpPost]
        public HttpResponseMessage AddUser(UserAuth userAuth)
        {
            try
            {
                if(_userRepository.GetUserFromEmail(userAuth.User.Email) == null)
                {
                    int createdUserId = _userRepository.CreateNewUser(userAuth.User.Username, 
                        userAuth.User.Email,userAuth.User.Birthday);

                    _userAuthRepository.CreateNewUserAuthForUserId
                        (createdUserId, userAuth.HashedPassword, userAuth.Salt);

                    return Request.CreateResponse(HttpStatusCode.OK, "Bruger oprettet");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Email findes allerede");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}