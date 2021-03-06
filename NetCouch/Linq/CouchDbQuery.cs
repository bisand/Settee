﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Biseth.Net.Couch.Linq
{
    public class CouchDbQuery<T> : ICouchDbQueryable<T>
    {
        public CouchDbQuery(CouchDbQueryProvider<T> provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            Provider = provider;
            Expression = Expression.Constant(this);
        }

        public CouchDbQuery(ICouchDbQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof (IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }
            Provider = provider;
            Expression = expression;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var result = Provider.Execute(Expression);
            if (result is IEnumerable<T>) 
                return ((IEnumerable<T>) result).GetEnumerator();
            
            return new List<T> {(T) result}.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; private set; }
        public Type ElementType { get; private set; }
        public IQueryProvider Provider { get; private set; }
    }
}