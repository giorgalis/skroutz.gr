using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class NameReader.
    /// </summary>
    internal static class NameReader
    {
        /// <summary>
        /// Gets the member names.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The expressions.</param>
        /// <returns>System.String.</returns>
        public static string GetMemberNames<T>(IList<Expression<Func<T, object>>> expressions)
        {
            List<string> memberNames = new List<string>();
            foreach (var expression in expressions)
            {
                memberNames.Add(GetMemberName(expression.Body).ToLower());
            }
            return string.Join(",", memberNames);
        }

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">expression</exception>
        /// <exception cref="System.ArgumentException">The expression is not valid.</exception>
        private static string GetMemberName(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            if (expression is MemberExpression)
                return ((MemberExpression)expression).Member.Name;

            if (expression is MethodCallExpression)
                return ((MethodCallExpression)expression).Method.Name;

            if (expression is UnaryExpression)
                return GetMemberName((UnaryExpression)expression);

            throw new ArgumentException("The expression is not valid.");
        }
        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <param name="unaryExpression">The unary expression.</param>
        /// <returns>System.String.</returns>
        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
                return ((MethodCallExpression)unaryExpression.Operand).Method.Name;

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
