using Microsoft.VisualStudio.TestTools.UnitTesting;
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
      AreEqual(Pion(Bleu, 0, 0), plateau[new LigneDeTrous(0), 0].Pion);
      AreEqual(Pion(Bleu, 0, 1), plateau[new LigneDeTrous(0), 1].Pion);
      AreEqual(Pion(Bleu, 1, 0), plateau[new LigneDeTrous(1), 0].Pion);
      AreEqual(Pion(Bleu, 1, 1), plateau[new LigneDeTrous(1), 1].Pion);
      AreEqual(Pion(Vert, 0, 2), plateau[new LigneDeTrous(0), 2].Pion);
      AreEqual(Pion(Vert, 0, 3), plateau[new LigneDeTrous(0), 3].Pion);
      AreEqual(Pion(Vert, 1, 2), plateau[new LigneDeTrous(1), 2].Pion);
      AreEqual(Pion(Vert, 1, 3), plateau[new LigneDeTrous(1), 3].Pion);
      AreEqual(Pion(Jaune, 0, 4), plateau[new LigneDeTrous(0), 4].Pion);
      AreEqual(Pion(Jaune, 0, 5), plateau[new LigneDeTrous(0), 5].Pion);
      AreEqual(Pion(Jaune, 1, 4), plateau[new LigneDeTrous(1), 4].Pion);
      AreEqual(Pion(Jaune, 1, 5), plateau[new LigneDeTrous(1), 5].Pion);
      AreEqual(Pion(Rouge, 0, 6), plateau[new LigneDeTrous(0), 6].Pion);
      AreEqual(Pion(Rouge, 0, 7), plateau[new LigneDeTrous(0), 7].Pion);
      AreEqual(Pion(Rouge, 1, 6), plateau[new LigneDeTrous(1), 6].Pion);
      AreEqual(Pion(Rouge, 1, 7), plateau[new LigneDeTrous(1), 7].Pion);
    }

    private static Pion Pion(Couleur couleur, int x, int y)
    {
      var pion = new Pion(couleur);
      pion.PoserSur(new Trou(new LigneDeTrous(x), y));
      return pion;
    }
  }
}