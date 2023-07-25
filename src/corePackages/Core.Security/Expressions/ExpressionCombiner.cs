using System.Linq.Expressions;

namespace Core.Security.Expressions
{
    public static class ExpressionCombiner
    {
        /// <summary>
        /// Birleştirilmiş iki lambda ifadesini geri döndürür.
        /// </summary>
        /// <typeparam name="T">Lambda ifadelerinin parametre türü.</typeparam>
        /// <param name="expression1">Birinci lambda ifadesi.</param>
        /// <param name="expression2">İkinci lambda ifadesi.</param>
        /// <returns>İki lambda ifadesini birleştirilmiş hali.</returns>
        public static Expression<Func<T, bool>> Combine<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            if (expression1 == null && expression2 == null)
            {
                return null;
            }

            if (expression1 == null)
            {
                return expression2;
            }

            if (expression2 == null)
            {
                return expression1;
            }

            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expression1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expression1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expression2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expression2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        /// <summary>
        /// LINQ ifadeleri üzerinde gezinme ve belirli bir ifadeyi diğer bir ifadeyle değiştirme işlevlerini sağlar.
        /// </summary>
        public class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }
    }
}