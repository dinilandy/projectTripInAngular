using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DAL.Functions;
public partial class TypesTripDAL : ITypesTripDAL
{
    OrganizedTripsContext db;
    public TypesTripDAL(OrganizedTripsContext db)
    {
        this.db = db;
    }
    public async Task< TypesTrip> GetByIdAsync(int TypesTripId)
    {
        try
        {
            var TypesTrip = await db.TypesTrips.Include(x=>x.TheTrips).FirstOrDefaultAsync(i => i.IdType == TypesTripId);
            if (TypesTrip == null)
            {
                return new TypesTrip();
            }
            return TypesTrip;
        }
        catch
        {
            return new TypesTrip();
        }              
    }
    public async  Task<int> AddAsync(TypesTrip id)
    {
        try
        {
           var newTypesTrip=await db.TypesTrips.AddAsync(id);
           await db.SaveChangesAsync();
            return id.IdType;
        }
        catch
        {
            return -1;
        }
    }
    public async Task< bool> DeleteAsync(int TypesTripId)
    {
        try
        {
            var TypesTrip = await GetByIdAsync(TypesTripId);
            db.TypesTrips.Remove(TypesTrip);
             await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task< List<TypesTrip>> GetAllAsync()
    {
        try
        {
            return await db.TypesTrips.Include(x => x.TheTrips).ToListAsync();
        }
        catch
        { return new List<TypesTrip>(); }
    }
    public async Task<List<Models.TheTrip>> GetTripByIdTypeDLLAsync(int typesOfTrip)
    {
        try
        {
            List<Models.TheTrip> trips = new List<Models.TheTrip>();
            var t = await db.TheTrips.Include(x => x.IdTypeNavigation).ToListAsync();
            foreach (var item in t.Where(e => e.IdType == typesOfTrip))
            {
                trips.Add(item);
            }
            //var type = context.Trips.Where(e => e.TypeId == typesOfTrip);
            if (trips == null)
            {
                //logger.LogError("Don't have this trip");
            }
            return trips;
        }
        catch (Exception ex)
        {
            //logger.LogError("failed");
            return new List<TheTrip>();
        }
    }

}
