using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantWebApi.Models;

namespace RestaurantWebApi.Repositories
{
    public interface IRestaurantRepository
    {
            IEnumerable<Cuisine> GetCuisines();
            Cuisine GetCuisine(Guid cuisineId);
            void AddCuisine(Cuisine cuisine);
            void DeleteCuisine(Cuisine cuisine);
            void UpdateCuisine(Cuisine cuisine);
            bool CuisineExists(Guid cuisineId);
            IEnumerable<Dish> GetDishsForCuisine(Guid cuisineId);
            Dish GetDishForCuisine(Guid cuisineId, Guid dishId);
            void AddDishForCuisine(Guid cuisineId, Dish dish);
            void UpdateDishForCuisine(Dish dish);
            void DeleteDish(Dish dish);
            bool Save();
        }
    }
