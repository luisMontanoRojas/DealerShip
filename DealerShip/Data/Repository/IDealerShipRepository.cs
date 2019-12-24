using DealerShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data.Repository
{
    public interface IDealerShipRepository
    {
        //CarBrand
        IEnumerable<CarBrand> GetCarBrands();
        CarBrand GetCarBrand(int id, bool showModels = false);
        CarBrand CreateCarBrand(CarBrand newBrand);
        bool DeleteCarBrand(int id);
        CarBrand UpdateCarBrand(CarBrand editBrand);

        //CarModel
        IEnumerable<CarModel> GetCarModels();
        CarModel GetCarModel(int id);
        CarModel AddCarModel(CarModel newModel);
        CarModel EditCarModel(CarModel editModel);
        bool RemoveCarModel(int id);
    }
}
