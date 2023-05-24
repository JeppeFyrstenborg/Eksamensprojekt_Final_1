using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IChatRepository
    {
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
