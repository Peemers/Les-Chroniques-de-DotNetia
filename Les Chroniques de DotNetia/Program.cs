using System.Runtime;
using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Interfaces;

Joueur j1 = new Joueur(400, "Peemers");
Ennemi e1 = new Ennemi(200, "Ethias");

Console.WriteLine(
  $"{j1.Pseudo} a {j1.PvActuels} points de vie et {j1.Ressource} point de ressource.\n{e1.Pseudo} a {e1.PvActuels} point de vie et {e1.Ressource} point de ressource");

j1.RegenRessource();

Console.WriteLine($"{j1.Ressource} ressource joueur 1, ne doit pas dépasser 50");

int degats = j1.Attaquer(e1);
int degatsLourd = j1.AttaqueLourde(e1);

while (j1.Ressource > 0)
{
  j1.Attaquer(e1);
  Console.WriteLine($"{j1.Pseudo} inflige {degats} sur {e1.Pseudo}");
  j1.AttaqueLourde(e1);
  Console.WriteLine($"{j1.Pseudo} inflige {degatsLourd} sur {e1.Pseudo}");
  
  Console.WriteLine($"{j1.Ressource} doit descendre de 10 a la fois");
}

j1.RegenRessource();

Console.WriteLine($"{j1.Ressource} ressources du joueur 1 il doit rester 5 normalement");

Console.WriteLine($"{j1.Pseudo} a {j1.PvActuels} et {j1.Ressource} {e1.Pseudo} a {e1.PvActuels} et {e1.Ressource}");

