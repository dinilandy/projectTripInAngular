using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces;

public interface ITheTripBLL
{
    Task<List<DTO.classes.TheTrip>> GetAllAsync();
    Task<List<DTO.classes.OrderPlace>> GetInvitesToTripAsync(int id);
  
    Task<int> AddAsync(DTO.classes.TheTrip trip);

     Task<DTO.classes.TheTrip> GetByIdAsync(int id);
    Task<bool> UpdateAsync(DTO.classes.TheTrip trip);






}
