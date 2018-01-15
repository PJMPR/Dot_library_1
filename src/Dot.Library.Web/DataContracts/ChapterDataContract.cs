using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{
    [DataContract]
    public class ChapterDataContract
    {
        [DataMember]
        public virtual ChapterDataContract Parent { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<ChapterDataContract> SubChapters { get; set; }
    }
}
