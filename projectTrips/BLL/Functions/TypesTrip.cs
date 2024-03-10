using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.mapper;
using Microsoft.Extensions.Logging;

namespace BLL.Functions;
public class TypesTripBLL : ITypesTripBLL
{
    ITypesTripDAL dal;
    IMapper mapper;
    public TypesTripBLL(ITypesTripDAL dal)
    {
        this.dal = dal;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DTO.mapper.Mapper>();
        });

        mapper = config.CreateMapper();
    }
    public async Task<List<DTO.classes.TypesTrip>> GetAllAsync()
    {

        return mapper.Map<List<DAL.Models.TypesTrip>, List<DTO.classes.TypesTrip>>(await dal.GetAllAsync());
    }
    public async Task<int> AddAsync(DTO.classes.TypesTrip trip)
    {
        List<DTO.classes.TypesTrip> allTripType = await GetAllAsync();
        DTO.classes.TypesTrip t = allTripType.Find(x => x.NameType.Equals(trip.NameType));
        if (t == null)
        {
            try
            {
                var mapType = mapper.Map<DAL.Models.TypesTrip>(trip);
                return await dal.AddAsync(mapType);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        else
        return -1;
    }
       
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
             await dal.DeleteAsync(id);
            return true;

        }
        catch 
        { 
            return false;
        }
    }
    public async Task<List<DTO.classes.TheTrip>> GetTripByIdTypeBLLAsync(int id)
    {
        try
        {
            var type = await dal.GetTripByIdTypeDLLAsync(id);
            return mapper.Map<List<DTO.classes.TheTrip>>(type);
        }
        catch (Exception ex)
        {
            //logger.LogError("faild" + ex.Message);
            throw ex;
        }
    }
}
