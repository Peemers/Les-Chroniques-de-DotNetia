// ReSharper disable All
namespace Les_Chroniques_de_DotNetia.Models;

internal class Guerrier : Joueur
{
  //Ressource
  public int Rage { get; protected set; }
  public int RageMax { get; } = 100;

  //Configuration Berserk
  private const double SeuilPvBas = 0.30; // 30 %

  public bool EstEnBerserk
  {
    get { return PvActuels <= MaxPv * SeuilPvBas; }
  }

  //Bonus vie faible ?
  public double BonusDegats
  {
    get { return EstEnBerserk ? 1.25 : 1.0; } // +25 %
  }

  public double ReductionDegats
  {
    get { return EstEnBerserk ? 0.75 : 1.0; } // -25 %
  }

  //Constructeur
  public Guerrier(string pseudo) : base(650, pseudo)
  {
    Rage = 0;
  }

  //Gestion de la rage
  protected void GagnerRage(int montant)
  {
    Rage += montant;
    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected bool DepenserRage(int cout)
  {
    if (Rage < cout)
      return false;

    Rage -= cout;
    return true;
  }
}