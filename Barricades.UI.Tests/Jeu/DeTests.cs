using Barricades.UI.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.UI.Tests.Jeu
{
  [TestClass]
  public class DeTests
  {
    [TestMethod]
    public void DonneUnChiffre()
    {
      var chiffre = De.Lancer();
      Assert.IsTrue(1 <= chiffre && chiffre <= 6);
    }
  }
}