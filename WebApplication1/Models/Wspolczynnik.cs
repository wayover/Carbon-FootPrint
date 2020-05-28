using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Wspolczynnik
    {
        public int Id { get; set; }
        [Required]
        public int Wspolczynnik_NazwaID { get; set; }
        [Required]
        public int ZrodloID { get; set; }
        [Required]
        public float Wartosc { get; set; }
        /*Najprościej będzie tutaj użytkownika zmusic do wpisania wartości w odpowiedzniej jednostce */
      //  [Required]
       // public Jednostka Jedkostka_licznik { get; set; }
     //   [Required] 
      //  public Jednostka Jednostka_mianownik { get; set; }
       // [Required] 
       // public   Jednostka Jednostka_mianownik2 { get; set; }
        public float Niepewnosc { get; set; }

        public virtual Wspolczynnik_Nazwa Wspolczynnik_Nazwa { get; set; }
        public virtual Zrodlo Zrodlo { get; set; }
        public virtual ICollection<Surowiec> Surowiec { get; set; }
    }
}