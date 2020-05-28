using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Zrodlo
    {
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Doi { get; set; }
        [Required]
        public string Opis { get; set; }

        public virtual ICollection<Wspolczynnik> Wspolczynnik { get; set; }

    }
}