using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Linie_Produkcyjne
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public int SurowiecID { get; set; }//warzywo

        public virtual Surowiec Surowiec { get; set; }
      //  public virtual ICollection<Linie_Etap> Linie_Etap { get; set; }

    }
}