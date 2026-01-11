using Les_Chroniques_de_DotNetia.Utils;

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Joueur : Combattant
{
  //Prop

  private readonly De _chanceDeFuite;

  //Constructeurs

  internal Joueur(string pseudo) : base(pseudo)
  {
    _chanceDeFuite = new De(1, 6);
  }

  //Methodes  

  protected void TenterLaFuite()
  {
    int chanceDeFuite = _chanceDeFuite.Lancer();
    if (chanceDeFuite == 6)
    {
      
    }
    
  }
}