// ReSharper disable All

using System.Net.Cache;

namespace Les_Chroniques_de_DotNetia.Models;

internal class Mage : Joueur
{
  //PROP
  //Ressource

  public int Mana { get; protected set; }

  public int MaxMana { get; } = 250;

  public int RegenMontant { get; protected set; } = 5; //peut etre modifié plus tard par des potions ou equipements
  public int ManaOut { get; private set; } = 20;
  
  protected int CoutAttaqueLourdeReel => ManaOut; // plus tard : modifs / => = get

  
  //(PROP) Bonus de Classe
  private const double seuilManaHaut = 0.70;

  public bool EstIllumine
  {
    get { return Mana >= MaxMana * seuilManaHaut; }
  }

  public double BonusAttaque
  {
    get { return EstIllumine ? 1.25 : 1.00; }
  }

  //(PROP) Override

  protected override double MultiplicateurDegats
  {
    get { return BonusAttaque; }
  }

  //Constructeurs

  public Mage(string pseudo) : base(350, pseudo)
  {
    Mana = MaxMana;
  }

  //METHODES
  //(METHODES) Bonus de classe

  //(METHODES) fonctionnement
  
  //(METHODES) Override

  protected override void ApresAttaque()
  {
    Mana += RegenMontant;
    if (Mana > MaxMana)
      Mana = MaxMana;
  }

  protected override bool PeutAttaquerLourd()
  {
    return Mana >= CoutAttaqueLourdeReel;
  }

  protected override void ApresAttaqueLourde()
  {
    Mana = Mana + RegenMontant - CoutAttaqueLourdeReel;
    if (Mana < 0)
      Mana = 0;

    if (Mana > MaxMana)
      Mana = MaxMana;
  }
}