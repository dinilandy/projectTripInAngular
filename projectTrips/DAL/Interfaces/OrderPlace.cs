using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces;
public interface IOrderPlaceDAL
{
      Task<List<OrderPlace>> GetAllAsync();
      Task<int> AddAsync(OrderPlace id);
      Task<bool> DeleteAsync(int orderPlaceId);
      Task<OrderPlace> GetByIdAsync(int OrderPlaceId);
}
