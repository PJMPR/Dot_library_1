using System;
using System.Runtime.Serialization;

namespace Dot.Library.Web.DataContracts
{
    public class UserMessageDataContract
    {
        public int Id { get; set; }
        public List<MessageDataContract> messages { get; set; }
    }
}