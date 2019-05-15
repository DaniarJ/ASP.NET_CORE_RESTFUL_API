using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Models
{
    public static class RestaurantContextExtensions
    {
            public static void EnsureSeedDataForContext(this RestaurantContext context)
            {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously :-)

                context.Cuisines.RemoveRange(context.Cuisines);
                context.SaveChanges();

                // init seed data
                var cuisines = new List<Cuisine>()
            {
                new Cuisine()
                {
                     Id = new Guid("03d12ce6-4af2-4f22-ae60-151bb10c7349"),
                     Name = "Italian",
                     Type = "European",
                     Dishs = new List<Dish>()
                     {
                         new Dish()
                         {
                             Id = new Guid("03d12ce6-4af2-4f22-ae60-151bb10c1111"),
                             Name = "Pasta",
                             Description = "This is a description about Pasta"
                         },
                         new Dish()
                         {
                             Id = new Guid("03d12ce6-4af2-4f22-ae60-151bb10c2222"),
                             Name = "Pizza",
                             Description = "This is a description about Pizza"
                         },
                         new Dish()
                         {
                             Id = new Guid("03d12ce6-4af2-4f22-ae60-151bb10c3333"),
                             Name = "Spaghetti",
                             Description = "This is a description about Spaghetti"
                         }
                     }
                },
                new Cuisine()
                {
                     Id = new Guid("213838d4-9133-48a7-ae77-e27a09d84a23"),
                     Name = "Chinese",
                     Type = "Asian",
                     Dishs = new List<Dish>()
                     {
                         new Dish()
                         {
                             Id = new Guid("213838d4-9133-48a7-ae77-e27a09d81111"),
                             Name = "Chinese1",
                             Description = "This is a description about Chinese Dish 1"
                         },
                         new Dish()
                         {
                             Id = new Guid("213838d4-9133-48a7-ae77-e27a09d82222"),
                             Name = "Chinese2",
                             Description = "This is a description about Chinese Dish 2"
                         },
                         new Dish()
                         {
                             Id = new Guid("213838d4-9133-48a7-ae77-e27a09d83333"),
                             Name = "Chinese3",
                             Description = "This is a description about Chinese Dish 3"
                         }
                     }
                },
                new Cuisine()
                {
                     Id = new Guid("b2f2182a-dfb3-4bc9-a16d-43d3442db21c"),
                     Name = "Indian",
                     Type = "Asian",
                     Dishs = new List<Dish>()
                     {
                         new Dish()
                         {
                             Id = new Guid("b2f2182a-dfb3-4bc9-a16d-43d3442d1111"),
                             Name = "Indian1",
                             Description = "This is a description about Indian Dish 1"
                         }
                         ,
                         new Dish()
                         {
                             Id = new Guid("b2f2182a-dfb3-4bc9-a16d-43d3442d2222"),
                             Name = "Indian2",
                             Description = "This is a description about Indian Dish 2"
                         }
                     }
                }
            };
            context.Cuisines.AddRange(cuisines);
            context.SaveChanges();
            }
        }
 }