using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Barricades.Domaine.Couleur;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class PlateauTests
  {
    [TestMethod]
    public void MetLePlateauEnPlace()
    {
      var plateau = new Plateau();
      Assert.AreEqual(new Pion(Bleu), plateau[new LigneDeTrous(0), 0].Pion);
      Assert.AreEqual(new Pion(Bleu), plateau[new LigneDeTrous(0), 1].Pion);
      Assert.AreEqual(new Pion(Bleu), plateau[new LigneDeTrous(1), 0].Pion);
      Assert.AreEqual(new Pion(Bleu), plateau[new LigneDeTrous(1), 1].Pion);
    }
  }
}