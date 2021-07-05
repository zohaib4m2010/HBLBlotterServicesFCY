using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterFundsTransfer<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterFundsTransfer()
        {
            Mapper.CreateMap<Models.SBP_BlotterFundsTransfer, DataAccessLayer.SBP_BlotterFundsTransfer>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterFundsTransfer, Models.SBP_BlotterFundsTransfer>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}