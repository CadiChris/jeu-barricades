using Microsoft.VisualStudio.TestTools.UnitTesting;
using Barricades.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Barricades.Domaine.Tests
{
  [TestClass]
  public class PionTests
  {
    [TestMethod]
    public void PeutSePoser()
    {
      var plateau = new Plateau();
      var pion = new Pion(Couleur.Bleu);
      pion.PoserSur(plateau, new Trou(new Ligne(0), 0));
      AreEqual(pion,  plateau[new Ligne(0), 0].Pion);
    }

    [TestMethod]
    public void PeutPrevoirUnDeplacementSimple()
    {
      var plateau = new Plateau();

      var trajets = plateau[new Ligne(1), 0].Pion.TrajetsPour(1);

      AreEqual(1, trajets.Count);
      AreEqual(1, trajets[0].Trous.Count);
      AreEqual(new Trou(new Ligne(2), 1), trajets[0].Trous[0]);
    }

    [TestMethod]
    public void PeutDeplacerUnPion()
    {
      var plateau = new Plateau();
      var pion = plateau[new Ligne(1), 0].Pion;
      var trajets = pion.TrajetsPour(1);

      pion.Emprunter(trajets[0]);

      AreEqual(pion, plateau[new Ligne(2), 1].Pion);
      IsNull(plateau[new Ligne(1), 0].Pion);
    }
  }
}