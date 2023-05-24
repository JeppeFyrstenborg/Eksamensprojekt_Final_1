﻿using System;

namespace DTO.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }

        private DateTime _createdTime;
        public DateTime CreatedTime
        {
            get { return this._createdTime; }
            set { this._createdTime = value; }
        }

        public User User { get; set; }

        public Message()
        {
            this._createdTime = DateTime.Now;
        }

        public Message(string messageText, User user)
        {
            this.MessageText = messageText;
            this._createdTime = DateTime.Now;
            this.User = user;
        }

        public override string ToString()
        {
            return this.MessageText;
        }
    }
}
