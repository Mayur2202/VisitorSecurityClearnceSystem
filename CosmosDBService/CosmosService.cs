using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System;
using VisitorSecurityClearnceSystem.DTO;
using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.CosmosDBService
{
    public class CosmosService: ICosmosService
    {
        public Container container;

        public CosmosService()
        {
            container = GetContainer();
        }
        public async Task<Manager>SignUp(Manager manager)
        {
            return await container.CreateItemAsync<Manager>(manager);
        }
        public async Task<Manager>AddUser(Manager User, DTO.UserRole userRole)
        {
            return await container.CreateItemAsync(User);
        }
        public async Task<Manager>AddUser(Manager User)
        {
            return await container.CreateItemAsync(User);
        }
        public async Task<Manager> LoginOfficeUserSecurityUser(string userRole, string loginId, string password)
        {
            Manager user = container.GetItemLinqQueryable<Manager>(true)
                  .Where(q => q.Role.ToString().ToLower()==userRole.ToLower()&& q.UserLogin.ToLower() == loginId.ToLower() 
                              && q.Password == password
                              && q.DocumentType == "OfficeUser"
                              && q.Active == true
                              && q.Archieved == false)
                  .AsEnumerable()
                  .FirstOrDefault();

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<Visitor> RegisterFrom(Visitor visitor)
        {
            return await container.CreateItemAsync<Visitor>(visitor);
        }
        //
        public async Task UpdateVisitorStatus(string uId, DTO.RequestStatus status )
        {
            

            Visitor visitor = container.GetItemLinqQueryable<Visitor>(true)
              .Where(q => q.UID == uId)
              .AsEnumerable()
              .FirstOrDefault();
           // Visitor visitor = await GetVisitorById(visitorId);

            if (visitor != null)
            {
                // Update the status
                visitor.Status = (Entities.RequestStatus)status;

                // Save the updated visitor back to the database
                await container.ReplaceItemAsync(visitor, visitor.UID);
            
            }

        }
        public async Task<Visitor> GetVisitorById(string visitorId)
        {
            Visitor visitor = container.GetItemLinqQueryable<Visitor>(true)
            .Where(q => q.UID == visitorId &&q.DocumentType== "Visitor"&& q.Active==true && q.Archieved==false)
            .AsEnumerable()
            .FirstOrDefault();
            return visitor;
        }

        private Container GetContainer()
        {
            string URI = Environment.GetEnvironmentVariable("Cosmos-URI");
            string PrimaryKey = Environment.GetEnvironmentVariable("auth-token");
            string DataBaseName = Environment.GetEnvironmentVariable("DataBase");
            string ContainerName = Environment.GetEnvironmentVariable("Container");

            CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
            Container container = cosmosClient.GetContainer(DataBaseName, ContainerName);
            return container;
        }

        public Task<Manager> AddUser(Manager manager, Entities.UserRole userRole)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<Visitor>> GetAllRequest()
        {
            var visitors = container.GetItemLinqQueryable<Visitor>(true)
                .Where(q => q.DocumentType == "Visitor" && q.Active == true && q.Archieved == false)
                .AsEnumerable()
                .ToList();

            return visitors;
        }
       public async Task<Visitor> authorization(string Contactno)
        {
           
            var visitor = container.GetItemLinqQueryable<Visitor>(true)
                .Where(q => q.VisitorPhoneNo == Contactno && q.DocumentType == "Visitor" && q.Active == true && q.Archieved == false)
                .AsEnumerable()
                .FirstOrDefault();


            if (visitor != null && visitor.Status == Entities.RequestStatus.Approved)
            { 
                return visitor;
            }
            return null;
        }

    }
}
