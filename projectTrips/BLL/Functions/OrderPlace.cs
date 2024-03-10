using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.classes;
//using DAL.Models;
using DTO.mapper;
using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BLL.Functions
{
    public class OrderPlaceBLL : IOrderPlaceBLL
    {
        IOrderPlaceDAL OrderPlacedal;
        ITheTripDAL Tripdal;
        IUserDAL Userdal;
        IMapper mapper;

        public OrderPlaceBLL(IOrderPlaceDAL OrderPlacedal, ITheTripDAL Tripdal, IUserDAL Userdal)
        {
            this.OrderPlacedal = OrderPlacedal;
            this.Tripdal = Tripdal;
            this.Userdal = Userdal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.mapper.Mapper>();
            });

            mapper = config.CreateMapper();
        }
        public async Task<List<DTO.classes.OrderPlace>> GetAllAsync()
        {

            return mapper.Map<List<DAL.Models.OrderPlace>, List<DTO.classes.OrderPlace>>(await OrderPlacedal.GetAllAsync());
        }
        public async Task<List<DTO.classes.OrderPlace>> GetAllTripsAsync(int id)
        {
            try
            {
                //רשימה של כל ההזמנות
                List<DAL.Models.OrderPlace> listOrderPlaces = await OrderPlacedal.GetAllAsync();
                List<DAL.Models.OrderPlace> list = new List<DAL.Models.OrderPlace>();
                //עובר על כל ההזמנות לחיפוש הזמנה שקוד הטיול שלה שווה לקוד הטיול שהוכנס
                foreach (var orderPlace in listOrderPlaces)
                {
                    if (orderPlace.IdTrip == id)
                    {
                        list.Add(orderPlace);
                    }
                }
                return mapper.Map<List<DTO.classes.OrderPlace>>(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<int> AddAsync(OrderPlaces orderPlaces)
        //{
        //    try
        //    {
        //        //חיפוש הטיול בטבלת טיולים
        //        var tour1 = await tour.GetByIdAsync((int)orderPlaces.IdTour); //await context.Tours.FirstOrDefaultAsync(t => t.Id == orderPlaces.IdTour);
        //        //בדיקה תקינות - תאריך הטיול עוד לא עבר ויש מקומות פנויים בטיול
        //        if (orderPlaces.DateTour > DateTime.Today && tour1.PlacesAvilible - orderPlaces.CountPlaces >= 0)
        //        {
        //            orderPlaces.Date = DateTime.Now;//תאריך הזמנה
        //            DateTime t = DateTime.Now;//שעת הזמנה
        //            orderPlaces.ExiteTime = new TimeSpan(t.Hour, t.Minute, t.Second);
        //            //עדכון מספר המקומות הפנויים
        //            tour1.PlacesAvilible -= orderPlaces.CountPlaces;
        //            var answer = mapper.Map<OrderPlace>(orderPlaces);
        //            return await orderPlaceRepository.AddAsync(answer);
        //        }
        //        return -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public async Task<int> AddOrder(OrderTicketDTO orderTicketDTO)
        //{
        //    //שליפת כל הטיולים
        //    var trips = await tripsBLL.getAllAsync();
        //    //שליפת הטיול שרוצים להזמין לו מקום
        //    var thisTrip = trips.FirstOrDefault(t => t.TripId == orderTicketDTO.TripId);
        //    if (
        //       //בדיקה שתאריך הטיול לא עבר עדיין
        //       thisTrip.Date > DateTime.Now
        //        //בדיקה שיש מספיק מקומות להזמין 
        //        && thisTrip.EmptyPlaces > orderTicketDTO.CountPlaces
        //        )
        //    {
        //        DateTime t = DateTime.Now;
        //        orderTicketDTO.OrdDate = t;
        //        orderTicketDTO.OrdTime = new TimeSpan(t.Hour, t.Minute, t.Second);
        //        int i = await orderTicketBLL.addAsync(mapper.Map<DTO.Classes.OrderTicketDTO, DAL.Models.OrderTicket>(orderTicketDTO));
        //        //עדכון המקומות הפנוים בטיול 
        //        thisTrip.EmptyPlaces = thisTrip.EmptyPlaces - orderTicketDTO.CountPlaces;
        //        await tripsBLL.updateAsync(thisTrip);
        //        return i;
        //    }
        //    return -1;

        //}
        public async Task<int> AddAsync(DTO.classes.OrderPlace orderPlace)
        {
            try
            {
               var Tripe = await Tripdal.GetAllAsync();
               var thisTrip= Tripe.FirstOrDefault(t => t.IdTrip == orderPlace.IdTrip);
                if (thisTrip.Date > DateTime.Now && thisTrip.NumberPlacesAvailable > orderPlace.NumberPlaces)
                {
                    DateTime t = DateTime.Now;
                    orderPlace.Date = t;
                    orderPlace.OrderTime = new TimeSpan(t.Hour, t.Minute, t.Second);
                    int i = await OrderPlacedal.AddAsync(mapper.Map<DTO.classes.OrderPlace, DAL.Models.OrderPlace>(orderPlace));
                    //עדכון המקומות הפנוים בטיול 
                    thisTrip.NumberPlacesAvailable = (short?)(thisTrip.NumberPlacesAvailable - orderPlace.NumberPlaces);
                    await Tripdal.UpdateAsync(thisTrip);
                    return i;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //מחיקת הזמנה
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        //מציאת ההזמנה
        //        var o = await orderPlaceRepository.GetByIdAsync(id); //await context.OrderPlaces.FirstOrDefaultAsync(t => t.Id == id);
        //        //מציאת הטיול
        //        var t = await tour.GetByIdAsync((int)o.IdTour); //await context.Tours.FirstOrDefaultAsync(t => t.Id == o.IdTour);
        //        //אם תאריך הטיול לא עבר
        //        if (t.Date < DateTime.Today)
        //        {
        //            t.PlacesAvilible += o.CountPlaces;
        //            return await orderPlaceRepository.DeleteAsync(id);
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var orderPlace = await OrderPlacedal.GetByIdAsync(id);
                var trip = await Tripdal.GetByIdAsync((int)orderPlace.IdTrip);
                //if (trip.Date < DateTime.Today)
                // {
                trip.NumberPlacesAvailable = (short?)(trip.NumberPlacesAvailable + orderPlace.NumberPlaces);
                await Tripdal.UpdateAsync(trip);
                return  await OrderPlacedal.DeleteAsync(id);
                //}
               // return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }   
    }
}


