using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Surowiec
    {
        public int Id { get; set; }
        [Required] 
        public string Nazwa { get; set; }
        [Required] 
        public string Opis { get; set; }
        [Required] 
        public int WspolczynnikID { get; set; }

        public virtual Wspolczynnik Wspolczynnik { get; set; }
        public virtual ICollection<Modul> Modul { get; set; }
        public virtual ICollection<Etap> Etap { get; set; }
        public virtual ICollection<Linie_Produkcyjne> Linie_Produkcyjne { get; set; }

    }
}