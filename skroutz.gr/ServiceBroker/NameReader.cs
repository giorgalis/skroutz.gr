using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace skroutz.gr.ServiceBroker
{
    public static class NameReader
    {
        public static string GetMemberNames<T>(IList<Expression<Func<T, object>>> expressions)
        {
            List<string> memberNames = new List<string>();
            foreach (var cExpression in expressions)
                memberNames.Add(GetMemberName(cExpression.Body).ToLower());

            return string.Join(",", memberNames);
        }

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
        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
                return ((MethodCallExpression)unaryExpression.Operand).Method.Name;

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
