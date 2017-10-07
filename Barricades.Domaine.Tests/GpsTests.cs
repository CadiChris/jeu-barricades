using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Barricades.Domaine.Position;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class GpsTests
  {
    [TestMethod]
    public void VaToutDroit()
    {
      var arrivee = new Trou(P("0, 2"), new Trou(P("0, 3")));
      var milieu = new Trou(P("0, 1"), arrivee);
      var depart = new Trou(P("0, 0"), milieu);

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(3);
      AreEqual(1, trajets.Count());

      var trajetUnique = trajets.First();

      CollectionAssert.AreEqual(
        new List<Position> {P("0,0"), P("0,1"), P("0,2"), P("0,3")},
        trajetUnique.Etapes);
    }
  }
}