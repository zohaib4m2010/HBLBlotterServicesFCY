using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBranches<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBranches()
        {

            Mapper.CreateMap<Models.Branches, DataAccessLayer.Branches>();
            Mapper.CreateMap<DataAccessLayer.Branches, Models.Branches>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}