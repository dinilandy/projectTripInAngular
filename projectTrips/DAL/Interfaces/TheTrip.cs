using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces;

public interface ITheTripDAL
{
    Task<List<TheTrip>> GetAllAsync();
    Task<bool> UpdateAsync(TheTrip i);
    Task<int> AddAsync(TheTrip id);
    Task<TheTrip> GetByIdAsync(int TheTrips);
   




}
