using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Modul
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public int Moc { get; set; }
        [Required]
        public int Nazwa_nośnikaID { get; set; }//zasoby
        [Required]
        public int SurowiecID { get; set; }//warzywa

       // public virtual ICollection<Etap_Modul> Etap_Modul { get; set; }
       public virtual Surowiec Surowiec { get; set; }
        public virtual Nazwa_nośnika Nazwa_Nośnika { get; set; }
    }
}