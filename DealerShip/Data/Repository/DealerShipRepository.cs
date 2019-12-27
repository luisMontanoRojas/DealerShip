using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerShip.Data.Entities;
using DealerShip.Model;

namespace DealerShip.Data.Repository
{
    public class DealerShipRepository : IDealerShipRepository
    {
        private List<CarBrand> carBrands;
        private List<CarModel> carModels;
        private DealerDBContext dealerDBContext;
        public DealerShipRepository(DealerDBContext dealerDBContext)
        {
            this.dealerDBContext = dealerDBContext;
            carBrands = new List<CarBrand>() {
                new CarBrand()
                {
                    id=1,
                    name="Mazda",
                    nationality="Japon",
                    facebook="https://es-la.facebook.com/MazdaBol/",
                    ubication="Huanchaca, Cochabamba",
                    about="Mazda Motor Corporation es un fabricante de automóviles japonés, fundada en 1920, con sede principal en Hiroshima, y con plantas en las localidades de Hiroshima, Nishinoura, Nakanoseki y Miyoshi, Japón. En 2010, produjo 1 307 540 automóviles con ventas en China, Japón, Europa, América del Sur y Norteamérica.",
                    oficialPage="https://www.mazda.bo/"
                }
            };
            carModels = new List<CarModel>() {
                new CarModel()
                {
                    id=1,
                    name="CX5",
                    urlImage="https://imcruz-bolivia-qa.s3.amazonaws.com/uploads/sites/cx-30/cx-30.png",
                    year=2020,
                    displacement=2000,
                    horsePower=110,
                    weight= 1455,
                    transmission="manual",
                    basicPrice=28000,
                    carBrandId=1
                }
            };
        }
        public CarModel AddCarModel(CarModel newModel)
        {
            var lastModel = carModels.OrderByDescending(m => m.id).FirstOrDefault();
            var nextID = lastModel == null ? 1 : lastModel.id + 1;
            newModel.id = nextID;
            carModels.Add(newModel);
            return newModel;
        }

        public void  CreateCarBrand(CarBrandEntity newBrand)
        {
            dealerDBContext.CarBrands.Add(newBrand);
           
           
           
        }

        public bool DeleteCarBrand(int id)
        {
            var brandToDelete = carBrands.Single(a => a.id == id);
            return carBrands.Remove(brandToDelete);
        }

        public CarModel EditCarModel(CarModel editModel)
        {
            var modelToEdit = carModels.Single(a => a.id == editModel.id);
            if (editModel.basicPrice != 0)
            {
                modelToEdit.basicPrice = editModel.basicPrice;
            }
            if (editModel.carBrandId != null)
            {
                modelToEdit.carBrandId = editModel.carBrandId;
            }
            if (editModel.displacement != 0)
            {
                modelToEdit.displacement = editModel.displacement;
            }
            if (editModel.horsePower != 0)
            {
                modelToEdit.horsePower = editModel.horsePower;
            }
            if (editModel.name != null)
            {
                modelToEdit.name = editModel.name;
            }
            if (editModel.transmission != null)
            {
                modelToEdit.transmission = editModel.transmission;
            }
            if (editModel.urlImage != null)
            {
                modelToEdit.urlImage = editModel.urlImage;
            }
            if (editModel.weight != 0)
            {
                modelToEdit.weight = editModel.weight;
            }
            if (editModel.year != 0)
            {
                modelToEdit.year = editModel.year;
            }
            return modelToEdit;
        }

        public CarBrand GetCarBrand(int id, bool showModels)
        {
            var brand = carBrands.SingleOrDefault(a => a.id == id);
            if (showModels)
            {
                brand.carModels = carModels.Where(b => b.carBrandId == id);
            }
            return brand;
        }

        public IEnumerable<CarBrand> GetCarBrands()
        {
            return carBrands;
        }

        public CarModel GetCarModel(int id)
        {
            return carModels.SingleOrDefault(a => a.id == id);
        }

        public IEnumerable<CarModel> GetCarModels()
        {
            return carModels;
        }

        public bool RemoveCarModel(int id)
        {
            var modelToDelete = carModels.Single(b => b.id == id);
            return carModels.Remove(modelToDelete);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await dealerDBContext.SaveChangesAsync()) > 0;
        }

        public CarBrand UpdateCarBrand(CarBrand editBrand)
        {
            var brandToUpdate = carBrands.Single(b => b.id == editBrand.id);
            if (editBrand.about != null)
            {
                brandToUpdate.about = editBrand.about;
            }
            if (editBrand.url_logo_image != null)
            {
                brandToUpdate.about = editBrand.url_logo_image;
            }
            if (editBrand.facebook != null)
            {
                brandToUpdate.facebook = editBrand.facebook;
            }
            if (editBrand.name != null)
            {
                brandToUpdate.name = editBrand.name;
            }
            if (editBrand.nationality != null)
            {
                brandToUpdate.nationality = editBrand.nationality;
            }
            if (editBrand.oficialPage != null)
            {
                brandToUpdate.oficialPage = editBrand.oficialPage;
            }
            if (editBrand.ubication != null)
            {
                brandToUpdate.ubication = editBrand.ubication;
            }
            return brandToUpdate;
        }
    }
}
