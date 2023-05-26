using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eksamensprojekt_Final_1_WebAPI.Controllers
{
    public class ChatController : ApiController
    {
        private IChatRepository _chatRepository = new ChatRepository();


        [HttpGet]
        public List<Chat> GetAll()
        {
            List<Chat> chats = _chatRepository.GetAllChats();

            // Fjerner chats fra hver user.
            // Ellers opstår der en uendelig loop i konverteringen til JSON.
            foreach (Chat chat in chats)
            {
                foreach (User user in chat.Users)
                {
                    user.Chats = null;
                }
            }

            return chats;
        }

        [HttpPut]
        public HttpResponseMessage UpdateChat(Chat chat)
        {
            try
            {

                this._chatRepository.UpdateChatWithChat(chat);

                return Request.CreateResponse(HttpStatusCode.OK, "Chat opdateret");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteChat(int id)
        {
            try
            {

                this._chatRepository.DeleteChat(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Chat Slettet");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}