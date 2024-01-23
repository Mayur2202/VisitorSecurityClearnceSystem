using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.Interfaces
{
    public interface IManagerService
    {
        Task<Manager> SignUp(Manager manager);
        Task<Manager>AddUser(Manager User, DTO.UserRole userRole);
        Task<Manager> LoginOfficeUserSecurityUser(string userRole, string loginId, string password);
        Task<Visitor> GetVisitorById(string visitorId);
        Task UpdateVisitor(Visitor visitor);
        // Task<Maneger> AddOfficeUser(Maneger maneger,Entities.UserRole userRole);
        Task<List<Visitor>> GetAllRequest();
        Task authorization(string Contactno);
    }
}
