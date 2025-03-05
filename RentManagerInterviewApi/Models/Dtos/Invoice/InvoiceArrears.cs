namespace RentManagerInterviewApi.Models.Dtos.Invoice
{
    public class InvoiceArrears
    {
        public string TenantName { get; set; } = string.Empty;
        public string ApartmentName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal OverpaidAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
    }
}
