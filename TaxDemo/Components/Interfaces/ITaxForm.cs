namespace TaxDemo.Components.Interfaces
{
     public interface ITaxForm
    {
        // Interface for TaxForm types

        double GrossAnnualSalary { get; set; }
        double GrossMonthlySalary { get; set; }
        double NetAnnualSalary { get; set; }
        double NetMonthlySalary { get; set; }
        double AnnualTaxPaid { get; set; }
        double MonthlyTaxPaid { get; set; }
        public void CalculateTaxItemization();
    }
}
