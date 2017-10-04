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
      pion.PoserSur(plateau, new Trou(new LigneDeTrous(0), 0));
      AreEqual(pion,  plateau[new LigneDeTrous(0), 0].Pion);
    }

    [TestMethod]
    public void PeutPrevoirUnDeplacement()
    {
      var plateau = new Plateau();
      var pion = new Pion(Couleur.Bleu);
      pion.PoserSur(plateau, new Trou(new LigneDeTrous(0), 0));
      var trajets = pion.TrajetsPour(1);
      AreEqual(new Trou(new LigneDeTrous(0), 1), trajets[0].Trous[0]);
    }
    
  }
}