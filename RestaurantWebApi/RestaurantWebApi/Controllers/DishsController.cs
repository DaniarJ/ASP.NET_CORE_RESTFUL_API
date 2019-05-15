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
    [Route("api/cuisines/{cuisineId}/dishs")]
    public class DishsController : Controller
    {
        private IRestaurantRepository _RestaurantRepository;

        public DishsController(IRestaurantRepository RestaurantRepository) {
            _RestaurantRepository = RestaurantRepository;
        }

        [HttpGet()]
        public IActionResult GetDishsForCuisine(Guid cuisineId) {

            if (!_RestaurantRepository.CuisineExists(cuisineId)) {
                return NotFound();
            }

            var dishs = _RestaurantRepository.GetDishsForCuisine(cuisineId);
            return Ok(dishs);
        }

        [HttpGet("{id}", Name = "GetDishForCuisine")]
        public IActionResult GetDishForCuisine(Guid cuisineId, Guid id) {
            if ( ! _RestaurantRepository.CuisineExists(cuisineId)) {
                return NotFound();
            }

            var dish = _RestaurantRepository.GetDishForCuisine(cuisineId, id);
            if (dish == null) {
                return NotFound();
            }
            return Ok(dish);
        }
        [HttpPost]
        public IActionResult CreateDishForCuisine(Guid cuisineId,[FromBody]DishDto dish)
        {
            if( dish == null)
            {
                return BadRequest();
            }

            if(!_RestaurantRepository.CuisineExists(cuisineId)){
                return NotFound();
            }

            var dishNew = new Dish
            {
                Id = Guid.NewGuid(),
                Name = dish.Name,
                Description = dish.Description,
                CuisineId = cuisineId
            };

            _RestaurantRepository.AddDishForCuisine(cuisineId, dishNew);
            if (!_RestaurantRepository.Save()) {
                throw new Exception($"Creating a new Dish for Cuisine {cuisineId} failed.");
            }

            return CreatedAtRoute("GetDishForCuisine", new{ cuisineId = cuisineId , id = dishNew.Id } , dishNew );
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDishForCuisine(Guid cuisineId,Guid id)
        {
            if(!_RestaurantRepository.CuisineExists(cuisineId))
            {
                return NotFound();
            }

            var dish = _RestaurantRepository.GetDishForCuisine(cuisineId, id);
            if( dish == null)
            {
                return NotFound();
            }

            _RestaurantRepository.DeleteDish(dish);
            if (!_RestaurantRepository.Save()) {
                throw new Exception("Error Deleting Dish.");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDishForCuisine(Guid cuisineId, Guid id, [FromBody]DishDto dish)
        {
            if (dish == null)
            {
                return BadRequest();
            }
            if (!_RestaurantRepository.CuisineExists(cuisineId))
            {
                return NotFound();
            }
            var _dish = _RestaurantRepository.GetDishForCuisine(cuisineId, id);
            if ( _dish == null)
            {
                return NotFound();
            }
            if (dish.Name != null)
            {
                _dish.Name = dish.Name;
            }
            if (dish.Description != null)
            {
                _dish.Description = dish.Description;
            }
            if (!_RestaurantRepository.Save())
            {
                throw new Exception("Unable to update this dish.");
            }
            return NoContent();
        }
    }
}
