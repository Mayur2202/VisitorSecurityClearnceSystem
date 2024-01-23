namespace VisitorSecurityClearnceSystem.DTO
{
    public class AdminModel
    {
        /* public string UID {  get; set; }    
         public string ManegerId { get; set; }
         public string ManegerName { get; set; }
         public string ManegerPassword {  get; set; }   */
        public string UID { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
    }
    public enum UserRole
    {
        OfficeUser=1,
        SecurityUser=2
    }

}
