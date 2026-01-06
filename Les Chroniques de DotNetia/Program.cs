using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Models.Ennemis;
using Les_Chroniques_de_DotNetia.Models.UI;

class Program
{
  static void Main()
  {
    Joueur joueur1 = new Guerrier("Peemers");
    Ennemi ennemi1 = new Sanglier();

    while (joueur1.IsAlive || ennemi1.IsAlive)
    {
      MenuCombat menuCombat = new MenuCombat(joueur1);

      ActionCombat actionChoisie = menuCombat.ChoisirAction();

      int degats = actionChoisie(ennemi1);

      Console.WriteLine($"Dégâts infligés : {degats}");
      Console.WriteLine($"PV restants de l'ennemi : {ennemi1.PvActuels}");

      Console.ReadKey();
    }
  }
}