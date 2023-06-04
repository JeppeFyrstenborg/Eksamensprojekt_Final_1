using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;

namespace BLL.Controllers
{
    public class ChatController
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;

        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
            _messageRepository = new MessageRepository();
        }

        public List<Chat> GetChatsForUser(int userId)
        {
            return _chatRepository.GetChatsForUserID(userId);
        }

        public List<Message> GetMessagesInChatWithUser(int chatId)
        {
            return _messageRepository.GetMessagesFromChatWithUser(chatId);
        }

        public Chat UpdateChatWithChat(Chat chat)
        {
            return _chatRepository.UpdateChatWithChat(chat);
        }

        public void AddMessageToChat(string textMessage, int userId, int chatId)
        {
            Message newMessage = new Message
            {
                MessageText = textMessage,
            };
            _chatRepository.AddMessageToChat(newMessage, chatId, userId);
        }

        public void DeleteMessageFromDbWithMessageId(int messageId)
        {
            _chatRepository.DeleteMessageInChat(messageId);
        }

        public void DeleteChatWithChatId(int chatId)
        {
            _chatRepository.DeleteChat(chatId);
        }

        public void CreateNewChatWithNameAndUserIds(string newChatname, int userId1, int userId2)
        {
            _chatRepository.CreateNewChat(newChatname, userId1, userId2);
        }
    }
}
