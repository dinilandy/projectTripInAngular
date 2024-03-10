using AutoMapper;
using BLL.Interfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using DTO.classes;
using DTO.mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL.Functions;
public class UserBLL : IUserBLL
{
    IUserDAL dal;
    IOrderPlaceDAL OrderPlaceDAL;
    ITheTripDAL TheTripDAL;

    IMapper mapper;
    public UserBLL(IUserDAL dal, IOrderPlaceDAL OrderPlaceDAL , ITheTripDAL TheTripDAL )
    {
        this.dal = dal;
        this.OrderPlaceDAL = OrderPlaceDAL;   
        this.TheTripDAL = TheTripDAL; 

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DTO.mapper.Mapper>();
        });

        mapper = config.CreateMapper();
       
    }
    //GetAll
    public async Task<List<DTO.classes.User>> GetAllAsync()
    {

        return mapper.Map<List<DAL.Models.User>, List<DTO.classes.User>>(await dal.GetAllAsync());
    }
    //GetUserByMailAndPassword

    public async Task<DTO.classes.User> GetUserByMailAndPasswordAsync(string email, string password)
    {
        DAL.Models.User user = await dal.GetUserByMailAndPasswordAsync(email, password);
        if (user != null)
        {
            return mapper.Map<DAL.Models.User, DTO.classes.User>(user);
        }
        return null;
    }
    
    //AddUser
    public async Task<DTO.classes.User> AddUserAsync(DTO.classes.User user)
    {
        try
        {
            bool isNameValid = ValidationHelper.IsValidHebrewName(user.FirstName);
            bool isPhoneNumberValid = ValidationHelper.IsValidPhoneNumber(user.PhoneNumber);
            bool isEmailValid = ValidationHelper.IsValidEmail(user.Email);
            bool isPasswordValid = ValidationHelper.IsValidPassword(user.PasswordIn);
            if (isNameValid && isPhoneNumberValid && isEmailValid && isPasswordValid)
            {
                var newUser = mapper.Map<DAL.Models.User>(user);
                var use = await dal.AddAsync(newUser);
                if (use == -1)
                    return new DTO.classes.User();
                return user;
            }
            return new DTO.classes.User();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    //bool isNameValid = ValidationHelper.IsValidHebrewName(user.FirstName);
    //bool isPhoneNumberValid = ValidationHelper.IsValidPhoneNumber(user.PhoneNumber);
    //bool isEmailValid = ValidationHelper.IsValidEmail(user.Email);
    //bool isPasswordValid = ValidationHelper.IsValidPassword(user.PasswordIn);
    //if (isNameValid && isPhoneNumberValid && isEmailValid && isPasswordValid)
    //{
    //    //            try
    //    //            {             
    //    //                    var newUser = mapper.Map<DAL.Models.User>(user);
    //    //                    var use = await dal.AddAsync(newUser);
    //    //                    if (use == -1)
    //    //                        return new User();
    //    //                    return user;
    //    //            }
    //    //                return new User();
    //    //            catch (Exception ex)
    //    //            {
    //    //                //logger.LogError("failed" + ex.Message);
    //    //                throw ex;
    //    //            }
    //    //    }

    //    //}
    //    try
    //    {
    //        var mapUser = mapper.Map<DAL.Models.User>(user);
    //        var answer = await dal.AddAsync(mapUser);
    //        return mapper.Map<DTO.classes.User>(answer);

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //return -1;


    //UpdateUser

    public async Task<bool> UpdateAsync(DTO.classes.User user)
    {
        try
        {
            bool isNameValid = ValidationHelper.IsValidHebrewName(user.FirstName);
            bool isPhoneNumberValid = ValidationHelper.IsValidPhoneNumber(user.PhoneNumber);
            bool isEmailValid = ValidationHelper.IsValidEmail(user.Email);
            bool isPasswordValid = ValidationHelper.IsValidPassword(user.PasswordIn);
            if (!(isNameValid && isPhoneNumberValid && isEmailValid && isPasswordValid))
                return false;

            //var updUser = 
            return await dal.UpdateAsync(mapper.Map<DTO.classes.User, DAL.Models.User>(user));
            //return true;
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
    }
    //DeleteUser
    public async Task<bool> DeleteAsync(int id)
    {
        
        var list = await OrderPlaceDAL.GetAllAsync();
        List<DTO.classes.OrderPlace> newList = new List<DTO.classes.OrderPlace>();
        try
        {
            list.ForEach(x => { newList.Add(mapper.Map<DAL.Models.OrderPlace, DTO.classes.OrderPlace>(x));
                newList.FirstOrDefault(o => o.OrderDate > DateTime.Now);
            });
           
            newList = newList.FindAll(x => x.IdUser == id);
            return await dal.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            return false;

            throw ex;
        }
    }
    //    public async Task<bool> DeleteCustomerBLL(int id)
    //{
    //    var list = await GetCustomersAsyncBLL();
    //    CustomerDTO cust= list.FirstOrDefault(e=>e.CustId==id);
    //    if (cust == null)
    //    {
    //        return false;
    //    }
    //    //בדיקה שאין לו טיולים עתידיים 
    //    //שליפת כל ההזמנות של אותו לקוח  
    //    List<DTO.Classes.OrderTicketDTO> l = await GetAllTripsByCustomerBLL(cust.CustId);
    //    // מעבר על כל ההזמנות ובדיקה אם יש לו הזמנה לטיול שעוד לא התקים ואז א"א למחוק אותו 
    //   var o= l.FirstOrDefault(o=>o.TripDate>DateTime.Now);
    //    if (o != null)
    //        return false;
    //    bool f = await customerFunc.deleteAsync(cust.CustId);
    //    return f;
    //}
    //public async Task<bool> DeleteAsync(int id)
    //{
    //    var list = await GetAllAsync();
    //    DTO.classes.User cust = list.FirstOrDefault(e => e.IdUser == id);
    //    if (cust == null)
    //    {
    //        return false;
    //    }
    //    //בדיקה שאין לו טיולים עתידיים 
    //    //שליפת כל ההזמנות של אותו לקוח  
    //    List<DTO.classes.OrderPlace> l = await GetAllTripsAsync(cust.IdUser);
    //    // מעבר על כל ההזמנות ובדיקה אם יש לו הזמנה לטיול שעוד לא התקים ואז א"א למחוק אותו 
    //    var o = l.FirstOrDefault(o => o.Date > DateTime.Now);
    //    if (o != null)
    //        return false;
    //    bool f = await dal.DeleteAsync(cust.IdUser);
    //    return f;
    //}
    //public async Task<List<Tours>> GetAllTripsAsync(int id)
    // {
    //     try
    //     {
    //         List<Tours> list = new List<Tours>();
    //         // עובר על הטבלה של ההזמנות ומביא את כל אלו שקוד מזמין שווה לקוד שהוכנס
    //         foreach (var order in context.OrderPlaces)
    //         {
    //             if (order.IdUser == id)
    //             {
    //                 //var tours = mapper.Map<Tours>(await context.Tours.FirstOrDefaultAsync(f => f.Id == order.IdTour));
    //                 var tours = mapper.Map<Tours>(await tourBll.GetByIdAsync((int)order.IdTour));
    //    list.Add(tours);
    //             }
    //         }
    //         return list;
    //     }
    //     catch (Exception ex)
    //     {
    //    throw ex;
    //}

    // }
    //GetAllTripToUser

    public async Task<List<DTO.classes.TheTrip>> GetAllTripsAsync(short userId)
    {
        try
        {
            var a = await OrderPlaceDAL.GetAllAsync();
            List<DTO.classes.OrderPlace> bookings = mapper.Map<List<DTO.classes.OrderPlace>>(a);
            List<DTO.classes.TheTrip> trips = new List<DTO.classes.TheTrip>();

            foreach (DTO.classes.OrderPlace obj in bookings.Where(e => e.IdUser== userId))
            {
                //short s = (short) obj.TripId;
                var d = await TheTripDAL.GetByIdAsync((short)obj.IdTrip);
                trips.Add(mapper.Map<DTO.classes.TheTrip>(d));
            }
            return trips;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public async Task<List<DTO.classes.OrderPlace>> GetAllTripsAsync(int id)
    //{

    //    try
    //    {
    //        //רשימה של כל ההזמנות
    //        List<DAL.Models.OrderPlace> listOrderPlaces = await OrderPlaceDAL.GetAllAsync();
    //        List<DAL.Models.OrderPlace> list = new List<DAL.Models.OrderPlace>();
    //        //עובר על כל ההזמנות לחיפוש הזמנה שקוד הטיול שלה שווה לקוד הטיול שהוכנס
    //        foreach (var orderPlace in listOrderPlaces)
    //        {
    //            if (orderPlace.IdTrip == id)
    //            {
    //                list.Add(orderPlace);
    //            }
    //        }
    //        return mapper.Map<List<DTO.classes.OrderPlace>>(list);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //public async Task<List<DTO.classes.OrderPlace>> GetAllTripsAsync(int id)
    //{
    //    List<DAL.Models.OrderPlace> list1 = await ddaall.GetAllAsync();
    //    List<DTO.classes.OrderPlace> list = new List<DTO.classes.OrderPlace>();
    //    foreach (var i in list1)
    //    {
    //        if (i.IdUser == id)
    //            list.Add(i.IdUser);
    //    }
    //    if (list.Count > 0)
    //        return list;
    //    return null;
    //}
} 

   
  
