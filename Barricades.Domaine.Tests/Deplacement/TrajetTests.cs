using Barricades.Domaine.Deplacement;
using Barricades.Domaine.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests.Deplacement
{
  [TestClass]
  public class TrajetTests
  {
    [TestMethod]
    public void PeutContinuerAvecUnAutreTrajet()
    {
      var trajetA = new Trajet(false, null, Position.P("0,0"), Position.P("0,1"));
      var trajetB = new Trajet(Position.P("0,2"));

      var trajetComplet = trajetA.ContinuerAvec(trajetB);

      trajetComplet.AssertLaComposition(Position.P("0,0"), Position.P("0,1"), Position.P("0,2"));
    }

    [TestMethod]
    public void SaitSilPeutAtteindreUneDestination()
    {
      Assert.IsTrue(new Trajet(Position.P("0,0")).MeneA(Position.P("0,0")));
      Assert.IsFalse(new Trajet(Position.P("0,0")).MeneA(Position.P("1,0")));

      var trajetBloque = new Trajet(estBloque:true, prise:null, etapes: Position.P("0,0"));
      Assert.IsFalse(trajetBloque.MeneA(Position.P("0,0")));
    }
  }
}