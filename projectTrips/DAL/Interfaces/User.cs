using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces;
public interface IUserDAL
{
    Task<User> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<bool> DeleteAsync(int UserId);
    Task<int> AddAsync(User id);
    Task<bool> UpdateAsync(User User);
    Task<User> GetUserByMailAndPasswordAsync(string email, string PasswordID);
}
