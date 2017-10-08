using Barricades.Domaine.Jeu;

namespace Barricades.Domaine.Tests.Jeu
{
  public static class TrouTestExtensions
  {
    public static Trou TrousQuiSeSuivent(this int combien, int ligne, int colonne = 0)
    {
      var position = Position.P($"{ligne},{colonne}");

      var finDuParcours = combien - 1 == 0;
      return finDuParcours 
        ? new Trou(position)
        : new Trou(position, (combien - 1).TrousQuiSeSuivent(ligne, colonne+1));
    }
  }
}