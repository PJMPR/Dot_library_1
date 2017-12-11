using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    public class MessageDataContract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User Target { get; set; }
        public DateTime SentTime { get; set; }
    }
}