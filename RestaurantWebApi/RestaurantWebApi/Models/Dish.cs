using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebApi.Models
{
    public class Dish
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("CuisineId")]
        public Cuisine Cuisine { get; set; }

        public Guid CuisineId { get; set; }


    }
}
