using System;
using System.Collections.Generic;

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TestViewModel
    {

        [DataMember]
        public int RowId { get; set; }

        [DataMember]
        public string TestName { get; set; }

        [DataMember]
        public DateTime? CreateDate { get; set; }

        [DataMember]
        public ICollection<CardViewModel> Card { get; set; }
    }
}
