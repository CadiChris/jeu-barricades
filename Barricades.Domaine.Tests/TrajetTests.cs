﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Barricades.Domaine.Position;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class TrajetTests
  {
    [TestMethod]
    public void PeutContinuerAvecUnAutreTrajet()
    {
      var trajetA = new Trajet();
      trajetA.NouvelleEtape(P("0,0"));
      trajetA.NouvelleEtape(P("0,1"));

      var trajetB = new Trajet();
      trajetB.NouvelleEtape(P("0,2"));

      var trajetComplet = trajetA.ContinuerAvec(trajetB);

      CollectionAssert.AreEqual(
        new List<Position> { P("0,0"), P("0,1"), P("0,2") },
        trajetComplet.Etapes);
    }
  }
}