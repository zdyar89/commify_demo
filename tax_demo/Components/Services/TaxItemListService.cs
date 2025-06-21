using tax_demo.Components.Interfaces;
using tax_demo.Components.Models;


namespace tax_demo.Components.Services
{
    // Composite class service for TaxBreakdown and TaxItem objects
    public class TaxItemListService
    {
        // Class props

        private readonly ILogger _logger;
        public required IQueryable<TaxItem> TaxItems { get; set; }

        // Method to aggregate a TaxItemList
        public IQueryable<TaxItem> GetTaxList(ITaxForm taxBreakdown)
        {
            // Constructor for TaxList objects

            try
            {
                TaxItems = new List<TaxItem>
                {
                new TaxItem { Label = "Gross Annual Salary", Value = taxBreakdown.GrossAnnualSalary},
                new TaxItem { Label = "Gross Monthly Salary", Value = taxBreakdown.GrossMonthlySalary},
                new TaxItem { Label = "Net Annual Salary", Value = taxBreakdown.NetAnnualSalary},
                new TaxItem { Label = "Net Monthly Salary", Value = taxBreakdown.NetMonthlySalary},
                new TaxItem { Label = "Annual Tax Paid", Value = taxBreakdown.AnnualTaxPaid},
                new TaxItem { Label = "Monthly Tax Paid", Value = taxBreakdown.MonthlyTaxPaid},
                }.AsQueryable();
            }
            catch (Exception e)
            {
                _logger.LogError($"An error has occurred for GetTaxList(): {e}");
            }

            return TaxItems;
        }
    }
}
