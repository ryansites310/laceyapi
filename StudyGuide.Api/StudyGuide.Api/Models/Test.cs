using System;
using System.Collections.Generic;

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Test
    {
        public Test()
        {
            Card = new HashSet<Card>();
        }

        [DataMember]
        public int RowId { get; set; }

        [DataMember]
        public string TestName { get; set; }

        [DataMember]
        public DateTime? CreateDate { get; set; }

        [DataMember]
        public virtual ICollection<Card> Card { get; set; }
    }
}
