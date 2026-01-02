using Les_Chroniques_de_DotNetia.Models.Ennemis;

namespace Les_Chroniques_de_DotNetia.Models.Zones;

internal class Foret : Zone
{
 public Foret() : base("Une forêt sombre et peu rassurante")
 {
  EnnemisPossibles.Add((() => new Dragonnet()));
 } 
}