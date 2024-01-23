using VisitorSecurityClearnceSystem.CosmosDBService;
using VisitorSecurityClearnceSystem.Entities;
using VisitorSecurityClearnceSystem.Interfaces;

namespace VisitorSecurityClearnceSystem.Services
{
    public class VisitorService: IVisitorService
    {
        public ICosmosService _cosmosService;
        public VisitorService(ICosmosService cosmosServie)
        {
            _cosmosService = cosmosServie;
        }

        public Task authorization(string contactno)
        {
            throw new NotImplementedException();
        }

        public async Task<Visitor> RegisterFrom(Visitor visitor)
        {
            visitor.Id = Guid.NewGuid().ToString();
            visitor.UID = visitor.Id;
            visitor.DocumentType = "Visitor";

            visitor.CreatedBy = "";
            visitor.CreatedByName = "";
            visitor.CreatedOn = DateTime.Now;

            visitor.UpdatedBy = "";
            visitor.UpdatedByName = "";
            visitor.UpdatedOn = DateTime.Now;

            visitor.Version = 1;
            visitor.Active = true;
            visitor.Archieved = false;

            Visitor respons = await _cosmosService.RegisterFrom(visitor);
            return respons;

        }

        public Task UpdateVisitorStatus(string visitorId, RequestStatus status)
        {
            throw new NotImplementedException();
        }
       

    }
}
