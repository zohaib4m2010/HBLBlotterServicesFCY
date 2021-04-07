using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterCRRFINCON<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterCRRFINCON()
        {

            Mapper.CreateMap<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SBP_BlotterCRRFINCON>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterCRRFINCON, Models.SBP_BlotterCRRFINCON>();

            Mapper.CreateMap<Models.SBP_BlotterCRRFINCON, DataAccessLayer.SP_GetSBPBlotterCRRFINCON_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterCRRFINCON_Result, Models.SBP_BlotterCRRFINCON>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}