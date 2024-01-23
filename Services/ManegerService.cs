using System.Runtime.InteropServices;
using VisitorSecurityClearnceSystem.CosmosDBService;
using VisitorSecurityClearnceSystem.DTO;
using VisitorSecurityClearnceSystem.Entities;
using VisitorSecurityClearnceSystem.Interfaces;

namespace VisitorSecurityClearnceSystem.Services
{
    public class ManegerService: IManagerService
    {
        public ICosmosService _cosmosService;
        public ManegerService(ICosmosService cosmosService)
        {
            _cosmosService = cosmosService;
        }
        public async Task<Manager>SignUp(Manager manager)
        {
            manager.Id=Guid.NewGuid().ToString();
            manager.UID = manager.Id;
            manager.DocumentType = "Maneger";

            manager.CreatedBy = "";
            manager.CreatedByName = "";
            manager.CreatedOn = DateTime.Now;

            manager.UpdatedBy = "";
            manager.UpdatedByName = "";
            manager.UpdatedOn = DateTime.Now;

            manager.Version = 1;
            manager.Active= true;
            manager.Archieved = false;

            Manager respons = await _cosmosService.SignUp(manager);
            return respons;


        }
        public async Task<Manager>AddUser(Manager User, DTO.UserRole userRole )
        {
            User.Id = Guid.NewGuid().ToString();
            User.UID = User.Id;
            if (userRole == DTO.UserRole.OfficeUser)
                User.DocumentType = "OfficeUser";
            else if (userRole == DTO.UserRole.SecurityUser)
                User.DocumentType = "SecurityUser";


            User.CreatedBy = "";
            User.CreatedByName = "";
            User.CreatedOn = DateTime.Now;

            User.UpdatedBy = "";
            User.UpdatedByName = "";
            User.UpdatedOn = DateTime.Now;

            User.Version = 1;
            User.Active = true;
            User.Archieved = false;

            Manager respons = await _cosmosService.AddUser(User);
            return respons;

        }

        public async Task<Manager> LoginOfficeUserSecurityUser(string userRole, string loginId, string password)
        {
            Manager user=await _cosmosService.LoginOfficeUserSecurityUser(userRole, loginId, password);
            return user;
        }

        public async Task<Visitor> GetVisitorById(string visitorId)
        {
            return await _cosmosService.GetVisitorById(visitorId);
        }

       /* public async Task UpdateVisitor(Maneger visitor)
        {
            return await _cosmosService.UpdateVisitor(visitor);

        }*/

        public Task UpdateVisitor(Visitor visitor)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Visitor>> GetAllRequest()
        {
            return await _cosmosService.GetAllRequest();
        }
        public async Task<Visitor> authorization(string Contactno)
        {
            return await _cosmosService.authorization(Contactno);

        }

        Task IManagerService.authorization(string Contactno)
        {
            var visitor =  _cosmosService.authorization(Contactno);
            return visitor;
        }

        //public async Task<>

    }
}
