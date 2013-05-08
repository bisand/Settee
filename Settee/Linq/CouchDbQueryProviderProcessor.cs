﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Biseth.Net.Settee.Linq
{
    public class CouchDbQueryProviderProcessor<T>
    {
        private readonly ICouchDbQueryGenerator _queryGenerator;
        private readonly CouchDbTranslation _queryTranslation;

        public CouchDbQueryProviderProcessor(ICouchDbQueryGenerator queryGenerator, CouchDbTranslation queryTranslation)
        {
            _queryGenerator = queryGenerator;
            _queryTranslation = queryTranslation;
        }

        public object Execute(Expression expression)
        {
            VisitExpression(expression);
            return new List<T>();
        }

        protected void VisitExpression(Expression expression)
        {
            if (expression is BinaryExpression)
            {
                VisitBinaryExpression((BinaryExpression) expression);
            }
            else
            {
                switch (expression.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        VisitMemberAccess((MemberExpression) expression, true);
                        break;
                    case ExpressionType.Not:
                        var unaryExpressionOp = ((UnaryExpression) expression).Operand;
                        switch (unaryExpressionOp.NodeType)
                        {
                            case ExpressionType.MemberAccess:
                                VisitMemberAccess((MemberExpression) unaryExpressionOp, false);
                                break;
                            case ExpressionType.Call:
                                VisitMethodCall((MethodCallExpression) unaryExpressionOp, true);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(unaryExpressionOp.NodeType.ToString());
                        }
                        break;
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        VisitExpression(((UnaryExpression) expression).Operand);
                        break;
                    default:
                        if (expression is MethodCallExpression)
                        {
                            VisitMethodCall((MethodCallExpression) expression);
                        }
                        else if (expression is LambdaExpression)
                        {
                            VisitExpression(((LambdaExpression) expression).Body);
                        }
                        break;
                }
            }
        }

        private void VisitMethodCall(MethodCallExpression unaryExpressionOp, bool negated = false)
        {
        }

        private void VisitMemberAccess(MemberExpression expression, bool b)
        {
        }

        private void VisitBinaryExpression(BinaryExpression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.OrElse:
                    VisitOrElse(expression);
                    break;
                case ExpressionType.AndAlso:
                    VisitAndAlso(expression);
                    break;
                case ExpressionType.NotEqual:
                    VisitNotEquals(expression);
                    break;
                case ExpressionType.Equal:
                    VisitEquals(expression);
                    break;
                case ExpressionType.GreaterThan:
                    VisitGreaterThan(expression);
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    VisitGreaterThanOrEqual(expression);
                    break;
                case ExpressionType.LessThan:
                    VisitLessThan(expression);
                    break;
                case ExpressionType.LessThanOrEqual:
                    VisitLessThanOrEqual(expression);
                    break;
            }
        }

        private void VisitLessThanOrEqual(BinaryExpression expression)
        {
        }

        private void VisitLessThan(BinaryExpression expression)
        {
        }

        private void VisitGreaterThanOrEqual(BinaryExpression expression)
        {
        }

        private void VisitGreaterThan(BinaryExpression expression)
        {
        }

        private void VisitEquals(BinaryExpression expression)
        {
        }

        private void VisitNotEquals(BinaryExpression expression)
        {
        }

        private void VisitAndAlso(BinaryExpression expression)
        {
        }

        private void VisitOrElse(BinaryExpression expression)
        {
        }
    }
}