using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{[DataContract]
    public class CategoryDataContract
    {   [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public List<CategoryDataContract> SubCategories { get; set; }
        [DataMember]
        public CategoryDataContract Parent { get; set; }
    }
}
