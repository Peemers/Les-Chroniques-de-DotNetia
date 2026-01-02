using Les_Chroniques_de_DotNetia.Models;

namespace Les_Chroniques_de_DotNetia.Models;

internal class GardienEngourdi : Ennemi
{
  //prop

  private bool _protectionIntacte = true;

  private double ReductionDegats
  {
    get { return _protectionIntacte ? 0.25 : 1.0; } // si pas reçu de coup alors -75 % de degats
  }

  //constructeur

  internal GardienEngourdi(string pseudo) : base("Gardien Engourdi")
  {
  }

  //override
  protected override double MultiplicateurDegatsRecus => ReductionDegats;

  protected override int BasePv => 550;


  protected override void ApresReceptionDegats()
  {
    _protectionIntacte = false;
  }
}