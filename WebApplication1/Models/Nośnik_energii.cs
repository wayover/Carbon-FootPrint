using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Nośnik_energii
    {
        public int Id { get; set; }
        [Required]
        public int Nazwa_nośnikaID { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public float EqivCO2 { get; set; }
        [Required]
        public int JednostkaID { get; set; }
        [Required]
        public float NCV { get; set; }
        [Required]
        public int WE { get; set; }

        public virtual Jednostka Jednostka { get; set; }

        public virtual Nazwa_nośnika Nazwa_Nośnika { get; set; }


    }
}