using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class GpsTests
  {
    [TestMethod]
    public void VaToutDroit()
    {
      var arrivee = new Trou(new Position(0, 2));
      var milieu = new Trou(new Position(0, 1), arrivee);
      var depart = new Trou(new Position(0, 0), milieu);

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(1);
      Assert.AreEqual(1, trajets.Count);
    }
  }
}