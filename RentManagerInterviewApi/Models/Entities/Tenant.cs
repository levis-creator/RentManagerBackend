using RentManagerInterviewApi.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Entities
{
   public class Tenant : BaseEntity
    {

        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public int? UnitId { get; set; }
        private Unit? _unit;

        public Unit? Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                if (value != null)
                {
                    value.Status = UnitStatus.Occupied; // Automatically update status
                }
            }
        }

        public ICollection<LeaseAgreement> LeaseAgreements { get; set; } = [];
        public ICollection<PaymentTransfer> PaymentTransfers { get; set; } = [];
    }

}
