using Microsoft.AspNetCore.Mvc;
using RestaurantWebApi.Data;
using RestaurantWebApi.Models;
using RestaurantWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Controllers
{
    [Route("api/cuisines")]
    public class CuisinesController : Controller  
    {
        private readonly IRestaurantRepository _RestaurantRepository;

        public CuisinesController(IRestaurantRepository RestaurantRepository) {
            _RestaurantRepository = RestaurantRepository;
        }

        [HttpGet()]
        public IActionResult GetCuisines() {
                var cuisines = _RestaurantRepository.GetCuisines();
                return Ok(cuisines);
        }

        [HttpGet("{id}" , Name = "GetCuisine")]
        public IActionResult GetCuisine(Guid id) {
            var cuisine = _RestaurantRepository.GetCuisine(id);

            if ( cuisine == null) {
                return NotFound();
            }

            return Ok(cuisine);
        }

        [HttpPost()]
        public IActionResult CreateCuisine([FromBody]CuisineDto cuisine) {

            if (cuisine == null) {
                return BadRequest();
            }

            var cuisineNew = new Cuisine{
                     Id = Guid.NewGuid(),
                     Name = cuisine.Name,
                     Type = cuisine.Type,
                     Dishs = new List<Dish>()
            };
            if (cuisine.Dishs.Any()) {
                foreach( var dish in cuisine.Dishs)
                {
                    cuisineNew.Dishs.Add(
                            new Dish
                            {   
                                Id = Guid.NewGuid(),
                                Name = dish.Name,
                                Description = dish.Description,
                                CuisineId = cuisineNew.Id
                            }
                       );
                }
            }

            _RestaurantRepository.AddCuisine(cuisineNew);

            if(!_RestaurantRepository.Save())
            {
                throw new Exception("Creating Cuisine Failed.");
            }
            cuisineNew.Dishs = new List<Dish>();
            return CreatedAtRoute("GetCuisine", new { id = cuisineNew.Id } , cuisineNew);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCuisine(Guid id) {
            var cuisine = _RestaurantRepository.GetCuisine(id);

            if(cuisine == null)
            {
                return NotFound();
            }

            _RestaurantRepository.DeleteCuisine(cuisine);

            if(!_RestaurantRepository.Save())
            {
                throw new Exception("Unable to Delete this Cuisine.");
            }
            return NoContent();
        }


    }
}
