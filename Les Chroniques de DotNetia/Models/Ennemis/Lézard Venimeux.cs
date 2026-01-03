namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class LezardVenimeux : Ennemi
{
  //TODO empoisonnement à implémenter aussi plus tard
  
  //constructeur

  internal LezardVenimeux() : base("Lezard Venimeux")
  {
  }
  
  //override
  
  protected override int BasePv => 550;
}