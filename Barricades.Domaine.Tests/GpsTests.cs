using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Barricades.Domaine.Couleur;
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
    public void ProposePlusieursTrajetsEnCasDEmbranchements()
    {
      var _3_1 = new Trou(P("3,1"));
      var _2_3 = new Trou(P("2,3"));
      var _2_2 = new Trou(P("2,2"), _2_3, _3_1);
      var _2_1 = new Trou(P("2,1"), _2_2);

      var gps = new Gps(_2_1);
      var trajets = gps.TrajetsPour(2).ToList();
      AreEqual(2, trajets.Count);

      trajets[0].AssertLaComposition(P("2,1"), P("2,2"), P("2,3"));
      trajets[1].AssertLaComposition(P("2,1"), P("2,2"), P("3,1"));
    }

    [TestMethod]
    public void DetecteUnBlocage()
    {
      var depart = 4.TrousQuiSeSuivent(0);
      var _0_1 = depart.Successeurs[0];
      var _0_2 = _0_1.Successeurs[0];
      _0_1.Successeurs[0] = _0_2.Poser(new Pion(Bleu, P("0,2")));

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(6).ToList();

      AreEqual(1, trajets.Count);
      AreEqual(2, trajets.Single().Etapes.Count);
      IsTrue(trajets.Single().EstBloque);
    }

    [TestMethod]
    public void DetecteUnePriseDePion()
    {
      var depart = 4.TrousQuiSeSuivent(0);
      var _0_1 = depart.Successeurs[0];
      var _0_2 = _0_1.Successeurs[0];
      _0_1.Successeurs[0] = _0_2.Poser(new Pion(Bleu, P("0,2")));

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(2).ToList();
      IsTrue(trajets.Single().PrendUnPion);
    }
  }
}