using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Wspolczynnik_Nazwa
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Skrot { get; set; }
        [Required]
        public string Opis { get; set; }

        public virtual ICollection<Wspolczynnik> Wspolczynnik { get; set; }
    }
}