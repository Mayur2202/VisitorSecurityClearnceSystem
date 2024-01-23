using Newtonsoft.Json;

namespace VisitorSecurityClearnceSystem.Entities
{
    public class MandatoryField
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UID { get; set; }

        [JsonProperty(PropertyName = "dType", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdByName", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedByName", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { set; get; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archieved", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archieved { get; set; }
    }
    public class Visitor: MandatoryField
    {
        [JsonProperty(PropertyName = "visitorId", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorId { get; set; }

        [JsonProperty(PropertyName = "visitorName", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorName { get; set; }

        [JsonProperty(PropertyName = "visitorEmailId", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorEmailId { get; set; }

        [JsonProperty(PropertyName = "visitorPhoneNo", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorPhoneNo { get; set; }

        [JsonProperty(PropertyName ="requeststatus",NullValueHandling =NullValueHandling.Ignore)]
        public RequestStatus Status { get; set; }


    }
    public enum RequestStatus 
    {
        Pending=1,
        Approved=2,
        Rejected=3
    }
}
