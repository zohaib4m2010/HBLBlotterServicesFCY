using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
 
    class EntityMapperBlotterLogin<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapperBlotterLogin()
        {
            Mapper.CreateMap<Models.SP_SBPGetLoginInfo_Result, DataAccessLayer.SP_SBPGetLoginInfo_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPGetLoginInfo_Result, Models.SP_SBPGetLoginInfo_Result>();

            Mapper.CreateMap<Models.SP_SBPGetLoginInfo_Result, DataAccessLayer.SP_SBPGetLoginInfoById_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_SBPGetLoginInfoById_Result, Models.SP_SBPGetLoginInfo_Result>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
