using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CardViewModel
    {
        [DataMember]
        public int RowId { get; set; }
        [DataMember]

        public int TestId { get; set; }

        [DataMember]
        public string Question { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public string Answer { get; set; }
    }
}
