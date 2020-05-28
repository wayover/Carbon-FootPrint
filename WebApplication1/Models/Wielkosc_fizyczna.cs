using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Wielkosc_fizyczna
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public int Jednostka_bazowaID { get; set; }
        public virtual Jednostka_bazowa Jednostka_Bazowa { get; set; }
        public virtual ICollection<Wielkosc_fizyczna> Wielkosc_Fizyczna { get; set; }
    }
}