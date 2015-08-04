using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace CommonTest
{
    public class IsNullVisitor : ExpressionVisitor
    {
        public bool IsNull { get; set; }
        public object Current { get; set; }

        protected override Expression VisitMember(MemberExpression node)
        {
            base.VisitMember(node);

            if (this.CheckNull())
            {
                return node;
            }

            var member = (PropertyInfo)node.Member;
            this.Current = member.GetValue(Current, null);

            CheckNull();

            return node;
        }

        private bool CheckNull()
        {
            return (IsNull = this.Current == null);
        }
    }

    public static class MyExtension
    {
        public static bool IsNull<T>(this T root, Expression<Func<T, object>> getter)
        {
            var visitor = new IsNullVisitor { Current = root };
            visitor.Visit(getter);
            return visitor.IsNull;
        }
    }


}
