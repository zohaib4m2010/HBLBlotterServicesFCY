using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiServices.Repository
{
    class EntityMapperBlotterCashFlowSum<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterCashFlowSum()
        {
            Mapper.CreateMap<Models.SP_SBPBlotterRunningBal, DataAccessLayer.SP_SBPBlotterRunningBal>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPBlotterRunningBal, Models.SP_SBPBlotterRunningBal>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
