using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiServices.Repository
{
    class EntityMapperBlotterCurrentDT<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotterCurrentDT()
        {
            Mapper.CreateMap<Models.SP_SBPOpicsSystemDate_Result, DataAccessLayer.SP_SBPOpicsSystemDate_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPOpicsSystemDate_Result, Models.SP_SBPOpicsSystemDate_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
