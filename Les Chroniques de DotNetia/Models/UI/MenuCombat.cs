using Les_Chroniques_de_DotNetia.Interfaces;
using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Models.Zones;

namespace Les_Chroniques_de_DotNetia.Models.UI;

internal delegate int ActionCombat(ICible cible);

internal class MenuCombat
{
  private readonly Joueur _joueur;

  internal MenuCombat(Joueur joueur)
  {
    _joueur = joueur;
  }

  internal ActionCombat ChoisirAction()
  {
    Console.WriteLine("Choisissez une action :");
    Console.WriteLine("1 - Attaquer");
    Console.WriteLine("2 - Attaque Lourde");
    Console.WriteLine("3 - Tenter une fuite");
    

    string choix = Console.ReadLine()!;

    switch (choix)
    {
      case "1":
        return _joueur.Attaquer;
      case "2":
        return _joueur.AttaqueLourde;
      case "3":
        
      default:
        Console.WriteLine("Choix invalide, attaque par défaut.");
        return _joueur.Attaquer;
    }
  }
}