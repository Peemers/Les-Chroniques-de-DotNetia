// ReSharper disable All

namespace Les_Chroniques_de_DotNetia.Models;

internal class Guerrier : Joueur
{
  //Ressource
  public int Rage { get; protected set; }
  public int RageMax { get; } = 100;

  private const int GagnerRageMontant = 10;
  private int rageOut { get; set; } = 14;

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
  protected void GagnerRage()
  {
    Rage += GagnerRageMontant;
    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected bool DepenserRage()
  {
    if (Rage < rageOut)
      return false;

    Rage -= rageOut;
    return true;
  }
  
  //OverRide

  protected override void ApresAttaque() //gain de rage apres attaque
  {
    Rage = Rage + GagnerRageMontant;
    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected override void ApresAttaqueLourde()
  {
    Rage = Rage + GagnerRageMontant - rageOut;
    if (Rage < 0)
      Rage = 0;

    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected override bool PeutAttaquerLourd()
  {
    return Rage >= rageOut;
  }

  protected override double MultiplicateurDegats
  {
    get { return BonusDegats; }
  }

  protected override double MultiplicateurDegatsRecus => ReductionDegats;
}