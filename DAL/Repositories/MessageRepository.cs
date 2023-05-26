using DTO.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public List<Message> GetAllMessages()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Messages.Include(m => m.User).ToList();
            }
        }

        public void DeleteMessageById(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Message TempMessage = db.Messages.FirstOrDefault(x => x.MessageId == id);
                db.Messages.Remove(TempMessage);
                db.SaveChanges();
            }
        }

        public Message GetMessageById(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Messages.FirstOrDefault(x => x.MessageId == id);
            }
        }

        public List<Message> GetMessagesFromChatWithUser(int chatId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<Message> Messages = db.Chats
                            .Where(c => c.ChatId == chatId)
                            .SelectMany(c => c.Messages)
                            .Include(m => m.User) // Include User property of each Message
                            .ToList();
                return Messages;
            }
        }

        public void UpdateMessageInChat(int chatId, int messageId, string messageText)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Chats.Where(c => c.ChatId == chatId)
                    .FirstOrDefault()
                    .Messages
                    .FirstOrDefault(m => m.MessageId == messageId)
                    .MessageText = messageText;
            }
        }

        public List<Message> GetMessagesForUserId(int userId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Messages
                            .Where(m => m.User.UserId == userId)
                            .ToList();
            }
        }
    }
}
