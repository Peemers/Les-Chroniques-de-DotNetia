namespace Les_Chroniques_de_DotNetia.Models.Zones;
using Les_Chroniques_de_DotNetia.Models.Ennemis;

internal class Desert : Zone
{
  //constructeur

  internal Desert() : base("Le Désert Sandboxé", "Un désert immense, chaud, sec, grouillant de monstres plus grands que la normale ")
  {
    EnnemisPossibles.Add(() => new SerpentGéant());
    EnnemisPossibles.Add(() => new LezardVenimeux());
    EnnemisPossibles.Add(() => new ScorpionGéant());
  }
}