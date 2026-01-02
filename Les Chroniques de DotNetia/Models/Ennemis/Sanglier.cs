namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class Sanglier : Ennemi
{
  //Constructeur

  internal Sanglier() : base("Sanglier")
  {
  }
  
  //override

  protected override int BasePv => 800;

  protected override double MultiplicateurDegats => 0.5;
  //Methodes
}