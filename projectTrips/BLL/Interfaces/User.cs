using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces;
public interface IUserBLL
{
    
    Task<List<DTO.classes.User>> GetAllAsync();
    Task<DTO.classes.User> GetUserByMailAndPasswordAsync(string email, string password);
    Task<DTO.classes.User> AddUserAsync(DTO.classes.User user);   //Task<DTO.classes.User> AddUserAsync(DTO.classes.User user);

    Task<bool> UpdateAsync(DTO.classes.User u);
    Task<bool> DeleteAsync(int id);
    Task<List<DTO.classes.TheTrip>> GetAllTripsAsync(short userId);
}
