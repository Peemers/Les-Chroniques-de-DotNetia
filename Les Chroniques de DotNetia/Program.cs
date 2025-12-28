using Les_Chroniques_de_DotNetia.Models;
using Les_Chroniques_de_DotNetia.Interfaces;

Joueur j1 = new Joueur(400);
Ennemi e1 = new Ennemi(200);

Console.WriteLine($"J1 a {j1.PvActuels} E1 a {e1.PvActuels}");

while (e1.IsAlive)
{
    j1.Attaquer(e1);
}

Console.WriteLine($"J1 a {j1.PvActuels} E1 a {e1.PvActuels}");


