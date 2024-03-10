using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces;

public interface ITypesTripDAL
{
    Task<List<TypesTrip>> GetAllAsync();
    Task<bool> DeleteAsync(int TypesTripId);
    Task<int> AddAsync(TypesTrip id);
    Task<TypesTrip> GetByIdAsync(int TypesTripId);


    Task<List<Models.TheTrip>> GetTripByIdTypeDLLAsync(int typesOfTrip);


}
