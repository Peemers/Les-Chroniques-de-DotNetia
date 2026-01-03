namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class SerpentGéant : Ennemi
{
  
  //TODO empoisonnement possible plus tard
  
  //constructeur

  internal SerpentGéant() : base("Serpent Géant")
  {
  }
  
  //Override
  protected override int BasePv => 450;
}