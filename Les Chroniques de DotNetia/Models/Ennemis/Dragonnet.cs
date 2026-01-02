namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class Dragonnet : Ennemi
{
  //Constructeur

  internal Dragonnet() : base("Dragonnet")
  {
  }
  
  //override

  protected override int BasePv => 350;

  protected override double MultiplicateurDegats => 1.3;
  //Methodes

}