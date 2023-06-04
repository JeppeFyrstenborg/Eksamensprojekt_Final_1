using DTO.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IChatRepository
    {
        List<Chat> GetAllChats();

        List<Chat> GetChatsForUserID(int userId);

        void CreateMessageInChat(string messageText, int userId, int chatId);

        void CreateNewChat(string chatName, int user1, int user2);

        Chat GetChatAndMessages(int chatId);

        Chat UpdateChatWithChat(Chat chat);

        void AddMessageToChat(Message message, int chatId, int userId);

        void DeleteMessageInChat(int messageId);

        void DeleteChat(int chatId);
    }
}
