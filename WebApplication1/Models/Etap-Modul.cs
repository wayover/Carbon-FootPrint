using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Etap_Modul
    {

        public int Id { get; set; }
        [Required]
        public int ModulID { get; set; }
        [Required]
        public int EtapID { get; set; }

        //public virtual Modul Modul { get; set; }
        //public virtual Etap Etap { get; set; }
    }
}