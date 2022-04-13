using AutoMapper;
using IOTKeyAndValues.Models.DB;
using IOTKeyAndValues.Models.Requests;
using IOTKeyAndValues.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.AutoMappers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<KeyValue, KeyValueResponse>().ReverseMap();
            CreateMap<KeyValue, KeyValueRequest>().ReverseMap();
        }
    }
}
