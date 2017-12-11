using System;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int Id{get;set;}

        [DataMember]
        public string Title{get;set;}
        
        [DataMember]
        public string Content{get;set;}
        
        [DataMember]
        public User Target{get;set;}

        [DataMember]
        public DateTime SentTime{get;set;}

    }
}
