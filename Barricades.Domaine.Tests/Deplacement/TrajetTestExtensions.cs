using System.Linq;
using Barricades.Domaine.Deplacement;
using Barricades.Domaine.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests.Deplacement
{
  public static class TrajetTestExtensions
  {
    public static void AssertLaComposition(this Trajet trajet, params Position[] positions)
    {
      CollectionAssert.AreEqual(
        positions.ToList(),
        trajet.Etapes.ToList(),
        $"Trajet qui fail l'assertion : {trajet}. ");
    }
  }
}