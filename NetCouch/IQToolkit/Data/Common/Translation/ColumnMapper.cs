﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (MS-PL)

using System.Collections.Generic;
using System.Linq.Expressions;
using Biseth.Net.Couch.IQToolkit.Data.Common.Expressions;

namespace Biseth.Net.Couch.IQToolkit.Data.Common.Translation
{
    /// <summary>
    /// Rewrite all column references to one or more aliases to a new single alias
    /// </summary>
    public class ColumnMapper : DbExpressionVisitor
    {
        HashSet<TableAlias> oldAliases;
        TableAlias newAlias;

        private ColumnMapper(IEnumerable<TableAlias> oldAliases, TableAlias newAlias)
        {
            this.oldAliases = new HashSet<TableAlias>(oldAliases);
            this.newAlias = newAlias;
        }

        public static Expression Map(Expression expression, TableAlias newAlias, IEnumerable<TableAlias> oldAliases)
        {
            return new ColumnMapper(oldAliases, newAlias).Visit(expression);
        }

        public static Expression Map(Expression expression, TableAlias newAlias, params TableAlias[] oldAliases)
        {
            return Map(expression, newAlias, (IEnumerable<TableAlias>)oldAliases);
        }

        protected override Expression VisitColumn(ColumnExpression column)
        {
            if (this.oldAliases.Contains(column.Alias))
            {
                return new ColumnExpression(column.Type, column.QueryType, this.newAlias, column.Name);
            }
            return column;
        }
    }
}
