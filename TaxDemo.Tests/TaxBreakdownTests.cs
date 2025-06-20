using NUnit.Framework.Internal;
using tax_demo.Components.Interfaces;
using tax_demo.Components.Models;

namespace TaxDemo.Tests
{
    [TestFixture(typeof(TaxBreakdown))]
    public class TaxBreakdownTests<T> where T : ITaxBreakdown, new()
    {
        
        public const double testGrossAnnualSalaryATier = 5000.00;
        public const double testGrossAnnualSalaryBTier = 20000.00;
        public const double testGrossAnnualSalaryCTier = 40000.00;
        
        //[Test]
        //public void CalculateATierTax()
    }
}
