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

    [TestMethod]
    public void ProposeUneFourchette()
    {
      var _3_1 = new Trou(P("3,1"));
      var _2_3 = new Trou(P("2,3"));
      var _2_2 = new Trou(P("2,2"), _2_3, _3_1);

      var gps = new Gps(_2_2);
      var trajets = gps.TrajetsPour(1).ToList();

      AreEqual(2, trajets.Count);
      var trajetVers_2_3 = trajets[0];
      CollectionAssert.AreEqual(
        new List<Position> {P("2,2"), P("2,3")},
        trajetVers_2_3.Etapes);

      var trajetVers_3_1 = trajets[1];
      CollectionAssert.AreEqual(
        new List<Position> { P("2,2"), P("3,1")},
        trajetVers_3_1.Etapes,
        $"{trajetVers_3_1}");
    }
  }

  public static class TrouExtensions
  {
    public static Trou TrousQuiSeSuivent(this int combien, int ligne, int colonne = 0)
    {
      var position = P($"{ligne},{colonne}");

      var finDuParcours = combien - 1 == 0;
      return finDuParcours 
        ? new Trou(position)
        : new Trou(position, (combien - 1).TrousQuiSeSuivent(ligne, colonne+1));
    }
  }
}