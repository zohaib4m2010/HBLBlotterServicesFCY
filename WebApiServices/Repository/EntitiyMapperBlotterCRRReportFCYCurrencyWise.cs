using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterCRRReportFCYCurrencyWise<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterCRRReportFCYCurrencyWise()
        {
            Mapper.CreateMap<Models.SBP_BlotterCRRReportingCurrencyWise, DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise, Models.SBP_BlotterCRRReportingCurrencyWise>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}