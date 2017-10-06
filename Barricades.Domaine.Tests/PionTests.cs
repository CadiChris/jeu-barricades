using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class PionTests
  {
    [TestMethod]
    public void PeutPrevoirUnDeplacementSimple()
    {
      var plateau = new Plateau();
      var bleu = plateau[new Position(1, 0)].Pion;

      var trajets = bleu.TrajetsPour(1);

      AreEqual(1, trajets.Count);
      AreEqual(1, trajets[0].Trous.Count);
      AreEqual(new Trou(new Position(2, 1)), trajets[0].Trous[0]);
    }

    [TestMethod]
    public void PeutDeplacerUnPion()
    {
      var plateau = new Plateau();
      var bleu = plateau[new Position(1, 0)].Pion;
      var trajets = bleu.TrajetsPour(1);

      bleu.Emprunter(trajets[0]);

      AreEqual(bleu, plateau[new Position(2, 1)].Pion);
      IsNull(plateau[new Position(1, 0)].Pion);
    }
  }
}