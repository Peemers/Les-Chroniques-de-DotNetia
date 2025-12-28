using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Interfaces;

Joueur j1 = new Joueur(400, "Peemers");
Ennemi e1 = new Ennemi(200, "Ethias");

Console.WriteLine($"{j1.Pseudo} a {j1.PvActuels} points de vie et {j1.Ressource} point de ressource.\n{e1.Pseudo} a {e1.PvActuels} point de vie et {e1.Ressource} point de ressource");

//while (e1.PvActuels > 0 || j1.PvActuels > 0)
//{
  
//}

j1.Attaquer(e1);
e1.AttaqueLourde(j1);

cw



Console.WriteLine($"{j1.Pseudo} a {j1.PvActuels} {e1.Pseudo} a {e1.PvActuels}");


