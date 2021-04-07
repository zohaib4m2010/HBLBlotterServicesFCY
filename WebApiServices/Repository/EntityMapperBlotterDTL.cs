using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
    class EntityMapperBlotterDTL<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotterDTL()
        {
            Mapper.CreateMap<Models.SBP_BlotterDTL, DataAccessLayer.SBP_BlotterDTL>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterDTL, Models.SBP_BlotterDTL>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}


