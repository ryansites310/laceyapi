namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "pagination")]
    public class Pagination
    {
        public Pagination()
        {
            Start = 1;
            TotalResults = 1;
            Count = 1;
        }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "totalresults")]
        public int TotalResults { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}