﻿using System.Collections.Generic;
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
      trajets.Single().AssertLaComposition(P("0,0"), P("0,1"), P("0,2"), P("0,3"));
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
      trajetVers_2_3.AssertLaComposition(P("2,2"), P("2,3"));

      var trajetVers_3_1 = trajets[1];
      trajetVers_3_1.AssertLaComposition(P("2,2"), P("3,1"));
    }
  }
}