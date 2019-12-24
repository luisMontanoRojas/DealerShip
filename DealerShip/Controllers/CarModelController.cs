using DealerShip.Exceptions;
using DealerShip.Model;
using DealerShip.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Controllers
{
    [Route("api/carbrand/{carBrandId:int}/carModel")]
    public class CarModelController : ControllerBase
    {
        private ICarModelService carModelService;
        public CarModelController(ICarModelService carModelService)
        {
            this.carModelService = carModelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarModel>> getCarModels(int carBrandId)
        {
            try
            {
                var models = carModelService.GetCarModels(carBrandId);
                return Ok(models);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{idModel}")]
        public ActionResult<CarModel> GetCarModel(int carBrandId, int idModel)
        {
            try
            {
                var model = carModelService.GetCarModel(carBrandId, idModel);
                return Ok(model);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CarModel> PostCarModel(int carBrandId, [FromBody] CarModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createCarModel = carModelService.AddCarModel(carBrandId, carModel);
            return Created($"api/carbrand/{carBrandId:int}/carModel/{createCarModel.id}", createCarModel);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CarModel> DeleteCarModel(int carBrandId, int id) {
            try {
                var result = carModelService.RemoveCarModel(carBrandId, id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete Model");
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<CarModel> PutCarModel(int carBrandId, int id, [FromBody] CarModel carModel) {
           try
            {
                return Ok(carModelService.EditCarModel(carBrandId, id, carModel));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
