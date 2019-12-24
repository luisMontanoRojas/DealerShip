using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerShip.Data.Repository;
using DealerShip.Exceptions;
using DealerShip.Model;

namespace DealerShip.Services
{
    public class CarModelService : ICarModelService
    {
        private IDealerShipRepository dealerShipRepository;
        public CarModelService(IDealerShipRepository dealerShipRepository)
        {
            this.dealerShipRepository = dealerShipRepository;
        }
        public CarModel AddCarModel(int brandId, CarModel newModel)
        {
            validateBrand(brandId);
            newModel.carBrandId = brandId;
            newModel.id = 0;
            return dealerShipRepository.AddCarModel(newModel);
        }

        public CarModel EditCarModel(int brandId, int id, CarModel editModel)
        {
            validateModelIdEdit(id, brandId, editModel);
            if (editModel.id == null) {
                editModel.id = id;
            }
            if (id != editModel.id) {
                throw new BadRequestOperationException("id URL should be euqual to body");
            }
            editModel.id = id;
            return dealerShipRepository.EditCarModel(editModel);
        }

        public CarModel GetCarModel(int brandId, int id)
        {
            CarModel model = validateModelId(id, brandId);
            return model;
        }

        public IEnumerable<CarModel> GetCarModels(int brandId)
        {
            validateBrand(brandId);
            return dealerShipRepository.GetCarModels().Where(m => m.carBrandId == brandId);
        }

        public bool RemoveCarModel(int brandId, int id)
        {
            var modelToDelete = dealerShipRepository.GetCarModel(id);
            if (modelToDelete == null) {
                throw new NotFoundItemException($"Model {id} does not exists");
            }
            return dealerShipRepository.RemoveCarModel(id);
        }
        private bool validateBrand(int id)
        {
            var brand = dealerShipRepository.GetCarBrand(id);
            if (brand == null)
            {
                throw new NotFoundItemException($"Brand not found with id {id}");
            }

            return true;
        }

        private CarModel validateModelId(int id,int brandId)
        {
            validateBrand(brandId);
            var model = dealerShipRepository.GetCarModel(id);
            if (model == null) {
                throw new NotFoundItemException($"cannot found model with id {id}");
            }
            return model;
        }

        private CarModel validateModelIdEdit(int id, int brandId, CarModel editModel)
        {
            if (brandId == editModel.carBrandId)
            {
                var model = validateModelId(id, brandId);
                return model;
            }
            return null;
        }
    }
}
