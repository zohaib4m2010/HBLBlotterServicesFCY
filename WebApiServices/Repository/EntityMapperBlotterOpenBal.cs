using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterOpenBal<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterOpenBal()
        {
            Mapper.CreateMap<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SBP_BlotterOpeningBalance>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterOpeningBalance, Models.SBP_BlotterOpeningBalance>();

            Mapper.CreateMap<Models.SBP_BlotterOpeningBalance, DataAccessLayer.SP_GetAllOpeningBalance_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetAllOpeningBalance_Result, Models.SBP_BlotterOpeningBalance>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}