using Les_Chroniques_de_DotNetia.Models.Ennemis;

namespace Les_Chroniques_de_DotNetia.Models.Zones;

internal class Foret : Zone
{
 public Foret() : base("La Forêt du Ça-Marchait-Hier", "Une Forêt sombre et peu rassurante")
 {
  EnnemisPossibles.Add(() => new Dragonnet());
  EnnemisPossibles.Add(() => new Loup());
  EnnemisPossibles.Add(() => new Sanglier());
 } 
}