using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
    class EntityMapperBlotter<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotter()
        {
            Mapper.CreateMap<Models.SP_SBPBlotter_Result, DataAccessLayer.SP_SBPBlotter_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPBlotter_Result, Models.SP_SBPBlotter_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
