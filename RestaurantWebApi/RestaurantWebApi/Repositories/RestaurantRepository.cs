using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantWebApi.Models;

namespace RestaurantWebApi.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
            private RestaurantContext _context;

            public RestaurantRepository(RestaurantContext context)
            {
                _context = context;
            }

            public void AddCuisine(Cuisine cuisine)
            {
                _context.Cuisines.Add(cuisine);
            }

            public void AddDishForCuisine(Guid cuisineId, Dish dish)
            {
                    _context.Dishs.Add(dish);
            }

            public bool CuisineExists(Guid cuisineId)
            {
                return _context.Cuisines.Any(a => a.Id == cuisineId);
            }

            public void DeleteCuisine(Cuisine cuisine)
            {
                _context.Cuisines.Remove(cuisine);
            }

            public void DeleteDish(Dish dish)
            {
                _context.Dishs.Remove(dish);
            }

            public Cuisine GetCuisine(Guid cuisineId)
            {
                return _context.Cuisines.FirstOrDefault(a => a.Id == cuisineId);
            }

            public IEnumerable<Cuisine> GetCuisines()
            {
                return _context.Cuisines.OrderBy(a => a.Name);
            }


            public void UpdateCuisine(Cuisine cuisine)
            {
                // no code in this implementation
            }

            public Dish GetDishForCuisine(Guid cuisineId, Guid dishId)
            {
                return _context.Dishs
                  .Where(b => b.CuisineId == cuisineId && b.Id == dishId).FirstOrDefault();
            }

            public IEnumerable<Dish> GetDishsForCuisine(Guid cuisineId)
            {
                return _context.Dishs
                            .Where(b => b.CuisineId == cuisineId).OrderBy(b => b.Name).ToList();
            }

            public void UpdateDishForCuisine(Dish dish)
            {
                // no code in this implementation
            }

            public bool Save()
            {
                return (_context.SaveChanges() >= 0);
            }

    }
 }
