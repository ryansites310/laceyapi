using System;
using System.Collections.Generic;

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Card
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

        [DataMember]
        public virtual Test Test { get; set; }
    }
}
