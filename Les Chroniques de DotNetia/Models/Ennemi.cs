using Les_Chroniques_de_DotNetia.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Les_Chroniques_de_DotNetia.Models;

internal class Ennemi : Combattant
{
  //Prop

  //Constructeurs

  internal Ennemi(int maxPv, string pseudo) : base(maxPv, pseudo)
  {
  }
  
  //Methodes
  
  protected override bool PeutAttaquerLourd()
  {
    return true;
  }
}