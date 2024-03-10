using DAL.Models;
using DTO.mapper;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces;
public interface IOrderPlaceBLL
{
    Task<List<DTO.classes.OrderPlace>> GetAllTripsAsync(int id);
   // Task<DTO.classes.OrderPlace> AddAsync(DTO.classes.OrderPlace orderPlace);
    Task<int> AddAsync(DTO.classes.OrderPlace orderPlace);
    Task<bool> DeleteAsync(int id);
    Task<List<DTO.classes.OrderPlace>> GetAllAsync();

}
