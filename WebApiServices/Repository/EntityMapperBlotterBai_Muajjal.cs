using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Repository
{
    public class EntityMapperBlotterBai_Muajjal<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterBai_Muajjal()
        {
            Mapper.CreateMap<Models.SBP_BlotterBai_Muajjal, DataAccessLayer.SBP_BlotterBai_Muajjal>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterBai_Muajjal, Models.SBP_BlotterBai_Muajjal>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}