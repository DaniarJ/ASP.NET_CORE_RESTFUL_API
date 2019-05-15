using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Data
{
    public class CuisineDto
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public IEnumerable<DishDto> Dishs { get; set; }
           = new List<DishDto>();
    }
}
