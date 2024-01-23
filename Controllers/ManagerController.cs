using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VisitorSecurityClearnceSystem.CosmosDBService;
using VisitorSecurityClearnceSystem.DTO;
using VisitorSecurityClearnceSystem.Entities;
using VisitorSecurityClearnceSystem.Interfaces;
using VisitorSecurityClearnceSystem.Services;

namespace VisitorSecurityClearnceSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        public IManagerService _manegerServcie;
        public IMapper _mapper;
        public IVisitorService _visitorServcie;
       public ICosmosService _cosmosService;
        public ManagerController(IManagerService manegerService,IMapper mapper ,IVisitorService visitorService,ICosmosService cosmosService) 
        {
            _manegerServcie = manegerService;
            _mapper = mapper;  
            _visitorServcie = visitorService;
            _cosmosService = cosmosService;
        }
       /* [HttpPost]
        public async Task<IActionResult> SignUp(AdminModel adminModel)
        {
            try
            {
                Manager manager= _mapper.Map<Manager>(adminModel);

                var respons = await _manegerServcie.SignUp(manager);

                var model = _mapper.Map<AdminModel>(respons);
                return Ok("Inserted successfully"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
        [HttpPost]
        public async Task<IActionResult> AddUsers(AdminModel adminModel)
        {
            try
            {
                Manager User = _mapper.Map<Manager>(adminModel);

                var respons = await _manegerServcie.AddUser(User, adminModel.Role);

                var model = _mapper.Map<AdminModel>(respons);
                return Ok("Inserted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult>LoginOfficeUserSecurityUser(string userRole,string loginId,string password)
        {
            try
            {
                var user = await _manegerServcie.LoginOfficeUserSecurityUser(userRole, loginId, password);
                if (user == null)
                {
                    return BadRequest("Invalid credentials.");
                }
                var usermodel=_mapper.Map<AdminModel>(user);
                return Ok("LogIn successfully");
;
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> ReviewVisitorStatus(string visitorId, DTO.RequestStatus status)
        {
            try
            {
                // Retrieve the visitor from the database
                Visitor visitor = await _manegerServcie.GetVisitorById(visitorId);

                if (visitor == null)
                {
                    return BadRequest("Visitor not found.");
                }

                // Update the status
                visitor.Status = (Entities.RequestStatus)status;

                // Save the updated visitor back to the database
                await _cosmosService.UpdateVisitorStatus(visitorId,status);

                return Ok("Visitor status updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetAllRequest()
        {
            try
            {
               
                var visitorRequests = await _manegerServcie.GetAllRequest();
                var model = _mapper.Map<List<VisitorModel>>(visitorRequests);

                return Ok(model);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]

        public async Task<IActionResult>authorization(string Contactno)
        {
            try
            {
                var visitor = await _cosmosService.authorization(Contactno);

                if (visitor == null)
                {
                    return BadRequest("Invalid credentials.");
                }

                if (visitor.Status != Entities.RequestStatus.Approved)
                {
                    return BadRequest("Visitor request not approved. Access denied.");
                }

                var visitorModel = _mapper.Map<VisitorModel>(visitor);
                return Ok(visitorModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
