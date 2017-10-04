

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class FilterExpression
    {
        [DataMember]
        public string ColumnName { get; set; }

        [DataMember]
        public string Filter { get; set; }
    }
}