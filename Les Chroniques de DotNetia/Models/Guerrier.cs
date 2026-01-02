// ReSharper disable All

namespace Les_Chroniques_de_DotNetia.Models;

internal class Guerrier : Joueur
{
  #region Props

  //Ressource
  public int Rage { get; protected set; }
  public int RageMax { get; } = 100;

  private const int RageIn = 10;
  private int RageOut { get; set; } = 14;

  //Configuration Berserk
  private const double SeuilPvBas = 0.30; // si pv plus bas que 30 %

  public bool EstEnBerserk
  {
    get { return PvActuels <= MaxPv * SeuilPvBas; } //Bersek si pvseuilbas
  }

  //Bonus vie faible ?
  public double BonusDegats
  {
    get { return EstEnBerserk ? 1.25 : 1.0; } // si bersek alors +25 %
  }

  public double ReductionDegats
  {
    get { return EstEnBerserk ? 0.75 : 1.0; } // si bersek alors -25 %
  }

  #endregion

  #region Constructeurs

  //Constructeur
  public Guerrier(string pseudo) : base(pseudo)
  {
    Rage = 0;
  }

  #endregion

  //Gestion de la rage

  #region Override

  //OverRide

  protected override void ApresAttaque() //gain de rage apres attaque -Override de la classe Combattant.ApresAttaque
  {
    Rage = Rage + RageIn;
    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected override void ApresAttaqueLourde() //Override de la classe Combattant.ApresAttaqueLourde
  {
    Rage = Rage + RageIn - RageOut;
    if (Rage < 0)
      Rage = 0;

    if (Rage > RageMax)
      Rage = RageMax;
  }

  protected override bool PeutAttaquerLourd() //Override de la classe Combattant.PeutAttaquerLourd
  {
    return Rage >= RageOut;
  }

  protected override double MultiplicateurDegats // //Override de la classe Combattant.MultiplicateurDegats
  {
    get { return BonusDegats; }
  }

  protected override double MultiplicateurDegatsRecus => ReductionDegats;

  protected override int BasePv => 600;

  #endregion
}