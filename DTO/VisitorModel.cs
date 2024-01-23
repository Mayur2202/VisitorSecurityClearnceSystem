using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.DTO
{
    public class VisitorModel
    {
        public string UID {  get; set; }
        public string VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string VisitorEmailId { get; set; }
        public string VisitorPhoneNo { get; set; }
        public RequestStatus Status { get; set; }

    }
    public enum RequestStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
