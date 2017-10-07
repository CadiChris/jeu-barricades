using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class PlateauTests
  {
    private const int UN_COUP = 1;
    private static Pion Pion(Couleur couleur, int x, int y) => new Pion(couleur, new Position(x, y));

    [TestMethod]
    public void MetLePlateauEnPlace()
    {
      var plateau = new Plateau();
      // Bleu
      plateau.AssertPion(Bleu, 0, 0);
      plateau.AssertPion(Bleu, 0, 1);
      plateau.AssertPion(Bleu, 1, 0);
      plateau.AssertPion(Bleu, 1, 1);
      // Vert
      plateau.AssertPion(Vert, 0, 2);
      plateau.AssertPion(Vert, 0, 3);
      plateau.AssertPion(Vert, 1, 2);
      plateau.AssertPion(Vert, 1, 3);
      // Jaune
      plateau.AssertPion(Jaune, 0, 4);
      plateau.AssertPion(Jaune, 0, 5);
      plateau.AssertPion(Jaune, 1, 4);
      plateau.AssertPion(Jaune, 1, 5);
      // Rouge
      plateau.AssertPion(Rouge, 0, 6);
      plateau.AssertPion(Rouge, 0, 7);
      plateau.AssertPion(Rouge, 1, 6);
      plateau.AssertPion(Rouge, 1, 7);

      foreach (var y in Range(0, 9))
        IsTrue(plateau[new Position(2, y)].EstVide);

      AreEqual(Pion(Barricade, 3, 3), plateau[new Position(3, 3)].Pion);
    }

    [TestMethod]
    public void PeutPrevoirUnDeplacementSimple()
    {
      var plateau = new Plateau();
      var position = new Position(1, 0);
      var trajets = plateau.TrajetsPour(position, 1);

      AreEqual(1, trajets.Count());
      AreEqual(2, trajets.First().Etapes.Count);
      AreEqual(new Position(2, 1), trajets.First().Arrivee);
    }

    [TestMethod]
    public void PeutDeplacerUnPion()
    {
      var plateau = new Plateau();
      var departDuBleu = new Position(1, 0);
      var trajetsUnique = plateau.TrajetsPour(departDuBleu, UN_COUP).First();

      plateau.Deplacer(plateau.PionSur(departDuBleu), trajetsUnique);

      AreEqual(Pion(Bleu, 2, 1), plateau.PionSur(new Position(2, 1)));
      IsNull(plateau[departDuBleu].Pion);
    }
  }

  public static class PlateauTestsExtensions
  {
    public static void AssertPion(this Plateau plateau, Couleur couleurAttendue, int x, int y)
    {
      var pionAttendu = new Pion(couleurAttendue, new Position(x, y));
      AreEqual(pionAttendu, plateau.PionSur(new Position(x, y)));
    }
  }
}