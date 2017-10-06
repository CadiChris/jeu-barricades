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
  public class TrouTests
  {
    [TestMethod]
    public void Egalite()
    {
      AreEqual(new Trou(new Position(0, 0)), new Trou(new Position(0,0)));
      AreNotEqual(new Trou(new Position(0, 0)), new Trou(new Position(0, 1)));
    }
  }
}