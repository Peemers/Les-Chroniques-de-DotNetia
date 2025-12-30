using Les_Chroniques_de_DotNetia.Interfaces;
using Les_Chroniques_de_DotNetia.Utils;

// ReSharper disable All

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Combattant : ICombattant
{
  #region Propriétés

  //Prop
  public string Pseudo { get; protected init; }
  public int MaxPv { get; protected set; }
  public int PvActuels { get; protected set; }
  public int AttaqueBase { get; protected init; } = 2;
  public int Ressource { get; protected set; }

  public int RessourceMax { get; protected set; } = 50; //parceque ça pourra etre modifié avec le niveau, des objets, ou de l'equipement éventuel.
  public int CoutAttaqueLourde { get; protected set; } = 10;
  public int RegenValeur { get; protected set; } = 5;

  private De _deDegats;
  private De _critique;

  public bool IsAlive
  {
    get { return PvActuels > 0; }
  }

  public bool AtkLourdeOk
  {
    get { return Ressource >= CoutAttaqueLourde; }
  }

  protected virtual double MultiplicateurDegats => 1.0;
  protected virtual double MultiplicateurDegatsRecus => 1.0;

  #endregion

  #region Constructeurs

  //Constructeurs

  protected Combattant(int maxPv, string pseudo)
  {
    MaxPv = maxPv;
    PvActuels = maxPv;
    Pseudo = pseudo;
    Ressource = RessourceMax;
    _deDegats = new De(1, 8);
    _critique = new De(1, 20);
  }

  #endregion

  #region Methodes

  #region Attaquer

  public int Attaquer(ICombattant cible)
  {
    if (cible == null || !IsAlive)
      return 0;

    int degats = AttaqueBase + _deDegats.Lancer();
    int jetCritique = _critique.Lancer();

    int degatsFinaux = degats;

    if (jetCritique == 20)
    {
      degatsFinaux = degatsFinaux * 2;
    }

    cible.RecevoirDegats(degatsFinaux);

    return degatsFinaux;
  }

  #endregion

  #region AttaqueLourde

  public int AttaqueLourde(ICombattant cible)
  {
    if (cible == null || !IsAlive || !AtkLourdeOk)
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
    Ressource -= CoutAttaqueLourde;
    return degatsFinaux;
  }

  #endregion

  #region RecevoirDegats

  public virtual void RecevoirDegats(int degats)
  {
    if (PvActuels <= 0)
      return;

    int degatsFinaux = degats;
    
    degatsFinaux = (int)(degats * MultiplicateurDegatsRecus);
    

    PvActuels -= degatsFinaux;

    if (PvActuels < 0)
      PvActuels = 0;
  }

  #endregion

  #region RegenRessource

  public virtual void RegenRessource()
  {
    if (Ressource >= RessourceMax)
    {
      return;
    }

    Ressource += RegenValeur;
    if (Ressource > RessourceMax)
    {
      Ressource = RessourceMax;
    }
  }

  #endregion

  #region ApresAttaque

  protected virtual void ApresAttaque()
  {
  }

  #endregion

  #endregion
}