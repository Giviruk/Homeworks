using System.Linq;
using System.Threading;
using Homework10.Models;

namespace Homework10.Services
{
    public class ExpressionCacheService
    {
        private readonly ApplicationContext context;

        public ExpressionCacheService(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(CalculatorExpression expression)
        {
            context.Expressions.Add(expression);
            context.SaveChanges();
        }

        public CalculatorExpression Get(string expression)
        {
            return context.Expressions?.FirstOrDefault(x => x.Input == expression);
        }
    }
}