using RentManagerInterviewApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Dtos.LeaseAgreement
{
    public class LeaseAgreementDisplayDto
    {
        public int Id { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public int? UnitId { get; set; }
        public string UnitNumber { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; } = new DateOnly();
        public DateOnly EndDate { get; set; } = new DateOnly();
        public decimal RentAmount { get; set; }
        public LeaseStatus Status { get; set; } = LeaseStatus.Active;
        public string StatusDescription { get; set; } = string.Empty;
    }
}
