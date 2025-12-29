using Les_Chroniques_de_DotNetia.Interfaces;
using Les_Chroniques_de_DotNetia.Utils;

// ReSharper disable All

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Combattant : ICombattant
{
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

  public bool IsAlive
  {
    get { return PvActuels > 0; }
  }

  public bool AtkLourdeOk
  {
    get { return Ressource >= CoutAttaqueLourde; }
  }

  //Constructeurs

  protected Combattant(int maxPv, string pseudo)
  {
    MaxPv = maxPv;
    PvActuels = maxPv;
    Pseudo = pseudo;
    Ressource = RessourceMax;
    _deDegats = new De(1, 6);
  }

  //Methodes

  public void Attaquer(ICombattant cible)
  {
    if (cible == null)
      return;

    if (!IsAlive)
      return;

    int degats = AttaqueBase + _deDegats.Lancer();
    cible.RecevoirDegats(degats);
  }
  public void AttaqueLourde(ICombattant cible)
  {
    if (cible == null || !IsAlive || !AtkLourdeOk)
      return;

    int atk = AttaqueBase + _deDegats.Lancer();
    int degats = atk + atk / 2;
    cible.RecevoirDegats(degats);
    Ressource -= CoutAttaqueLourde;
  }

  public virtual void RecevoirDegats(int degats)
  {
    if (PvActuels <= 0)
    {
      return;
    }

    PvActuels -= degats;

    if (PvActuels < 0)
    {
      PvActuels = 0;
    }
  }

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
}