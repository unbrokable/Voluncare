using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Specification
{
    internal static class SpecificationExtentions
    {
        internal static Specification<TEntity> Or<TEntity>(this Specification<TEntity> left, Specification<TEntity> right)
            where TEntity : IDbEntity
        {
            var leftExpr = left.Expression;
            var rightExpr = right.Expression;
            var leftParam = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<TEntity>(
                Expression.Lambda<Func<TEntity, bool>>(
                    Expression.OrElse(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)),
                    leftParam));
        }

        internal static Specification<TEntity> And<TEntity>(this Specification<TEntity> left, Specification<TEntity> right)
            where TEntity : IDbEntity
        {
            var leftExpr = left.Expression;
            var rightExpr = right.Expression;
            var leftParam = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<TEntity>(
                Expression.Lambda<Func<TEntity, bool>>(
                    Expression.AndAlso(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)),
                    leftParam));
        }

        internal static Specification<TEntity> Not<TEntity>(this Specification<TEntity> specification)
            where TEntity : IDbEntity
        {
            return new Specification<TEntity>(
                Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Not(specification.Expression.Body),
                    specification.Expression.Parameters));
        }
    }
}
