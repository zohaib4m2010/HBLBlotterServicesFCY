using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
    class EntityMapperBlotterEmail<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterEmail()
        {

            Mapper.CreateMap<Models.BlotterSumEmail , DataAccessLayer.BlotterSumEmail>();
            Mapper.CreateMap<DataAccessLayer.BlotterSumEmail, Models.BlotterSumEmail>();


        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
