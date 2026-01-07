// ReSharper disable All
namespace Les_Chroniques_de_DotNetia.Utils;

public class De
{

  //champs
  
  private static readonly Random _random = new Random(); //random
  //prop

  public int Minimum { get; protected init; }
  public int Maximum { get; protected init; }

  //Constructeurs

  public De(int minimum, int maximum)
  {
    Minimum = minimum;
    Maximum = maximum;
  }
  
  //Methodes

  public int Lancer()
  {
    return _random.Next(Minimum, Maximum+ 1);  
  }
}