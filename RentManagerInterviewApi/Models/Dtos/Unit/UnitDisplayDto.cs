using RentManagerInterviewApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentManagerInterviewApi.Models.Dtos.Unit
{
    public class UnitDisplayDto
    {
        public int Id { get; set; }
        public string UnitNumber { get; set; } = string.Empty;
        public UnitStatus Status { get; set; } = UnitStatus.Available;
        public string ApartmentName { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
    }
}
