using System.Collections.Generic;
using Homework10.Services;

namespace Homework13.WebCalculator.Services
{
    public class RamCacheCalculator : CalculatorDecorator
    {
        private readonly Dictionary<string, decimal> Cache;

        public RamCacheCalculator(ICalculator calculator) : base(calculator)
        {
            Cache = new Dictionary<string, decimal>();
        }

        public override decimal Calculate(string expression)
        {
            if (Cache.ContainsKey(expression)) 
                return Cache[expression];
            var result = Calculator.Calculate(expression);
            Cache[expression] = result;
            return result;
        }
    }
}