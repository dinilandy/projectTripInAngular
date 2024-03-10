using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL.Functions;
public partial class UserDAl : IUserDAL
{ 

   public OrganizedTripsContext db;
    public UserDAl(OrganizedTripsContext db)
    {
        this.db = db;
    }
public async Task< User> GetByIdAsync(int id)
{
    try
    {
        var newUser =await db.Users.Include(x=>x.OrderPlaces)
                .FirstOrDefaultAsync(x => x.IdUser == id);
        if (newUser == null)
            return new User();
        else
            return newUser;
    }
    catch (Exception ex)
    {
        return new User();
    }
}
public async Task< User> GetUserByMailAndPasswordAsync(string email , string PasswordID)
    {
        try
        {
          var user= await db.Users.Include(x => x.OrderPlaces).FirstOrDefaultAsync(i => i.Email == email && i.PasswordIn == PasswordID);
            if (user == null)
            {
                return new User();
            }
            return user;
        }
        catch {
            return new User();
        }
    }
    

    public async Task< bool> UpdateAsync(User User)
    {
        try
        {
            var User1 =await GetByIdAsync( User.IdUser);
            if (User1 == null)
            {
                return false;
            }
                User1.IdUser= User.IdUser;
                User1.FirstName = User.FirstName;
                User1.LastName = User.LastName;
                User1.Email = User.Email;
                User1.PhoneNumber= User.PhoneNumber;
                User1.PasswordIn = User.PasswordIn;
                User1.FirstAidCertificate = User.FirstAidCertificate;
                await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<int> AddAsync(User user)
    {
        try
        {
           var newuser=await this.db.Users.AddAsync(user);
            await db.SaveChangesAsync();
      
            return user.IdUser;
            
        }
        catch(Exception ex) 
        {
            throw ex;
        }
        
    }
    public async Task< bool> DeleteAsync(int UserId)
    {
        try
        {
            var User =  await GetByIdAsync(UserId);
            db.Users.Remove( User);
            await db.SaveChangesAsync();
            return true;

        }
        catch 
        {
            return false;   
        }

    }
    public async Task< List<User>> GetAllAsync()
    {
        try
        { 
            return await db.Users.Include(x => x.OrderPlaces). ToListAsync();
        }
        catch { return new List<User>(); }  
        
    }
    
   
    

   

    
   
}


