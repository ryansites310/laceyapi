namespace StudyGuide.Api
{
    using System.Runtime.Serialization;
    using Models;

    [DataContract(Name = "resultmeta")]
    public class ResultMeta
    {
        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }
}