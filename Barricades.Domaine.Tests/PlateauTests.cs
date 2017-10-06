using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class PlateauTests
  {
    [TestMethod]
    public void MetLePlateauEnPlace()
    {
      var plateau = new Plateau();
      AreEqual(Pion(Bleu, 0, 0), plateau[new Position(0, 0)].Pion);
      AreEqual(Pion(Bleu, 0, 1), plateau[new Position(0, 1)].Pion);
      AreEqual(Pion(Bleu, 1, 0), plateau[new Position(1, 0)].Pion);
      AreEqual(Pion(Bleu, 1, 1), plateau[new Position(1, 1)].Pion);
      AreEqual(Pion(Vert, 0, 2), plateau[new Position(0, 2)].Pion);
      AreEqual(Pion(Vert, 0, 3), plateau[new Position(0, 3)].Pion);
      AreEqual(Pion(Vert, 1, 2), plateau[new Position(1, 2)].Pion);
      AreEqual(Pion(Vert, 1, 3), plateau[new Position(1, 3)].Pion);
      AreEqual(Pion(Jaune, 0, 4), plateau[new Position(0, 4)].Pion);
      AreEqual(Pion(Jaune, 0, 5), plateau[new Position(0, 5)].Pion);
      AreEqual(Pion(Jaune, 1, 4), plateau[new Position(1, 4)].Pion);
      AreEqual(Pion(Jaune, 1, 5), plateau[new Position(1, 5)].Pion);
      AreEqual(Pion(Rouge, 0, 6), plateau[new Position(0, 6)].Pion);
      AreEqual(Pion(Rouge, 0, 7), plateau[new Position(0, 7)].Pion);
      AreEqual(Pion(Rouge, 1, 6), plateau[new Position(1, 6)].Pion);
      AreEqual(Pion(Rouge, 1, 7), plateau[new Position(1, 7)].Pion);

      foreach (var y in Range(0, 9))
        IsTrue(plateau[new Position(2, y)].EstVide);

      AreEqual(Pion(Barricade, 3, 3), plateau[new Position(3, 3)].Pion);
    }

    private static Pion Pion(Couleur couleur, int x, int y)
    {
      var pion = new Pion(couleur);
      pion.PoserSur(new Trou(new Position(x, y)));
      return pion;
    }
  }
}