using System;
using System.Collections.Generic;
using System.Text;

namespace Les_Chroniques_de_DotNetia.Interfaces;

internal interface ICombattant
{
    public string Pseudo { get; }
    public int MaxPv { get; }
    public int PvActuels { get; }

    public bool IsAlive { get; }


    int Attaquer(ICible cible);
    
}
