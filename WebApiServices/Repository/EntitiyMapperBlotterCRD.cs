using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterCRD<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterCRD()
        {
            Mapper.CreateMap<Models.SBP_BlotterCRD, DataAccessLayer.SBP_BlotterCRD>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRD, Models.SBP_BlotterCRD>();

            Mapper.CreateMap<Models.SBP_BlotterCRD, DataAccessLayer.SP_GetSBPBlotterCRD_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SBP_BlotterCRD>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterCRD_Result, DataAccessLayer.SP_GetSBPBlotterCRD_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterCRD_Result, Models.SP_GetSBPBlotterCRD_Result>();
            
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}