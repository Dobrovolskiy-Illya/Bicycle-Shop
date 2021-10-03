using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        public string ContactPhone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
    }
}
