using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Models
{
    public class Cuisine
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public ICollection<Dish> Dishs { get; set; }
            = new List<Dish>();


    }
}
