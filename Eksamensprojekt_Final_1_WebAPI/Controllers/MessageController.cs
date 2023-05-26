using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eksamensprojekt_Final_1_WebAPI.Controllers
{
    public class MessageController : ApiController
    {

        private IMessageRepository _messageRepository = new MessageRepository();


        [HttpGet]
        public List<Message> GetAll()
        {
            return _messageRepository.GetAllMessages();
        }

        [HttpGet]
        public Message Get(int id)
        {
            return _messageRepository.GetMessageById(id);
        }



    }
}
