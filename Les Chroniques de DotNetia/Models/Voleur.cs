namespace Les_Chroniques_de_DotNetia.Models;

internal class Voleur : Joueur
{
  //!PROP
  //?Ressource

  public int Energie { get; protected set; }
  public int EnergieMax { get; } = 100;
  public int PtCombo { get; protected set; } = 0;
  public int EnergieOut { get; } = 10;
  public int EnergieIn { get; } = 5;

  public bool EstConcentré => PtCombo == 5;

  public int BonusDegats
  {
    get { return EstConcentré ? 2 : 1; }
  }


  //public bool EstInvisible { get; protected set; } //Pour plus tard

  //Constructeur

  public Voleur(string pseudo) : base(450, pseudo)
  {
    Energie = EnergieMax;
  }
  
  //!METHODES
  //?Fonctionnement

  protected void ResetCombo()
  {
    PtCombo = 0;
  }
  
  
  //?Override

  protected override void ApresAttaque()
  {
    Energie += EnergieIn;
    if (Energie > EnergieMax)
      Energie = EnergieMax;
  }

  protected override void ApresAttaqueLourde()
  {
    Energie -= EnergieOut;
    PtCombo++;
    if (Energie < 0)
      Energie = 0;

    if (Energie > EnergieMax)
      Energie = EnergieMax;
    
    if(PtCombo >= 5)
    {
      ResetCombo();
    }
  }

  protected override bool PeutAttaquerLourd()
  {
    return Energie >= EnergieOut;
  }

  protected override double MultiplicateurDegats => BonusDegats;
}