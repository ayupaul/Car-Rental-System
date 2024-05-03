using AutoMapper;
using Buisness_Layer.Model;
using Data_Access_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.AutoMapper
{
    public class MappingConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarEntity, CarModel>();
                cfg.CreateMap<CarModel, CarEntity>();

                cfg.CreateMap<CarRentalAgreementEntity, CarRentalAgreementModel>();

                cfg.CreateMap<CarRentalAgreementModel, CarRentalAgreementEntity>();


            });

            return config.CreateMapper();
        }
    }
}
