 using System.ComponentModel;

namespace RentManagerInterviewApi.Models.Entities
{
    public enum UnitStatus
    {
        Available,
        Occupied
    }
    public enum LeaseStatus
    {
        Active,
        Terminated,
        Expired
    }
    public enum InvoiceStatus
    {
        Pending,
        Paid,
        OverDue,
    }


}
