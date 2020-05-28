using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Nazwa_nośnika
    {
        public int Id { get; set; }
        [Required]
        public string Nosnik { get; set; }
        [Required]
        public string Kod_GUS { get; set; }
        [Required]
        public int equivkgCO2 { get; set; }
        public virtual ICollection<Nośnik_energii> Nośnik_Energii { get; set; }
        public virtual ICollection<Modul> Modul { get; set; }
    }
}