using Les_Chroniques_de_DotNetia.Models.Zones;

class Program
{
  static void Main()
  {
    Zone zoneActuelle = new Foret();

    Console.WriteLine(zoneActuelle.Nom);
    Console.WriteLine(zoneActuelle.Description);

    var ennemi = zoneActuelle.GenererEnnemi();
    Console.WriteLine($"Un {ennemi.Pseudo} apparaît !");
  }
}