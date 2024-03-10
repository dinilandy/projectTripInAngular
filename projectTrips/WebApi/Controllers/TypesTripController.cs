using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TypesTripController : ControllerBase
    {
        ITypesTripBLL bll;

        public TypesTripController(ITypesTripBLL bll)
        {
            this.bll = bll;
        }
        [HttpGet]
        public async Task<List<DTO.classes.TypesTrip>> GetAllAsync()
        {
            return await bll.GetAllAsync();
        }
        [HttpPost("{Nametrip}")]
        public async Task<int> AddAsync(DTO.classes.TypesTrip trip)
        {
            return await bll.AddAsync(trip);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await bll.DeleteAsync(id);
        }
        [HttpGet("GetById/{id}")]
        public async Task<List<DTO.classes.TheTrip>> GetTripByIdTypeBLLAsync(int id)
        {
            return await bll.GetTripByIdTypeBLLAsync((int)id);    
        }
    }
}
