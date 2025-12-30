// ReSharper disable All

using System.Net.Cache;

namespace Les_Chroniques_de_DotNetia.Models;

internal class Mage : Joueur
{
  //PROP
  //Ressource

  public int Mana { get; protected set; }

  public int MaxMana { get; } = 250;
  
  public int RegenMontant { get ; protected set; } = 5; //peut etre modifié plus tard par des potions ou equipements
  
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
    Mana = 0;
  }

  //METHODES
  //(METHODES) Bonus de classe

  protected void RegenMana()
  {
    Mana += RegenMontant;
    if (Mana > MaxMana)
      Mana = MaxMana;
  }
  
  //(METHODES) fonctionnement

  protected bool depenserMana(int cout)
  {
    if (Mana < cout)
      return false;

    Mana = Mana - cout;
    return true;
  }
  
  //(METHODES) Override

  protected override void ApresAttaque()
  {
    RegenMana();
  }
}