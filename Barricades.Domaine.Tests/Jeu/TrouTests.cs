using Barricades.Domaine.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests.Jeu
{
  [TestClass]
  public class TrouTests
  {
    [TestMethod]
    public void Egalite()
    {
      Assert.AreEqual(new Trou(Position.P("0,0")), new Trou(Position.P("0,0")));
      Assert.AreNotEqual(new Trou(Position.P("0,0")), new Trou(Position.P("0,1")));
    }
  }
}