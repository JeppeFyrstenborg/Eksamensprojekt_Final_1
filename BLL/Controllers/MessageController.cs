using DAL;
using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;

namespace BLL.Controllers
{
    public class MessageController
    {

        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public List<Message> GetAllMessages()
        {
            return _messageRepository.GetAllMessages();
        }

        public List<Message> GetMessagesForUserId(int userId)
        {
            return _messageRepository.GetMessagesForUserId(userId);
        }
    }
}
