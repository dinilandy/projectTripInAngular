using DAL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions;
public class TheTripDAL : ITheTripDAL
{
    OrganizedTripsContext db;
    public TheTripDAL(OrganizedTripsContext db)
    {
        this.db = db;
    }
    public async Task<TheTrip> GetByIdAsync(int TheTrips)
    {
        try
        {
            var trip = await db.TheTrips
                .Include(p=>p.IdTypeNavigation)
                .FirstOrDefaultAsync(i => i.IdTrip == TheTrips);
            if (trip == null)
            {
                return new TheTrip();
            }
            return trip;    
        }
        catch (Exception ex) {
            return new TheTrip();
        }
    }

    public async Task<int> AddAsync(TheTrip id)
    {
        try
        {
           var trip=await db.TheTrips.AddAsync(id);
           await db.SaveChangesAsync();
            return trip.Entity.IdTrip;
        }
        catch
        {
            return -1;
        }
    }
    public async Task< bool> DeleteAsync(int TheTripId)
    {
        try
        {
            var TheTrip = await GetByIdAsync(TheTripId);
            db.TheTrips.Remove(TheTrip);
            db.SaveChangesAsync();
            return true;    
        }
        catch 
        {
           return false;
        }

    }
    public async Task< bool> UpdateAsync( TheTrip i)
    {
        try
        {
            var theTrip1 = await GetByIdAsync(i.IdTrip);
            if(theTrip1 == null)
            {
                return false;
            }
            theTrip1.IdTrip= i.IdTrip;
            theTrip1.DurationTripInHours = i.DurationTripInHours;
            theTrip1.NumberPlacesAvailable = i.NumberPlacesAvailable;
            theTrip1.IdType = i.IdType;
            theTrip1.Date = i.Date;
            theTrip1.Image=i.Image;
            theTrip1.Price = i.Price;
            theTrip1.TargetTripe = i.TargetTripe;
            theTrip1.LeavingTime = i.LeavingTime;
            
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public  async Task<List<TheTrip>> GetAllAsync()
    {
        try
        {
            return await db.TheTrips.Include(p => p.IdTypeNavigation).ToListAsync();
        }
        catch
        {
            return new List<TheTrip>();
        }
       
    }
}
