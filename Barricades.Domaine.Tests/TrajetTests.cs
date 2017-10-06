using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class TrajetTests
  {
    [TestMethod]
    public void PeutContinuer()
    {
      var trajetA = new Trajet();
      trajetA.NouvelleEtape(new Position(0, 0));
      trajetA.NouvelleEtape(new Position(0, 1));

      var trajetB = new Trajet();
      trajetB.NouvelleEtape(new Position(0, 2));

      var trajetComplet = trajetA.ContinuerAvec(trajetB);

      AreEqual(3, trajetComplet.Etapes.Count);
    }

    [TestMethod]
    public void PeutCreerDesFourchettes()
    {
      Func<Position> centre = () => new Position(10,10);
      Func<Position> gauche = () => new Position(0,0);
      Func<Position> droite = () => new Position(20,20);

      var debut = new Trajet();
      debut.NouvelleEtape(centre());

      var virageGauche = new Trajet();
      virageGauche.NouvelleEtape(gauche());
      
      var virageDroite = new Trajet();
      virageDroite.NouvelleEtape(droite());

      var trajets = debut.ContinuerAvec(virageGauche, virageDroite).ToList();
      AreEqual(2, trajets.Count());
      AreEqual(centre(), trajets[0].Depart);
      AreEqual(gauche(), trajets[0].Arrivee);
      AreEqual(centre(), trajets[1].Depart);
      AreEqual(droite(), trajets[1].Arrivee);
    }
  }
}