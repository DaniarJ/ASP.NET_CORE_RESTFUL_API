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
    [Route("api/cuisinecollections")]
    public class CuisineCollectionsController : Controller
    {
        private readonly IRestaurantRepository _RestaurantRepository;

        public CuisineCollectionsController(IRestaurantRepository RestaurantRepository)
        {
            _RestaurantRepository = RestaurantRepository;
        }

        [HttpPost]
        public IActionResult CreateCuisineCollecion([FromBody]ICollection<CuisineDto> cuisines) {
            if(cuisines == null)
            {
                return BadRequest();
            }

            foreach(var cuisine in cuisines)
            {
                var cuisineNew = new Cuisine
                {
                    Id = Guid.NewGuid(),
                    Name = cuisine.Name,
                    Type = cuisine.Type,
                    Dishs = new List<Dish>()
                };
                if (cuisine.Dishs.Any())
                {
                    foreach (var dish in cuisine.Dishs)
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

            }

                if (!_RestaurantRepository.Save())
                {
                    throw new Exception("Creating Cuisine Failed.");
                }
            return Ok();
        }


    }
}
