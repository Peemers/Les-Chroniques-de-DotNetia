using System.ComponentModel.DataAnnotations.Schema;
using Les_Chroniques_de_DotNetia.Models.Ennemis;

namespace Les_Chroniques_de_DotNetia.Models.Zones;

internal abstract class Zone
{
  
  //porp
  public string Nom { get; }
  public string Description { get; }

  protected List<Func<Ennemi>> EnnemisPossibles;  
  //constructeur
  
  protected Zone(string nom, string description)
  {
    Nom = nom;
    Description = description;
    EnnemisPossibles = new();
  }
  
  //methodes

  public Ennemi GenererEnnemi()
  {
    int index = Random.Shared.Next(EnnemisPossibles.Count);
    return EnnemisPossibles[index]();
  }
}