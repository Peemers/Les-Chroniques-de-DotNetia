using System.Runtime;
using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Interfaces;

Joueur j1 = new Guerrier("Peemers");
Ennemi e1 = new Ennemi(450, "Dragon");

while (j1.PvActuels > 0 && e1.PvActuels > 0)
{
  Console.Clear();
  Console.WriteLine($" ---Tour de {j1.Pseudo}---\n");
  Console.WriteLine($"Point de vie = {j1.PvActuels} \nRessource = {j1.Ressource} \nPoint de vie de {e1.Pseudo} =  {e1.PvActuels}\n");
  Console.WriteLine($"Choisissez votre Action : \n1 - Attaque normale \n2 - Attaque lourde-\nR/r - Régénérer la ressource \nQ/q pour quitter");

  string input = Console.ReadLine()!;

  if (input == "Q" || input == "q")
  {
    Console.Clear();
    break;
  }

  if (input != "Q" && input != "q" && input != "r" && input != "R" && input != "1" && input != "2")
  {
    Console.Clear();
    break;
  }

  switch (input)
  {
    case "1":

      Console.Clear();
      int degats = j1.Attaquer(e1);
      Console.WriteLine($"\n{j1.Pseudo} inflige {degats} de dégats avec une attaque normale à {e1.Pseudo}");
      Console.WriteLine($"Il reste {e1.PvActuels} PV à {e1.Pseudo}\n \n");
      break;

    case "2":

      Console.Clear();
      int degatsLourd = j1.AttaqueLourde(e1);
      Console.WriteLine($"\n{j1.Pseudo} inflige {degatsLourd} de dégats avec une attaque lourde à {e1.Pseudo}");
      Console.WriteLine($"{j1.Pseudo} a dépensé {j1.CoutAttaqueLourde} point de ressource. Reste {j1.Ressource}");
      Console.WriteLine($" Il reste {e1.PvActuels} PV à {e1.Pseudo}");
      break;

    case "R":

      Console.Clear();
      j1.RegenRessource();
      Console.WriteLine($"{j1.Pseudo} lance une regen de ressource et récupere {j1.RegenValeur} et dispose maintenant de {j1.Ressource} point de ressource");
      break;
  }

  Console.WriteLine($"---Tour de {e1.Pseudo}---\n");
  int degatsEnn = e1.Attaquer(j1);
  Console.WriteLine($"{e1.Pseudo} inflige {degatsEnn} point de dégats à {j1.Pseudo}");
  Console.WriteLine($"Il reste {j1.PvActuels} PV à {j1.Pseudo}\n");
  Console.WriteLine("Appuyez sur entrée pour continuer");
  Console.ReadLine();
}



