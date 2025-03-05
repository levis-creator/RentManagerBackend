using RentManagerInterviewApi.Models.Common;
using RentManagerInterviewApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Dtos.PaymentTransfer
{
    public class PaymentTransferDisplayDto
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public int? ToUnitId { get; set; }
        public string UnitNumber { get; set; } = string.Empty;
        public DateOnly TransferDate { get; set; }

    }
}
