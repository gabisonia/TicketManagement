using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TicketManagement.Application.Infrastructure
{
    public static class IsNullHelper
    {
        public static bool IsNull<T>(this T root, Expression<Func<T, object>> getter)
        {
            var visitor = new IsNullVisitor
            {
                CurrentObject = root
            };
            visitor.Visit(getter);
            return visitor.IsNull;
        }

        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }

        public static bool NotNull<T>(this T obj)
        {
            return obj != null;
        }

        public static string ToObjectName<T>(this T obj)
        {
            if (obj.IsNull())
            {
                return typeof(T).Name;
            }
            return string.Empty;
        }
    }

    public class IsNullVisitor : ExpressionVisitor
    {
        public bool IsNull { get; private set; }

        public object CurrentObject { get; set; }

        protected override Expression VisitMember(MemberExpression node)
        {
            base.VisitMember(node);
            if (CheckNull())
            {
                return node;
            }

            var member = (PropertyInfo)node.Member;
            CurrentObject = member.GetValue(CurrentObject, null);
            CheckNull();
            return node;
        }

        private bool CheckNull()
        {
            if (CurrentObject == null)
            {
                IsNull = true;
            }
            return IsNull;
        }
    }
}
