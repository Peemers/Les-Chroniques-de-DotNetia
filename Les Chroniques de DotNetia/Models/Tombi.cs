using Les_Chroniques_de_DotNetia.Interfaces;

namespace Les_Chroniques_de_DotNetia.Models;

internal class Tombi : Ennemi
{
  //prop

  private int _distance = 0;
  private bool _dejaAttaque = false;

  //Constructeur 
  internal Tombi(string pseudo) : base("Tombi")
  {
  }

  //override

  protected override int BasePv => 650;

  protected override void FinTour()
  {
    if (!_dejaAttaque)
      _distance++;
  }

  public override int Attaquer(ICible cible)
  {
    if (cible == null || !IsAlive)
      return 0;

    int degats = AttaqueBase;

    if (_distance >= 6)
    {
      //Contact!
      _dejaAttaque = true;
      degats = AttaqueBase * 200;
      cible.RecevoirDegats(degats);
      return degats;
    }

    if (_dejaAttaque)
    {
      return 0;
    }

    else if (_distance >= 4)
    {
      //très proche
      return 0;
    }

    else if (_distance >= 2)
    {
      //proche
      return 0;
    }
    else
    {
      //loin
      return 0;
    }
  }
}