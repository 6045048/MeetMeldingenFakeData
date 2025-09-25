using System;
using System.Globalization;
using Bogus;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nl-NL");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("nl-NL");

Randomizer.Seed = new Random(1234);

string[] diensten = { "Ambulance", "Brandweer", "Politie" };
string[] types = { "Verkeersongeval", "Brand", "Spoedrit", "Inbraak", "Reanimatie" };

// Create a Faker instance for generating fake reports in Dutch
var meldingFaker = new Faker<Melding>("nl")
    .RuleFor(m => m.Hulpdienst, f => f.PickRandom(diensten))
    .RuleFor(m => m.Locatie, f => f.Address.StreetAddress() + ", " + f.Address.City())
    .RuleFor(m => m.Type, f => f.PickRandom(types))
    .RuleFor(m => m.Tijdstip, f => f.Date.Recent(1));

// Generate 500 fake reports
var meldingen = meldingFaker.Generate(500);


// Display each generated report with the date, service, type, and location
foreach (var m in meldingen)
{
    Console.WriteLine($"{m.Tijdstip:G}: {m.Hulpdienst} -> {m.Type} op {m.Locatie}");
}

Console.WriteLine("\nDruk op een toets om af te sluiten...");
Console.ReadKey();

// Define the class after the code
public class Melding
{
    public string Hulpdienst { get; set; }
    public string Locatie { get; set; }
    public string Type { get; set; }
    public DateTime Tijdstip { get; set; }
}