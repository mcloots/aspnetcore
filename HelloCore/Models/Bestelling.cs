using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloCore.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string Artikel { get; set; }
        public Decimal? Prijs { get; set; }
        public int KlantID {get; set; }
        public Klant Klant { get; set; }

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
