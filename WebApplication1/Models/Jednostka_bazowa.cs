using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Jednostka_bazowa
    {

        public int Id { get; set;}
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Skrot { get; set; }
        public virtual ICollection<Wielkosc_fizyczna> Wielkosc_Fizyczna { get; set; }
    }
}