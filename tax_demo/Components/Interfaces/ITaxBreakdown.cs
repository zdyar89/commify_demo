namespace tax_demo.Components.Interfaces
{
     public interface ITaxBreakdown
    {
        // Properties
         double GrossAnnualSalary { get; set; }
         double GrossMonthlySalary { get; set; }
         double NetAnnualSalary { get; set; }
         double NetMonthlySalary { get; set; }
         double AnnualTaxPaid { get; set; }
         double MonthlyTaxPaid { get; set; }
    }
}
