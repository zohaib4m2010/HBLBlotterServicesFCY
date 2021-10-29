using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterImportExport<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterImportExport()
        {
            Mapper.CreateMap<Models.SBP_BlotterImportExport, DataAccessLayer.SBP_BlotterImportExport>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterImportExport, Models.SBP_BlotterImportExport>();

            Mapper.CreateMap<Models.SP_GetSBP_BlotterImportExport_Result, DataAccessLayer.SP_GetSBP_BlotterImportExport_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBP_BlotterImportExport_Result, Models.SP_GetSBP_BlotterImportExport_Result>();            
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}