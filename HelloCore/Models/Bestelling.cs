using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCore.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string Artikel { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal? Prijs { get; set; }
        [Display(Name = "Klant")]
        public int KlantID {get; set; }
        public Klant Klant { get; set; }

        [NotMapped]
        public string KlantDisplay {
            get {
                if(Klant != null) {
                return $"{Klant.Voornaam} {Klant.Naam}";
                } else {
                    return "";
                }
            }
        }
    }
}
