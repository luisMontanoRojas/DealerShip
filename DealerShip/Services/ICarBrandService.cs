using DealerShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Services
{
    public interface ICarBrandService
    {
        IEnumerable<CarBrand> GetCarBrands(string orderBy);
        CarBrand GetCarBrand(int id, bool showModels);
        Task<CarBrand> CreateCarBrandAsync(CarBrand newBrand);
        bool DeleteCarBrand(int id);
        CarBrand UpdateCarBrand(int id, CarBrand editBrand);
    }
}
