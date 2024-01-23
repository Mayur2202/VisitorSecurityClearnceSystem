using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.CosmosDBService
{
    public interface ICosmosService
    {
        Task<Manager>SignUp(Manager manager);
        Task<Manager> AddUser(Manager User, UserRole userRole);
        Task<Manager> LoginOfficeUserSecurityUser(string userRole, string loginId, string password);
       // Task<Maneger> AddOfficeUser(Maneger maneger);

        Task<Visitor> RegisterFrom(Visitor visitor);
        Task UpdateVisitorStatus(string visitorId, DTO.RequestStatus status);
        Task<Visitor> GetVisitorById(string visitorId);
        Task<Manager> AddUser(Manager User);
        //Task<Visitor> GetAllRequest();
        Task<List<Visitor>> GetAllRequest();
        Task <Visitor>authorization(string Contactno);
    }
}
