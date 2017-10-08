using System.Linq;
using Barricades.Domaine.Deplacement;
using Barricades.Domaine.Jeu;
using Barricades.Domaine.Tests.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests.Deplacement
{
  [TestClass]
  public class GpsTests
  {
    [TestMethod]
    public void VaToutDroit()
    {
      var gps = new Gps(4.TrousQuiSeSuivent(ligne: 0));
      var trajets = gps.TrajetsPour(3).ToList();

      Assert.AreEqual(1, trajets.Count);
      trajets.Single().AssertLaComposition(Position.P("0,0"), Position.P("0,1"), Position.P("0,2"), Position.P("0,3"));
    }

    [TestMethod]
    public void ProposePlusieursTrajetsEnCasDEmbranchements()
    {
      var _3_1 = new Trou(Position.P("3,1"));
      var _2_3 = new Trou(Position.P("2,3"));
      var _2_2 = new Trou(Position.P("2,2"), _2_3, _3_1);
      var _2_1 = new Trou(Position.P("2,1"), _2_2);

      var gps = new Gps(_2_1);
      var trajets = gps.TrajetsPour(2).ToList();
      Assert.AreEqual(2, trajets.Count);

      trajets[0].AssertLaComposition(Position.P("2,1"), Position.P("2,2"), Position.P("2,3"));
      trajets[1].AssertLaComposition(Position.P("2,1"), Position.P("2,2"), Position.P("3,1"));
    }

    [TestMethod]
    public void DetecteUnBlocage()
    {
      var depart = 4.TrousQuiSeSuivent(0);
      var _0_1 = depart.Successeurs[0];
      _0_1.Poser(new Pion(Couleur.Bleu, Position.P("0,1")));

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(6).ToList();

      Assert.AreEqual(1, trajets.Count);
      Assert.IsTrue(trajets.Single().EstBloque);
    }

    [TestMethod]
    public void DetecteUnePriseDePion()
    {
      var depart = 4.TrousQuiSeSuivent(0);
      var _0_1 = depart.Successeurs[0];
      var _0_2 = _0_1.Successeurs[0];
      _0_2.Poser(new Pion(Couleur.Bleu, Position.P("0,2")));

      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(2).ToList();

      Assert.AreEqual(new Pion(Couleur.Bleu, Position.P("0,2")), trajets.Single().Prise);
    }

    [TestMethod]
    public void NePrendPasDePionDeMemeCouleur()
    {
      var departBleu = new Trou(Position.P("0,0"));
      var suivant = new Trou(Position.P("0,1"));
      var arriveeBleue = new Trou(Position.P("0,2"));

      departBleu.Poser(new Pion(Couleur.Bleu, Position.P("0,0")));
      arriveeBleue.Poser(new Pion(Couleur.Bleu, Position.P("0,2")));

      departBleu.RemplacerSuccesseurs(suivant);
      suivant.RemplacerSuccesseurs(arriveeBleue);

      var trajets = new Gps(departBleu).TrajetsPour(2);
      Assert.AreEqual(true, trajets.Single().EstBloque);
    }

    [TestMethod]
    public void NeRebroussePasChemin()
    {
      var depart = 2.TrousQuiSeSuivent(0);
      var _0_0 = depart;
      var _0_1 = _0_0.Successeurs[0];
      _0_1.RemplacerSuccesseurs(_0_0);


      var gps = new Gps(depart);
      var trajets = gps.TrajetsPour(2).ToList();

      Assert.AreEqual(1, trajets.Count);
      Assert.AreEqual(true, trajets.Single().EstBloque);
    }
  }
}