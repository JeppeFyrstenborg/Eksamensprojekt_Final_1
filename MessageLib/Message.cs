using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLib
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

        public Message() { }

        public Message(string messageText)
        {
            this.MessageText = messageText;
            this._createdTime = DateTime.Now;
        }

        public override string ToString()
        {
            return this.MessageText;
        }

    }
}
