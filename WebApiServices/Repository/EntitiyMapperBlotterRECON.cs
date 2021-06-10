using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterRECON<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterRECON()
        {
            Mapper.CreateMap<Models.SBP_BlotterRECON, DataAccessLayer.SBP_BlotterRECON>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterRECON, Models.SBP_BlotterRECON>();

            Mapper.CreateMap<Models.SBP_BlotterRECON, DataAccessLayer.SP_GetSBPBlotterRECON_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SBP_BlotterRECON>();

            Mapper.CreateMap<Models.SP_GetSBPBlotterRECON_Result, DataAccessLayer.SP_GetSBPBlotterRECON_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBPBlotterRECON_Result, Models.SP_GetSBPBlotterRECON_Result>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}