﻿using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiServices.Repository
{
    class EntityMapperBlotterManual<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapperBlotterManual()
        {
           
            Mapper.CreateMap<Models.SBP_BlotterManualDeals, DataAccessLayer.SBP_BlotterManualDeals>();
            Mapper.CreateMap<DataAccessLayer.SBP_BlotterManualDeals, Models.SBP_BlotterManualDeals>();

           
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}


