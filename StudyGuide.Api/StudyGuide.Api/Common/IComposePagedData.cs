

namespace StudyGuide.Api.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    interface IComposePagedData<TEntity> where TEntity : class
    {
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GeneratedOrderByClause();

        Expression<Func<TEntity, bool>> GenerateWhereClause();

        int GenerateSkip();

        int GenerateTake();
    }
}
