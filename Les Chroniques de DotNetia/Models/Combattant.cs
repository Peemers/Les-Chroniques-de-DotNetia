using Les_Chroniques_de_DotNetia.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Les_Chroniques_de_DotNetia.Models;

internal abstract class Combattant : ICombattant
{
    
    //Prop

    public string Name { get; protected init; }
    public int MaxPv { get; protected set; }
    public int PvActuels { get; protected set; }

    public bool IsAlive
    {
        get { return PvActuels > 0; }
    }

    //Constructeurs

    protected Combattant(int maxPv, string name)
    {
        MaxPv = maxPv;
        PvActuels = maxPv;
        Name = name;
    }

    //Methodes

    public void Attaquer(ICombattant cible) //ici je dirais une implémentation commune car il s'agit de l'attaque de base ?
    {
        if (cible == null)
            return;

        if (!IsAlive)
            return;

        int degats = 2;
        cible.RecevoirDegats(degats);
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
