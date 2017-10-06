using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class GpsTests
  {
    [TestMethod]
    public void VaToutDroit()
    {
      var arrivee = new Trou(new Position(0, 2), new Trou(new Position(0, 3)));
      var milieu = new Trou(new Position(0, 1), arrivee);
      var depart = new Trou(new Position(0, 0), milieu);

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(3);
      AreEqual(1, trajets.Count());

      var trajetUnique = trajets.First();
      var nombreDeTrous = 4;
      AreEqual(nombreDeTrous, trajetUnique.Etapes.Count);
    }
  }
}