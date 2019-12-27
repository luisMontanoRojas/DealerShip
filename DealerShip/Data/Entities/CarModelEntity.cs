using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DealerShip.Data.Entities
{
    public class CarModelEntity
    {
        [Required]
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
        [ForeignKey("CarId")]
        public virtual CarBrandEntity carBrandId { get; set; }
    }
}
