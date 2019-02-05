using System.Linq;
using HelloCore.Data;
using HelloCore.Models;

public class DBInitializer
{
    public static void Initialize(HelloCoreContext context)
    {
        //Zeker zijn dat databank bestaat en zoniet aangemaakt wordt
        context.Database.EnsureCreated();

        //Als er al klanten zijn, hoeft db niet meer opgevuld worden
        if (context.Klanten.Any())
        {
            return;
        }

        //Db opvullen met klanten
        context.Klanten.AddRange(
            new Klant { Naam = "De Neve", Voornaam = "Jos", AangemaaktDatum = new System.DateTime(2019, 1, 20) },
            new Klant { Naam = "Bruynseels", Voornaam = "Rita", AangemaaktDatum = new System.DateTime(2019, 2, 4) },
            new Klant { Naam = "Naert", Voornaam = "Willy", AangemaaktDatum = new System.DateTime(2018, 12, 29) }
        );

        //Wijzigingen bewaren, insert query wordt achter de schermen uitgevoerd!
        context.SaveChanges();
    }
}