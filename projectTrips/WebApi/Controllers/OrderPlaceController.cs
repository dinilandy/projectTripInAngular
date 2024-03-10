using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderPlaceController : ControllerBase
    {
        IOrderPlaceBLL bll;

        public OrderPlaceController(IOrderPlaceBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet("GetAllToTrip/{id}")]
        public async Task<List<DTO.classes.OrderPlace>> GetAllTripsAsync(int id)
        {
            return await bll.GetAllTripsAsync(id);
        }
        [HttpPost("AddOrderPlace")]
        public async Task<int> AddAsync(DTO.classes.OrderPlace orderPlace)
        {
            return await bll.AddAsync(orderPlace);
        }
        [HttpDelete("DeleteOrderPlace/{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await bll.DeleteAsync(id);
        }
        [HttpGet]
        public async Task<List<DTO.classes.OrderPlace>> GetAllAsync()
        {
            return await bll.GetAllAsync(); 
        }


    }

}