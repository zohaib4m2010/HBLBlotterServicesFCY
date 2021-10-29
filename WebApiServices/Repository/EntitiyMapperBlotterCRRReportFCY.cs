using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterCRRReportFCY<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterCRRReportFCY()
        {
            Mapper.CreateMap<Models.SBP_BlotterCRRReportFCY, DataAccessLayer.SBP_BlotterCRRReportFCY>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRRReportFCY, Models.SBP_BlotterCRRReportFCY>();


            Mapper.CreateMap<Models.SP_GetSBPBlotterCRRReportFCY_Result, DataAccessLayer.SP_GetSBPBlotterCRRReportFCY_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterCRRReportFCY_Result, Models.SP_GetSBPBlotterCRRReportFCY_Result>();


            Mapper.CreateMap<Models.SBP_BlotterCRRReportingCurrencyWise, DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRRReportingCurrencyWise, Models.SBP_BlotterCRRReportingCurrencyWise>();


            Mapper.CreateMap<Models.SP_GetSBP_CRRReportingFCYCurrWise_Result, DataAccessLayer.SP_GetSBP_CRRReportingFCYCurrWise_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBP_CRRReportingFCYCurrWise_Result, Models.SP_GetSBP_CRRReportingFCYCurrWise_Result>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}