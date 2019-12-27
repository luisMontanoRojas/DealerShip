using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealerShip.Data.Entities;
using DealerShip.Data.Repository;
using DealerShip.Exceptions;
using DealerShip.Model;

namespace DealerShip.Services
{
    public class CarBrandService : ICarBrandService
    {
        private HashSet<string> allowedOrderByValues;
        private IDealerShipRepository dealerShipRepository;
        private readonly IMapper mapper;
        public CarBrandService(IDealerShipRepository dealerShipRepository, IMapper mapper)
        {
            this.dealerShipRepository = dealerShipRepository;
            this.mapper = mapper;
            allowedOrderByValues = new HashSet<string>() { "id", "name", "nationality", "phono", "facebook", "ubication", "about", "oficialPage" };
        }
        public async Task<CarBrand> CreateCarBrandAsync(CarBrand newBrand)
        {
            var carBrandEntity = mapper.Map<CarBrandEntity>(newBrand);
            dealerShipRepository.CreateCarBrand(carBrandEntity);
            if(await dealerShipRepository.SaveChangesAsync())
            {
                return mapper.Map<CarBrand>(carBrandEntity);
            }
            throw new Exception("There was an error ");
        }

        public bool DeleteCarBrand(int id)
        {
            var brandToDelete = dealerShipRepository.GetCarBrand(id);
            if (brandToDelete == null)
            {
                throw new NotFoundItemException($"brand {id} does not exists");
            }
            return dealerShipRepository.DeleteCarBrand(id);
        }

        public CarBrand GetCarBrand(int id, bool showModels)
        {
            validatCarBrandId(id);
            var brand = dealerShipRepository.GetCarBrand(id, showModels);
            return brand;
        }

        public IEnumerable<CarBrand> GetCarBrands(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }
            var brands = dealerShipRepository.GetCarBrands();
            return brands;
        }

        public CarBrand UpdateCarBrand(int id, CarBrand editBrand)
        {
            validatCarBrandId(id);

            if (editBrand.id == null)
            {
                editBrand.id = id;
            }
            if (id != editBrand.id)
            {
                throw new BadRequestOperationException("id URL should be euqual to body");
            }
            editBrand.id = id;
            return dealerShipRepository.UpdateCarBrand(editBrand);
        }

        private CarBrand validatCarBrandId(int id, bool showModels = false)
        {
            var brand = dealerShipRepository.GetCarBrand(id);
            if (brand == null)
            {
                throw new NotFoundItemException($"cannot found Brand with id {id}");
            }

            return brand;
        }
    }
}
