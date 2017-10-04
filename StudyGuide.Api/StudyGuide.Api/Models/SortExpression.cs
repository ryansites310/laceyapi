
namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class SortExpression
    {
        [DataMember]
        public string SortColumn { get; set; }

        [DataMember]
        public string SortDirection { get; set; }
    }
}