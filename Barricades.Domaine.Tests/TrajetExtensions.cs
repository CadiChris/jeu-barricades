using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests
{
  public static class TrajetExtensions
  {
    public static void AssertLaComposition(this Trajet trajet, params Position[] positions)
    {
      CollectionAssert.AreEqual(
        positions.ToList(),
        trajet.Etapes,
        $"Trajet qui fail l'assertion : {trajet}. ");
    }
  }
}