using System.Linq.Expressions;
namespace Core.Specifications
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification() { }
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = 
            new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T,object>> expression) {
            Includes.Add(expression);
        }
    }
}
