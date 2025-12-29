// ReSharper disable All
namespace Les_Chroniques_de_DotNetia.Utils;

public class De
{

  //random
  
  private static readonly Random _random = new Random();
  
  
  //prop

  public int Minimum { get; protected init; } = 1;
  public int Maximum { get; protected init; } = 6;

  //Constructeurs

  public De(int minimum, int maximum)
  {
    Minimum = minimum;
    Maximum = maximum;
  }

  public int Lancer()
  {
    return _random.Next(Maximum - Minimum + 1);  
  }
}