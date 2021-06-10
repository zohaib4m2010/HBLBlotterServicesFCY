using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperCurrencies<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperCurrencies()
        {

            Mapper.CreateMap<Models.SP_GetAllBlotterCurrencyById_Result, DataAccessLayer.SP_GetAllBlotterCurrencyById_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllBlotterCurrencyById_Result, Models.SP_GetAllBlotterCurrencyById_Result>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}