using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBLL bll;

        public UserController(IUserBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet("GetAllAsync")]
        public async Task<List<DTO.classes.User>> GetAllAsync()
        {
            return await bll.GetAllAsync();
        }

        [HttpGet("GetUserByMailAndPasswordAsync/{email}/{password}")]
        public async Task<DTO.classes.User> GetUserByMailAndPasswordAsync(string email, string password)
        {
            return await bll.GetUserByMailAndPasswordAsync(email, password);
        }
        [HttpPost("AddUserAsync/User")]
        public async Task<DTO.classes.User> AddUserAsync(DTO.classes.User user)
        {
            return await bll.AddUserAsync(user);
        }
        [HttpPut("UpdateAsync/User")]
        public async Task<bool> UpdateAsync(DTO.classes.User u)
        {
            return await bll.UpdateAsync(u);
        }
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await bll.DeleteAsync(id);
        }
        [HttpGet("GetAllTripsAsync/user")]
        public async Task<List<DTO.classes.TheTrip>> GetAllTripsAsync(short userId)

        {
            return await bll.GetAllTripsAsync(userId);
        }


    }
}
