using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class BookReservationDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public UserDataContract user { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public List<BookDataContract> reservatedBooks { get; set; }
    }
}
