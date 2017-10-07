using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Int32;
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

    public int[] P(string coordonnees)
    {
      coordonnees = coordonnees.Replace(" ", "");
      return new[] {Parse(coordonnees.Split(',')[0]), Parse(coordonnees.Split(',')[1])};
    }

    [TestMethod]
    public void MetLePlateauEnPlace()
    {
      var plateau = new Plateau();
      // Bleu
      plateau.AssertPions(Bleu, P("0,0"), P("0,1"), P("1,0"), P("1,1"));
      // Vert
      plateau.AssertPions(Vert, P("0,2"), P("0,3"), P("1,2"), P("1,3"));
      // Jaune
      plateau.AssertPions(Jaune, P("0,4"), P("0,5"), P("1,4"), P("1,5"));
      // Rouge
      plateau.AssertPions(Rouge, P("0,6"), P("0,7"), P("1,6"),P("1,7"));

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
    public static void AssertPions(this Plateau plateau, Couleur couleurAttendue, params int[] [] positions)
    {
      foreach (var position in positions)
      {
        var pionAttendu = new Pion(couleurAttendue, new Position(position[0], position[1]));
        AreEqual(pionAttendu, plateau.PionSur(new Position(position[0], position[1])));
      }
    }
  }
}