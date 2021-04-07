using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApiServices.Repository
{
    class EntityMapperBlotterDTLDB<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotterDTLDB()
        {
            Mapper.CreateMap<Models.SBP_BlotterDTLDaysWiseBal, DataAccessLayer.SBP_BlotterDTLDaysWiseBal>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterDTLDaysWiseBal, Models.SBP_BlotterDTLDaysWiseBal>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}

