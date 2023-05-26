using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public List<Chat> GetChatsForUserID(int userId)
        {
            using (DatabaseContext db = new DatabaseContext()) 
            {
                return db.Chats.Where(x => x.Users.Any(u => u.UserId == userId)).ToList();
            }
        }

        public void CreateMessageInChat(string messageText, int userId, int chatid)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Message TempMessage = new Message
                {
                    MessageText = messageText
                };

                User TempUser = (User)(from u in db.Users
                                where u.UserId == userId
                                select u);
                TempMessage.User = TempUser;

                Chat TempChat = (Chat)(from c in db.Chats
                                       where c.ChatId == chatid
                                       select c);
                TempChat.Messages.Add(TempMessage);

                db.SaveChanges();
            }
        }

        public Chat GetChatAndMessages(int chatId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return (Chat)(from c in db.Chats
                              where c.ChatId == chatId
                              select c).Include(m => m.Messages).Include(m1 => m1.Users);
            }
        }

        public Chat UpdateChatWithChat(Chat chat)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Chats.AddOrUpdate(chat);
                db.SaveChanges();
                return chat;
            }
        }
        public void AddMessageToChat(Message message, int chatId, int userId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Chat chat = db.Chats.FirstOrDefault(c => c.ChatId == chatId);
                User user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (chat != null && user != null)
                {
                    message.User = user;
                    chat.Messages.Add(message);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteMessageInChat(int messageId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Message messageInDb = db.Messages.FirstOrDefault(m => m.MessageId == messageId);
                db.Messages.Remove(messageInDb);
                db.SaveChanges();
            }
        }

        public void DeleteChat(int chatId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Chat chatInDb = db.Chats.FirstOrDefault(c => c.ChatId == chatId);
                db.Chats.Remove(chatInDb);
                db.SaveChanges();
            }
        }

        public void CreateNewChat(string chatName, int userId1, int userId2)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user1 = db.Users.FirstOrDefault(u => u.UserId == userId1);
                User user2 = db.Users.FirstOrDefault(u => u.UserId == userId2);

                Chat newChat = new Chat
                {
                    ChatName = chatName
                };
                newChat.Users.Add(user1);
                newChat.Users.Add(user2);
                db.Chats.Add(newChat);
                db.SaveChanges();
            }
        }

        public List<Chat> GetAllChats()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Chats.Include(c => c.Users).ToList();
            }
        }
    }
}
