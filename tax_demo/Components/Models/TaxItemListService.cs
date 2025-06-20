namespace tax_demo.Components.Models
{
    // Composite class service for TaxBreakdown and TaxItem objects
    public class TaxItemListService
    {
        // Method to aggregate a TaxItemList
        public IQueryable<TaxItem> GetTaxList(TaxBreakdown taxBreakdown)
        {
            // Constructor for TaxList objects
            IQueryable<TaxItem> taxItems = new List<TaxItem>
            {
            new TaxItem { Label = "Gross Annual Salary", Value = taxBreakdown.GrossAnnualSalary},
            new TaxItem { Label = "Gross Monthly Salary", Value = taxBreakdown.GrossMonthlySalary},
            new TaxItem { Label = "Net Annual Salary", Value = taxBreakdown.NetAnnualSalary},
            new TaxItem { Label = "Net Monthly Salary", Value = taxBreakdown.NetMonthlySalary},
            new TaxItem { Label = "Annual Tax Paid", Value = taxBreakdown.AnnualTaxPaid},
            new TaxItem { Label = "Monthly Tax Paid", Value = taxBreakdown.MonthlyTaxPaid},
            }.AsQueryable();

            return taxItems;
        }
    }
}
