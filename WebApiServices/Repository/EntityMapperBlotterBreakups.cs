using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterBreakups<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterBreakups()
        {

            Mapper.CreateMap<Models.SBP_BlotterBreakups, DataAccessLayer.SBP_BlotterBreakups>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterBreakups, Models.SBP_BlotterBreakups>();



            Mapper.CreateMap<Models.SP_GetLatestBreakup_Result, DataAccessLayer.SP_GetLatestBreakup_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetLatestBreakup_Result, Models.SP_GetLatestBreakup_Result>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}