using Dot.Library.Database.Model;
using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class MessageDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public UserDataContract Target { get; set; }

        [DataMember]
        public DateTime SentTime { get; set; }
    }
}