using NUnit.Framework.Internal;
using TaxDemo.Tests.TestSetups;
using TaxDemo.Components.Models;
using TaxDemo.Components.Interfaces;

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
