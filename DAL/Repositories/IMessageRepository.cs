using DTO.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessages();

        Message GetMessageById(int id);

        void DeleteMessageById(int id);

        List<Message> GetMessagesFromChatWithUser(int chatId);

        void UpdateMessageInChat(int chatId, int messageId, string messageText);

        List<Message> GetMessagesForUserId(int userId);

    }
}
