using AutoMapper;
using AutoMapper.Internal.Mappers;
using BLL.Interfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using DTO.classes;
//using DAL.Models;
using DTO.mapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;

namespace BLL.Functions;
public class TheTripBLL : ITheTripBLL
{
    ITheTripDAL dal;
    IOrderPlaceDAL OrderPlaceDAL;
    IMapper mapper;
    public TheTripBLL(ITheTripDAL dal, IOrderPlaceDAL OrderPlaceDAL)
    {
        this.dal = dal;
        this.OrderPlaceDAL = OrderPlaceDAL;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DTO.mapper.Mapper>();
        });

        mapper = config.CreateMapper();
    }
    public async Task<List<DTO.classes.TheTrip>> GetAllAsync()
    {

        return mapper.Map<List<DAL.Models.TheTrip>, List<DTO.classes.TheTrip>>(await dal.GetAllAsync());
    }
    public async Task<DTO.classes.TheTrip> GetByIdAsync(int id)
    {
        DAL.Models.TheTrip t = await dal.GetByIdAsync(id);
        if (t != null)
        {
            return mapper.Map<DAL.Models.TheTrip, DTO.classes.TheTrip>(t);
        }
        return null;
    }

    public async Task<bool> UpdateAsync(DTO.classes.TheTrip trip)
    {
        DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);
        if (trip.Date >= threeMonthsAgo && trip.DurationTripInHours >= 3 && trip.DurationTripInHours <= 12 && trip.NumberPlacesAvailable > 0 && trip.Price <= 3500 && trip.Price > 0 && trip.Date<=trip.Date)
       
            //try
            //{
                //var mapTrip = mapper.Map<DAL.Models.TheTrip>(trip);
                //var answer = await dal.UpdateAsync(mapTrip);
                // mapper.Map<DTO.classes.TheTrip>(answer);
                //return true;    
                return await dal.UpdateAsync(mapper.Map<DAL.Models.TheTrip>(trip));
               // return false;
            //}

            //catch (Exception ex)
            //{
            //throw ex;
            //}
        return
            false;
    }
    public async Task<int> AddAsync(DTO.classes.TheTrip trip)
    {
        DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);
        if (trip.Date <= threeMonthsAgo && trip.DurationTripInHours >= 3 && trip.DurationTripInHours <= 12 && trip.NumberPlacesAvailable > 0 && trip.Price <= 3500 && trip.Price > 0)
        { 
        try
        {
            var mapTrip = mapper.Map<DAL.Models.TheTrip>(trip);
            var answer = await dal.AddAsync(mapTrip);
            return mapper.Map<DTO.classes.TheTrip>(answer).IdTrip;
        }
        catch (Exception ex)
        {
            throw ex;
            }
        }
        else
            return -1;
}
    //List<DAL.Models.OrderPlace> listOrderPlaces = await OrderPlacedal.GetAllAsync();
    //List<DAL.Models.OrderPlace> list = new List<DAL.Models.OrderPlace>();
    //            //עובר על כל ההזמנות לחיפוש הזמנה שקוד הטיול שלה שווה לקוד הטיול שהוכנס
    //            foreach (var orderPlace in listOrderPlaces)
    //            {
    //                if (orderPlace.IdTrip == id)
    //                {
    //                    list.Add(orderPlace);
    //                }
    //            }
    //            return mapper.Map<List<DTO.classes.OrderPlace>>(list);
    public async Task<List<DTO.classes.OrderPlace>> GetInvitesToTripAsync(int id)
    {
        try
        {
            var list = await OrderPlaceDAL.GetAllAsync();
            list = list.FindAll(x => x.IdTrip.Equals(id));


            // List<DAL.Models.OrderPlace> g = await OrderPlaceDAL.GetAllAsync();
            // List<DAL.Models.OrderPlace> g1 = new List<DAL.Models.OrderPlace>();
            // foreach (var orderPlace in g)
            // {
            //     if (orderPlace.IdTrip == id)
            //         g1.Add(orderPlace);
            // }
            //// g1 = g1.FindAll(x => x.IdUser.Equals(id));

             return mapper.Map<List<DTO.classes.OrderPlace>>(list);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}