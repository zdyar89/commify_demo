using NUnit.Framework.Internal;
using TaxDemo.Tests.TestSetups;
using tax_demo.Components.Models;
using tax_demo.Components.Interfaces;

namespace TaxDemo.Tests
{
    [TestFixture]
    public class TaxBreakdownTests<ITaxForm> : TestTaxFormBase<ITaxForm>
    {   
        // TaxBreakdown data object tests
        
        [Test]
        public void CalculateATierTax()
        {
            taxBreakdown.GrossAnnualSalary = testGrossAnnualSalaryATier;
            taxBreakdown.CalculateTaxItemization();
            Assert.Equals(taxBreakdown.AnnualTaxPaid, 0);
        }
    }
}
