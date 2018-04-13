using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreporukaJela.Models
{
    public class Jelo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        public int RestoranId { get; set; }
        public virtual Restoran Restoran { get; set; }
    }
}