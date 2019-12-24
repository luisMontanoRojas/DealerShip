using DealerShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Services
{
    public interface ICarModelService
    {
        IEnumerable<CarModel> GetCarModels(int brandId);
        CarModel GetCarModel(int brandId, int id);
        CarModel AddCarModel(int brandId, CarModel newModel);
        CarModel EditCarModel(int brandId, int id, CarModel editModel);
        bool RemoveCarModel(int brandId, int id);
    }
}
