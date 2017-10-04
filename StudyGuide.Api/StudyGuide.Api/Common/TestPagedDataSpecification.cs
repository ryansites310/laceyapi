namespace StudyGuide.Api.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class TestPagedDataSpecification : PagedDataSpecification<Test>
    {
        private readonly PagedDataRequest _request;

        public TestPagedDataSpecification(PagedDataRequest request) : base(request)
        {
            _request = request;
        }

        public override Func<IQueryable<Test>, IOrderedQueryable<Test>> GeneratedOrderByClause()
        {
            IOrderedQueryable<Test> OrderByClause(IQueryable<Test> o) => o.OrderByDescending(w => w.CreateDate);

            return OrderByClause;
        }


        public override Expression<Func<Test, bool>> GenerateWhereClause()
        {
            var whereClause = PredicateExtensions.Begin<Test>();

            if (_request.Filters == null && _request.MultiSelectFilters == null)
            {
                return whereClause;
            }

            return whereClause
                .And(TestIdEqauls());
        }


        private Expression<Func<Test, bool>> TestIdEqauls()
        {
            var isTestIdNullOrEmpty = _request.Filters.All(r => r.ColumnName.ToLower() != "rowId");
            var testIdFilter = _request.Filters.FirstOrDefault(r => r.ColumnName.ToLower() == "rowId");
            var testIdFilterValue = testIdFilter != null ? Convert.ToInt32(testIdFilter.Filter) : 0;

            return (f) =>
                (
                    isTestIdNullOrEmpty ||
                    f.RowId.Equals(testIdFilterValue)
                );
        }
    }
}
