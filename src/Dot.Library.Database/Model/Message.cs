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
        public class Message
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Content { get; set; }

            public User Target { get; set; }

            public DateTime SentTime { get; set; }

        }
    }
}
