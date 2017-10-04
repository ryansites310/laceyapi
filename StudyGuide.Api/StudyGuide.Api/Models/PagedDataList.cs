using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGuide.Api.Models
{
    using System.Runtime.Serialization;
    using Microsoft.EntityFrameworkCore;

    [DataContract]
    public class PagedTests : IPagedList<Test>
    {
        [DataMember]
        public int IndexFrom { get; }

        [DataMember]
        public int PageIndex { get; }

        [DataMember]
        public int PageSize { get; }

        [DataMember]
        public int TotalCount { get; }

        [DataMember]
        public int TotalPages { get; }

        [DataMember]
        public IList<Test> Items { get; }

        [DataMember]
        public bool HasPreviousPage { get; }

        [DataMember]
        public bool HasNextPage { get; }
    }
}
