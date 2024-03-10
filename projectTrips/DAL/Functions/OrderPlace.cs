using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL.Functions;

public  class OrderPlaceDAL : IOrderPlaceDAL
{
    OrganizedTripsContext db;
    public OrderPlaceDAL(OrganizedTripsContext db)
    {
        this.db = db;
    }
    public async Task<OrderPlace> GetByIdAsync(int OrderPlaceId)
    {
        try
        {
            var OrderPlace = await db.OrderPlaces
                .Include(p => p.IdTripNavigation)
                .Include(p => p.IdUserNavigation)
                .FirstOrDefaultAsync(i => i.IdOrder == OrderPlaceId);

            if (OrderPlace == null)
            {
                return new OrderPlace();
            }
            return OrderPlace;
        }
        catch (Exception ex) 
        {
            return new OrderPlace();
        }
    }
    public async Task<bool> DeleteAsync(int orderPlaceId) 
    {
        try
        {
            var orderPlace = await GetByIdAsync(orderPlaceId);
            db.OrderPlaces.Remove(orderPlace);
           await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;   
        }   
        
    }
    public async Task<int> AddAsync(OrderPlace id)
    {
        try
        {
            var trip = await db.OrderPlaces.AddAsync(id);
            await db.SaveChangesAsync();
            return trip.Entity.IdOrder;
        }
        catch
        {
            return -1;
        }
    }


    public async Task<List<OrderPlace>> GetAllAsync()
    {
        try
        {
            return await db.OrderPlaces
                 .Include(p => p.IdTripNavigation)
                .Include(p => p.IdUserNavigation)
                .ToListAsync();
        }
        catch { return new List<OrderPlace>(); }    
       
    }
}
