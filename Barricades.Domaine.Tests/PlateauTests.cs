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
      AreEqual(Pion(Bleu, 0, 0), plateau.PionSur(new Position(0, 0)));
      AreEqual(Pion(Bleu, 0, 1), plateau.PionSur(new Position(0, 1)));
      AreEqual(Pion(Bleu, 1, 0), plateau.PionSur(new Position(1, 0)));
      AreEqual(Pion(Bleu, 1, 1), plateau.PionSur(new Position(1, 1)));
      AreEqual(Pion(Vert, 0, 2), plateau.PionSur(new Position(0, 2)));
      AreEqual(Pion(Vert, 0, 3), plateau.PionSur(new Position(0, 3)));
      AreEqual(Pion(Vert, 1, 2), plateau.PionSur(new Position(1, 2)));
      AreEqual(Pion(Vert, 1, 3), plateau.PionSur(new Position(1, 3)));
      AreEqual(Pion(Jaune, 0, 4), plateau.PionSur(new Position(0, 4)));
      AreEqual(Pion(Jaune, 0, 5), plateau.PionSur(new Position(0, 5)));
      AreEqual(Pion(Jaune, 1, 4), plateau.PionSur(new Position(1, 4)));
      AreEqual(Pion(Jaune, 1, 5), plateau.PionSur(new Position(1, 5)));
      AreEqual(Pion(Rouge, 0, 6), plateau.PionSur(new Position(0, 6)));
      AreEqual(Pion(Rouge, 0, 7), plateau.PionSur(new Position(0, 7)));
      AreEqual(Pion(Rouge, 1, 6), plateau.PionSur(new Position(1, 6)));
      AreEqual(Pion(Rouge, 1, 7), plateau.PionSur(new Position(1, 7)));

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

      AreEqual(1, trajets.Count);
      AreEqual(2, trajets[0].Positions.Count);
      AreEqual(new Position(2, 1), trajets[0].Arrivee);
    }

    [TestMethod]
    public void PeutDeplacerUnPion()
    {
      var plateau = new Plateau();
      var departDuBleu = new Position(1, 0);
      var trajetsUnique = plateau.TrajetsPour(departDuBleu, UN_COUP)[0];

      plateau.Deplacer(plateau.PionSur(departDuBleu), trajetsUnique);

      AreEqual(Pion(Bleu, 2, 1), plateau.PionSur(new Position(2, 1)));
      IsNull(plateau[departDuBleu].Pion);
    }
  }
}