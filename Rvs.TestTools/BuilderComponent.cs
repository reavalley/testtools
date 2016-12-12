using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Rvs.TestTools
{
    public class BuilderComponent<TOutput> : IBuilder<TOutput> where TOutput : class
    {
        private TOutput _instance;
        
        public BuilderComponent<TOutput> With<T>(Expression<Func<TOutput, T>> memberLamda, T value)
        {
            if (_instance == null)
                _instance = Activator.CreateInstance<TOutput>();

            var memberSelectorExpression = memberLamda.Body as MemberExpression;
            if (memberSelectorExpression == null) return this;

            var property = memberSelectorExpression.Member as PropertyInfo;
            property?.SetValue(_instance, value, null);
            return this;
        }

        public TOutput Build()
        {
            return _instance;
        }
    }
}
