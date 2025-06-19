using tax_demo.Components.Interfaces;
using tax_demo.Components.Models;

namespace TaxDemo.Tests
{
    [TestFixture(typeof(TaxBreakdown))]
    public class TaxBreakdownTests<T> where T : ITaxBreakdown, new()
    {
    }
}
