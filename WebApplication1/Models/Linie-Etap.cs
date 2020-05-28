using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Linie_Etap
    {
        public int Id { get; set; }
        [Required]
        public int Linie_ProdukcyjneID { get; set; }
        [Required]
        public int EtapID { get; set; }

        //public virtual Linie_Produkcyjne Linie_Produkcyjne { get; set; }
        //public virtual Etap Etap { get; set; }
    }
}