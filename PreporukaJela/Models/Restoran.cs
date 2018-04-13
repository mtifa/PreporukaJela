using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreporukaJela.Models
{
    public class Restoran
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Telefon { get; set; }
        public ICollection<Jelo> Jela { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}