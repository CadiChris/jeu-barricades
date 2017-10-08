using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.UI.Tests
{
  [TestClass]
  public class DeTests
  {
    [TestMethod]
    public void DonneUnChiffre()
    {
      var chiffre = De.Lancer();
      IsTrue(1 <= chiffre && chiffre <= 6);
    }
  }
}