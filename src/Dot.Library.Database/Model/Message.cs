using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    public class Message
    {
        int id;
        string title;
        string content;
        string fromUser;
        string toUser;

        public Message(int id, string title, string content, string fromUser, string toUser)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.fromUser = fromUser;
            this.toUser = toUser;
        }

    }
}
