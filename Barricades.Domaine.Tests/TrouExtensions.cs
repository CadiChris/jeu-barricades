﻿namespace Barricades.Domaine.Tests
{
  public static class TrouExtensions
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