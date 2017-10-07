using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Barricades.Domaine.Position;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class TrajetTests
  {
    [TestMethod]
    public void PeutContinuerAvecUnAutreTrajet()
    {
      var trajetA = new Trajet(false, false, P("0,0"), P("0,1"));
      var trajetB = new Trajet(P("0,2"));

      var trajetComplet = trajetA.ContinuerAvec(trajetB);

      trajetComplet.AssertLaComposition(P("0,0"), P("0,1"), P("0,2"));
    }
  }
}