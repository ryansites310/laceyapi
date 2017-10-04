namespace StudyGuide.Api.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PagedDataRequest
    {
        [DataMember]
        public IEnumerable<FilterExpression> Filters { get; set; }

        [DataMember]
        public IEnumerable<FilterExpression> MultiSelectFilters { get; set; }

        [DataMember]
        public SortExpression Sort { get; set; }

        [DataMember]
        public Pagination Pagination { get; set; }
    }
}