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
      var gps = new Gps(4.TrousQuiSeSuivent(ligne: 0));
      var trajets = gps.TrajetsPour(3).ToList();

      AreEqual(1, trajets.Count);
      CollectionAssert.AreEqual(
        new List<Position> { P("0,0"), P("0,1"), P("0,2"), P("0,3") },
        trajets.First().Etapes);
    }
  }

  public static class TrouExtensions
  {
    public static Trou TrousQuiSeSuivent(this int combien, int ligne, int colonne = 0)
    {
      var position = P($"{ligne},{colonne}");

      var finDuParcours = combien - 1 == 0;
      return finDuParcours ? new Trou(position) : new Trou(position, (combien - 1).TrousQuiSeSuivent(ligne, colonne+1));
    }
  }
}