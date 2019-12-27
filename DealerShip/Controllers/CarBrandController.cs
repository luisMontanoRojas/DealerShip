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
    [Route("api/[controller]")]
    public class CarBrandController : ControllerBase
    {
        private ICarBrandService carBrandService;
        public CarBrandController(ICarBrandService carBrandService)
        {
            this.carBrandService = carBrandService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarBrand>> GetCarBrands(string orderBy = "id")
        {
            try
            {
                return Ok(carBrandService.GetCarBrands(orderBy));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CarBrand> GetCarBrand(int id, bool showModels = false)
        {
            try
            {
                return Ok(carBrandService.GetCarBrand(id, showModels));
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
        public async Task<ActionResult<CarBrand>> PostCarBrand([FromBody] CarBrand carBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCarBrand =await  carBrandService.CreateCarBrandAsync(carBrand);
            return Created($"/api/carbrand/{createdCarBrand.id}", createdCarBrand);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteCarBrand(int id)
        {
            try
            {
                var result = carBrandService.DeleteCarBrand(id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete brand");
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
        public ActionResult<CarBrand> PutCarBrand(int id, [FromBody]CarBrand carBrand)
        {
            if (!ModelState.IsValid)
            {
                var natinallity = ModelState[nameof(carBrand.nationality)];

                if (natinallity != null && natinallity.Errors.Any())
                {
                    return BadRequest(natinallity.Errors);
                }
            }

            try
            {
                return Ok(carBrandService.UpdateCarBrand(id, carBrand));

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
