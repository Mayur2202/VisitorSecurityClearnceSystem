using VisitorSecurityClearnceSystem.Entities;

namespace VisitorSecurityClearnceSystem.Interfaces
{
    public interface IVisitorService
    {
        Task authorization(string contactno);
        Task<Visitor> RegisterFrom(Visitor visitor);

        //Task<Visitor> RegisterFrom(Visitor visitor);
        Task UpdateVisitorStatus(string visitorId, RequestStatus status);
    }
}
