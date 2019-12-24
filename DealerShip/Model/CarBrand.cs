using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Model
{
    public class CarBrand
    {
        public int? id { get; set; }
        [Required]
        public string name { get; set; }
        [StringLength(20, ErrorMessage = "error {0} There isn't a country name with more than {1} min is {2}", MinimumLength = 2)]
        public string nationality { get; set; }
        public string facebook { get; set; }
        [Required]
        public string ubication { get; set; }
        public string about { get; set; }
        [Required]
        public string oficialPage { get; set; }
        public IEnumerable<CarModel> carModels { get; set; }
    }
}
