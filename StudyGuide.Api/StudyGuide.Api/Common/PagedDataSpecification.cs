namespace StudyGuide.Api.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public abstract class PagedDataSpecification<TEntity> : IComposePagedData<TEntity> where TEntity : class
    {
        private readonly PagedDataRequest _request;
        protected PagedDataSpecification(PagedDataRequest request)
        {
            _request = request;
        }

        public abstract Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GeneratedOrderByClause();

        public virtual int GenerateSkip()
        {
            if (_request.Pagination == null)
            {
                return 0;
            }

            return _request.Pagination.Start;
        }

        public virtual int GenerateTake()
        {
            if (_request.Pagination == null)
            {
                return 10;
            }
            return _request.Pagination.Count;
        }

        public abstract Expression<Func<TEntity, bool>> GenerateWhereClause();
    }
}
