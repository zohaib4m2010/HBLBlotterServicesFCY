using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterConversionRate<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterConversionRate()
        {
            Mapper.CreateMap<Models.SP_Get_SBPBlotterConversionRate_Result, DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_Get_SBPBlotterConversionRate_Result, Models.SP_Get_SBPBlotterConversionRate_Result>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}