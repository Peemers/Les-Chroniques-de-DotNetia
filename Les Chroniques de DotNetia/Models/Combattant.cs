using Les_Chroniques_de_DotNetia.Interfaces;
using Les_Chroniques_de_DotNetia.Utils;

// ReSharper disable All

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Combattant : ICombattant, ICible
{
  #region Propriétés

  //Prop
  public string Pseudo { get; protected init; }
  public int MaxPv { get; protected set; }
  public int PvActuels { get; protected set; }
  public int AttaqueBase { get; protected init; } = 2;
  protected abstract int BasePv { get; }


  private De _deDegats; //ajout des dés dans logique de combat
  private De _critique; //ajout des dés dans logique de combat

  public bool IsAlive // True si Pv au dessus de 0
  {
    get { return PvActuels > 0; }
  }

  protected virtual double MultiplicateurDegats => 1.0; //prop Overridé chez les enfants
  protected virtual double MultiplicateurDegatsRecus => 1.0; // idem

  #endregion

  #region Constructeurs

  //Constructeurs

  protected Combattant(string pseudo)
  {
    MaxPv = BasePv;
    PvActuels = MaxPv;
    Pseudo = pseudo;
    _deDegats = new De(1, 8);
    _critique = new De(1, 20);
  }

  #endregion

  #region Methodes

  #region Attaquer

  public int Attaquer(ICible cible)
  {
    if (cible == null || !IsAlive)
      return 0;

    int degats = AttaqueBase + _deDegats.Lancer(); //utilisation des dés
    int jetCritique = _critique.Lancer(); //utilisation des dés

    int degatsFinaux = degats;
    degatsFinaux = (int)(degatsFinaux * MultiplicateurDegats); //cast du double et Multip Overridé par les enfants

    if (jetCritique == 20)
    {
      degatsFinaux = degatsFinaux * 2;
    }

    cible.RecevoirDegats(degatsFinaux);
    ApresAttaque(); //Override par les enfants

    return degatsFinaux;
  }

  #endregion

  #region AttaqueLourde

  public int AttaqueLourde(ICible cible)
  {
    if (cible == null || !IsAlive || !PeutAttaquerLourd())
      return 0;

    int atk = AttaqueBase + _deDegats.Lancer();
    int degats = atk + atk / 2;
    int jetCritique = _critique.Lancer();

    int degatsFinaux = degats;

    degatsFinaux = (int)(degatsFinaux * MultiplicateurDegats);


    if (jetCritique == 20)
    {
      degatsFinaux = degatsFinaux * 2;
    }

    cible.RecevoirDegats(degatsFinaux);
    ApresAttaqueLourde();
    return degatsFinaux;
  }

  #endregion

  #region RecevoirDegats

  void ICible.RecevoirDegats(int degats)
  {
    if (PvActuels <= 0)
      return;

    int degatsFinaux = (int)(degats * MultiplicateurDegatsRecus);
    PvActuels -= degatsFinaux;

    if (PvActuels < 0)
      PvActuels = 0;
  }

  #endregion

  #region ApresAttaque

  protected virtual void ApresAttaque() //Overridé par les enfants
  {
  }

  #endregion

  #region ApresAttaqueLourde

  protected virtual void ApresAttaqueLourde() //Overridé par les enfants
  {
  }

  #endregion

  #region PeutAttaquerLourd

  protected abstract bool PeutAttaquerLourd(); //Overridé par les enfants

  #endregion

  #endregion
}