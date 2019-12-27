using AutoMapper;
using DealerShip.Data.Entities;
using DealerShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data
{
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            this.CreateMap<CarBrandEntity, CarBrand>()
                .ReverseMap();

            this.CreateMap<CarModelEntity, CarModel>()
                .ReverseMap();
        }
    }
}
