namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class ScorpionGéant : Ennemi
{
  //TODO sera capable d'empoisonner plus tard
  
  //Constructeur
 
  internal ScorpionGéant() : base("Scorpion Géant")
  {
  }
  
  //Override

  protected override int BasePv => 400;
  
}