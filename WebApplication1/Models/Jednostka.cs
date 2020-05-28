using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Jednostka
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Skrot { get; set; }
        [Required]
        public int Wielkosc_fizycznaID { get; set; }
        [Required]
        public float Przelicznik { get; set; }

        public virtual Wielkosc_fizyczna Wielkosc_Fizyczna { get; set; }
        public virtual ICollection<Nośnik_energii> Nośnik_Energii { get; set; }
        public virtual ICollection<Wspolczynnik> Wspolczynnik { get; set; }

    }
}