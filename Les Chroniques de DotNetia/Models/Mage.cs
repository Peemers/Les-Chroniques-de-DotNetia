// ReSharper disable All

using System.Net.Cache;

namespace Les_Chroniques_de_DotNetia.Models;

internal class Mage : Joueur
{
  //PROP
  //Ressource

  public int Mana { get; protected set; }

  public int MaxMana { get; } = 250;

  public int ManaIn { get; protected set; } = 5; //peut etre modifié plus tard par des potions ou equipements
  public int ManaOut { get; private set; } = 20;

  protected int CoutAttaqueLourdeReel => ManaOut; // plus tard : modifs / => = get


  //(PROP) Bonus de Classe
  private const double seuilManaHaut = 0.70; //si mana par dessus 70% appelé juste en bas

  public bool EstIllumine
  {
    get { return Mana >= MaxMana * seuilManaHaut; } //ici
  }

  public double BonusAttaque
  {
    get { return EstIllumine ? 1.25 : 1.00; } // si est éliminé 1.25x dégats sinon 1x
  }

  //(PROP) Override

  protected override double MultiplicateurDegats //Override de la classe Combattant.MultiplicateurDegats
  {
    get { return BonusAttaque; }
  }

  protected override int BasePv => 350;

  //Constructeurs

  public Mage(string pseudo) : base(pseudo)
  {
    Mana = MaxMana;
  }

  //METHODES
  //(METHODES) Bonus de classe

  //(METHODES) fonctionnement

  //(METHODES) Override

  protected override void ApresAttaque() //Override de la classe Combattant.ApresAttaque
  {
    Mana += ManaIn;
    if (Mana > MaxMana)
      Mana = MaxMana;
  }

  protected override bool PeutAttaquerLourd() //Override de la classe Combattant.PeutAttaquerLourd
  {
    return Mana >= CoutAttaqueLourdeReel;
  }

  protected override void ApresAttaqueLourde() //Override de la classe Combattant.ApresAttaqueLourde
  {
    Mana = Mana + ManaIn - CoutAttaqueLourdeReel;
    if (Mana < 0)
      Mana = 0;

    if (Mana > MaxMana)
      Mana = MaxMana;
  }
}