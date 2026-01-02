namespace Les_Chroniques_de_DotNetia.Models;

internal class Dragonnet : Ennemi
{
  //Constructeur

  internal Dragonnet(string pseudo) : base("Dragonnet")
  {
  }
  
  //override

  protected override int BasePv => 350;

  protected override double MultiplicateurDegats => 1.3;
  //Methodes

}