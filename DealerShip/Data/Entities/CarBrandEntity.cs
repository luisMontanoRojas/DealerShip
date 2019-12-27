using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data.Entities
{
    public class CarBrandEntity
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [StringLength(20, ErrorMessage = "error {0} There isn't a country name with more than {1} min is {2}", MinimumLength = 2)]
        public string nationality { get; set; }
        
        public string url_logo_image { get; set; }
        public string facebook { get; set; }
      
        public string ubication { get; set; }
        public string about { get; set; }
        
        public string oficialPage { get; set; }
        public virtual ICollection<CarModelEntity> carModels { get; set; }
    }
}
