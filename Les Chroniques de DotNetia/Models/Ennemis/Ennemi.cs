using Les_Chroniques_de_DotNetia.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Les_Chroniques_de_DotNetia.Models.Ennemis;

internal abstract class Ennemi : Combattant
{
  //Prop

  //Constructeurs

  internal Ennemi(string pseudo) : base(pseudo)
  {
  }

  //Methodes

}