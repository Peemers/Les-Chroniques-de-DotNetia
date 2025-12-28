using Les_Chroniques_de_DotNetia.Interfaces;

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Combattant : ICombattant
{
    
    //Prop

    public string Pseudo { get; protected init; }
    public int MaxPv { get; protected set; }
    public int PvActuels { get; protected set; }
    public int AttaqueBase { get; protected init; } = 2;
    public int Ressource { get; protected set; }
    public int CoutAttaqueLourde { get; protected set; } = 10;

    public bool IsAlive
    {
        get { return PvActuels > 0; }
    }

    //Constructeurs

    protected Combattant(int maxPv, string pseudo)
    {
        MaxPv = maxPv;
        PvActuels = maxPv;
        Pseudo = pseudo;
        Ressource = 50;
    }

    //Methodes

    public void Attaquer(ICombattant cible) 
    {
        if (cible == null)
            return;

        if (!IsAlive)
            return;

        int degats = AttaqueBase;
        cible.RecevoirDegats(degats);
    }

    public void AttaqueLourde(ICombattant cible)
    {
        if (cible == null)
        {
            return;
        }
        if (!IsAlive)
        {
            return;
        }
        if (Ressource >= CoutAttaqueLourde)
        {
            int degats = AttaqueBase + AttaqueBase / 2;
            cible.RecevoirDegats(degats);
            Ressource = Ressource - CoutAttaqueLourde;
        }

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
}