using System;
using System.Globalization;
using Homework10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework13.WebCalculator.Controllers
{
    public class CalculatorCacheController : Controller
    {
        private readonly ICalculator calculator;
        public CalculatorCacheController(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        [HttpGet]
        public string Calculate(string expression)
        {
            return calculator.Calculate(expression.GetUrlWithPluses()).ToString(CultureInfo.InvariantCulture);
        }
        
        [HttpGet]
        public IActionResult CalculateMemoryTest()
        {
            var rnd = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                var expression = $"{rnd.Next()}+{rnd.Next()}";
                calculator.Calculate(expression.GetUrlWithPluses()).ToString(CultureInfo.InvariantCulture);
            }

            return Ok();
        }
    }
}