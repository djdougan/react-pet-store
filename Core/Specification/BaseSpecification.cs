using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Specification
{
    public class BaseSpecification<T>: ISpecification<T>
    {
        public BaseSpecification(){

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria){
            Criteria1 = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set;}

        public Expression<Func<T, object>> OrderByDescending{ get; private set;}

        public int Take{ get; private set;}

        public int Skip { get; private set;}

        public bool IsPagingEnabled { get; private set;}

        public Expression<Func<T, bool>> Criteria1 { get; }


        protected void AddIncludes(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression){
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression){
            OrderByDescending = orderByDescendingExpression;
        }
    }
}