using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Dot.Library.Database.Model
{
    [DataContract]
    public class Chapter
    {
        [DataMember]
        public virtual Chapter Parent { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Chapter> SubChapters { get; set; }
    }
}
