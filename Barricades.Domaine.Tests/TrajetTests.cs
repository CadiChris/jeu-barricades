using System.Collections.Generic;
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
      var trajetA = new Trajet(false, null, P("0,0"), P("0,1"));
      var trajetB = new Trajet(P("0,2"));

      var trajetComplet = trajetA.ContinuerAvec(trajetB);

      trajetComplet.AssertLaComposition(P("0,0"), P("0,1"), P("0,2"));
    }

    [TestMethod]
    public void SaitSilPeutAtteindreUneDestination()
    {
      IsTrue(new Trajet(P("0,0")).MeneA(P("0,0")));
      IsFalse(new Trajet(P("0,0")).MeneA(P("1,0")));

      var trajetBloque = new Trajet(estBloque:true, prise:null, etapes: P("0,0"));
      IsFalse(trajetBloque.MeneA(P("0,0")));
    }
  }
}