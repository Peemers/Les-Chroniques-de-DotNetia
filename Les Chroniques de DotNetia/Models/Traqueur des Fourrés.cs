using Les_Chroniques_de_DotNetia.Interfaces;

namespace Les_Chroniques_de_DotNetia.Models;

internal class TraqueurDesFourrés : Ennemi
{
  private bool _estTouche;
  private int _compteurPasTouche;

  //prop

  //constructeurs
  internal TraqueurDesFourrés(string pseudo) : base("Tranqueur des Fourrés")
  {
  }

  //Override

  protected override int BasePv => 400;
  protected override double MultiplicateurDegats => 0.8;

  protected override void DebutTour()
  {
    _estTouche = false;
  }

  protected override void ApresReceptionDegats()
  {
    _estTouche = true;
    _compteurPasTouche = 0;
  }

  protected override void FinTour()
  {
    if (!_estTouche)
    {
      _compteurPasTouche++;
    }
  }

  public override int Attaquer(ICible cible)
  {
    if (cible == null || !IsAlive)
      return 0;

    int degats = AttaqueBase;


    if (_compteurPasTouche >= 5)
    {
      degats = AttaqueBase * 4;
      _compteurPasTouche = 0;
    }
    else if (_compteurPasTouche >= 2)
    {
      degats = AttaqueBase * 2;
      _compteurPasTouche = 0;
    }


    cible.RecevoirDegats(degats);
    return degats;
  }
}