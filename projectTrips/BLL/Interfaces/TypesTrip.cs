using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces;

public interface ITypesTripBLL
{
     Task<List<DTO.classes.TypesTrip>> GetAllAsync();
     Task<int> AddAsync(DTO.classes.TypesTrip trip);
     Task<bool> DeleteAsync(int id);


    Task<List<DTO.classes.TheTrip>> GetTripByIdTypeBLLAsync(int id);



}
