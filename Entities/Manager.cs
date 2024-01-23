using Newtonsoft.Json;

namespace VisitorSecurityClearnceSystem.Entities
{
    public class Manager : MandatoryField
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UID { get; set; }

        [JsonProperty(PropertyName = "managerName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public UserRole Role { get; set; }

        [JsonProperty(PropertyName = "userLogin", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLogin { get; set; } 

        [JsonProperty(PropertyName = "passWord", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
    public enum UserRole
    {
        OfficeUser=1,
        SecurityUser=2
    }
 }
