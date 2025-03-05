namespace RentManagerInterviewApi.Models.Dtos.Payment
{
    public class PaymentDisplayDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int AmountPaid { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public DateOnly PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
    }
}
