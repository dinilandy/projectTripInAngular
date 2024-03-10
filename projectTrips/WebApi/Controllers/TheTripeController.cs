using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   
       [ Route("api/[controller]")]
        [ApiController]
        public class TheTripeController : ControllerBase
        {
            ITheTripBLL bll;

            public TheTripeController(ITheTripBLL bll)
            {
                this.bll = bll;
            }

            [HttpGet]
            public async Task<List<DTO.classes.TheTrip>> GetAllAsync()
            {
                return await bll.GetAllAsync();
            }
        [HttpPost("addTrip/{trip}")]
        public async Task<int> addAsync(DTO.classes.TheTrip trip)

        {
            return await bll.AddAsync(trip);
        }
        [HttpGet("GetInvitesToTrip/{id}")]
        public async Task<List<DTO.classes.OrderPlace>> GetInvitesToTripAsync(int id)
        {
            return await bll.GetInvitesToTripAsync(id);
        }
        [HttpPut("updateTrip/{Trip}")]
        public async Task<bool> updateAsync(DTO.classes.TheTrip trip)
        {
            return await bll.UpdateAsync(trip);   
        }
        [HttpGet("GetTripById/{id}")]
        public async Task<DTO.classes.TheTrip> GetByIdAsync(int id)
        {
            return await bll.GetByIdAsync(id);
        }

        }

    //public class TheTripeController : ControllerBase
    //{
    //    ITypesTripBLL bllType;
    //    IOrderPlaceBLL bllOrder;
    //    ITheTripBLL bllTrip;
    //    public TheTripeController(ITheTripBLL bllTrip, ITypesTripBLL bllType, IOrderPlaceBLL bllOrder)
    //    {
    //        this.bllTrip = bllTrip;
    //        this.bllType = bllType;
    //        this.bllOrder = bllOrder;
    //    }
    //    //order/////////////////////////////////////////////////
    //    [HttpGet]
    //    public async Task<List<DTO.classes.OrderPlace>> GetAllToTripAsync()
    //    {
    //        return await bllOrder.GetAllToTripAsync();
    //    }
    //    [HttpPost]
    //    [Route("OrderPlace")]
    //    public async Task<int> AddAsync(DTO.classes.OrderPlace orderPlace)
    //    {
    //        return await bllOrder.AddAsync(orderPlace);
    //    }
    //    [HttpDelete]
    //    [Route("{id}")]
    //    public async Task<bool> DeleteAsync(int id)
    //    {
    //        return await bllOrder.DeleteAsync(id);
    //    }
    //    //Trip////////////////////////////////////////////////
    //    [HttpGet]
    //    public async Task<List<DTO.classes.TheTrip>> GetAllAsync()
    //    {
    //        return await bllTrip.GetAllAsync();
    //    }

    //    [HttpPost]
    //    [Route("trip")]
    //    public async Task<int> addAsync(DTO.classes.TheTrip trip)
    //    {
    //        return await bllTrip.addAsync(trip);
    //    }
    //    //[HttpGet]
    //    //public async List<DTO.classes.OrderPlace> GetInvitesToTripAsync(int id)
    //    //{
    //    //return await bll.GetInvitesToTripAsync<DTO.classes.OrderPlace>(id); 
    //    //}
    //    [HttpPut]
    //    [Route("updateAsync/{id}")]
    //    public async Task<bool> updateAsync(DTO.classes.TheTrip Trip, int id)
    //    {
    //        return await bllTrip.updateAsync(Trip, id);
    //    }
    //    [HttpGet]
    //    [Route("{id}")]
    //    public async Task<DTO.classes.TheTrip> GetByIdAsync(int id)
    //    {
    //        return await bllTrip.GetByIdAsync(id);
    //    }
    //    //Type///////////////////////////////////////////////
    //    [HttpGet]
    //    public async Task<List<DTO.classes.TypesTrip>> GetAllAsyncType()
    //    {
    //        return await bllType.GetAllAsync();
    //    }
    //    [HttpPost]
    //    [Route("trip")]
    //    public async Task<int> AddAsync(DTO.classes.TypesTrip trip)
    //    {
    //        return await bllType.AddAsync(trip);
    //    }
    //    [HttpDelete]
    //    [Route("{id}")]
    //    public async Task<bool> DeleteAsyncType(int id)
    //    {
    //        return await bllType.DeleteAsync(id);
    //    }
    }
