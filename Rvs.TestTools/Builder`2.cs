using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Rvs.TestTools
{
    public abstract class Builder<TOutput, TBuilder> : IBuilder<TOutput> where TBuilder : class
    {
        private TOutput _instance;
        public static TBuilder Init()
        {
            return Activator.CreateInstance<TBuilder>();
        }

        public TBuilder With<T>(Expression<Func<TOutput, T>> memberLamda, T value)
        {
            if (_instance == null)
                _instance = Activator.CreateInstance<TOutput>();

            var memberSelectorExpression = memberLamda.Body as MemberExpression;
            if (memberSelectorExpression == null) return this as TBuilder;

            var property = memberSelectorExpression.Member as PropertyInfo;
            property?.SetValue(_instance, value, null);
            return this as TBuilder;
        }

        public TOutput Build()
        {
            return _instance;
        }
    }
}
