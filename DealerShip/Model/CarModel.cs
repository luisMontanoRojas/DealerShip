using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Model
{
    public class CarModel
    {
        public int? id { get; set; }
        [Required]
        public string name { get; set; }
        public string urlImage { get; set; }
        public int year { get; set; }
        public int displacement { get; set; }//cilindrada
        public int horsePower { get; set; }//caballosDeFuerza
        public int weight { get; set; }//peso
        public string transmission { get; set; }
        public int basicPrice { get; set; }
        [Required]
        public int? carBrandId { get; set; }//el int? es para que si le mandamos vacio por defecto este valor se pone en cero con el int? te regresa como nulo y eso es lo que necesitamos
    }
}
