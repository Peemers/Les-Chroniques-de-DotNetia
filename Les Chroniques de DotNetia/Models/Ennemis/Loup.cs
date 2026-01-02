namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class Loup : Ennemi
{
  //Constructeur

  internal Loup() : base("Dragonnet")
  {
  }
  
  //override

  protected override int BasePv => 550;

  protected override double MultiplicateurDegats => 0.6;
  //Methodes

}