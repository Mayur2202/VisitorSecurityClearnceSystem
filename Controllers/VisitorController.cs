using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitorSecurityClearnceSystem.DTO;
using VisitorSecurityClearnceSystem.Entities;
using VisitorSecurityClearnceSystem.Interfaces;

namespace VisitorSecurityClearnceSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        public IVisitorService _visitorService;
        public IMapper _mapper;
        public VisitorController(IVisitorService visitorService, IMapper mapper)
        {
            _visitorService = visitorService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterFrom(VisitorModel visitorModel)
        {
            try
            {
                Visitor visitor=_mapper.Map<Visitor>(visitorModel);
                var respons=await _visitorService.RegisterFrom(visitor);
                var model=_mapper.Map<VisitorModel>(respons);
                return Ok(model);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        


        
    }
}
