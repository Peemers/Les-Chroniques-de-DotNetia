using Les_Chroniques_de_DotNetia.Interfaces;
using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Models.Ennemis;
using Les_Chroniques_de_DotNetia.Models.Zones;

internal delegate int FightAction(ICible cible);

class Program
{
  static void Main()
  {
    FightAction action;
    
    Joueur joueur1 = new Guerrier("Peemers");
    Ennemi ennemi1 = new Sanglier();

    action = joueur1.Attaquer;

    int degats = action(ennemi1);
  }
}