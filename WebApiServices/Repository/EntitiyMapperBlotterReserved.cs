﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebApiServices.Repository
{
    public class EntitiyMapperBlotterReserved<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntitiyMapperBlotterReserved()
        {

            Mapper.CreateMap<Models.SP_GetSBP_Reserved_Result, DataAccessLayer.SP_GetSBP_Reserved_Result>();
            Mapper.CreateMap<DataAccessLayer.SP_GetSBP_Reserved_Result, Models.SP_GetSBP_Reserved_Result>();

            Mapper.CreateMap<Models.BlotterSBP_Reserved, DataAccessLayer.BlotterSBP_Reserved>();
            Mapper.CreateMap<DataAccessLayer.BlotterSBP_Reserved, Models.BlotterSBP_Reserved>();

        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}