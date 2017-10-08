using System.Linq;
using Barricades.Domaine.Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Barricades.Domaine.Tests.Jeu
{
  [TestClass]
  public class PlateauTests
  {
    private const int UN_COUP = 1;

    [TestMethod]
    public void MetLePlateauEnPlace()
    {
      var plateau = new Plateau();
      plateau.AssertPions(Couleur.Bleu, Position.P("0,0"), Position.P("0,1"), Position.P("1,0"), Position.P("1,1"));
      plateau.AssertPions(Couleur.Vert, Position.P("0,2"), Position.P("0,3"), Position.P("1,2"), Position.P("1,3"));
      plateau.AssertPions(Couleur.Jaune, Position.P("0,4"), Position.P("0,5"), Position.P("1,4"), Position.P("1,5"));
      plateau.AssertPions(Couleur.Rouge, Position.P("0,6"), Position.P("0,7"), Position.P("1,6"),Position.P("1,7"));

      // Ligne 2
      foreach (var y in Enumerable.Range(0, 9))
        plateau.AssertTrouVide(Position.P($"2,{y}"));

      // Ligne 3
      plateau.AssertTrouVide(Position.P("3,0"), Position.P("3,1"), Position.P("3,2"), Position.P("3,4"), Position.P("3,5"), Position.P("3,6"));
      plateau.AssertPions(Couleur.Barricade, Position.P("3,3"));

      // Barricades. On test seulement les barricades.
      // Arrivé ici on est confiant que les autres trous sont vides.
      plateau.AssertPions(Couleur.Barricade, Position.P("4,2"), Position.P("4,5"), Position.P("5,2"), Position.P("7,3"), Position.P("7,4"), Position.P("8,4"));
    }

    [TestMethod]
    public void PeutPrevoirUnDeplacementSimple()
    {
      var plateau = new Plateau();
      var position = Position.P("1,0");
      var trajets = plateau.TrajetsPour(position, 1);

      Assert.AreEqual(1, trajets.Count());
      Assert.AreEqual(2, trajets.First().Etapes.Count);
      Assert.AreEqual(Position.P("2,1"), trajets.First().Arrivee);
    }

    [TestMethod]
    public void PeutDeplacerUnPion()
    {
      var plateau = new Plateau();
      var departDuBleu = Position.P("1,0");
      var trajetsUnique = plateau.TrajetsPour(departDuBleu, UN_COUP).First();

      plateau.Deplacer(trajetsUnique);

      Assert.AreEqual(new Pion(Couleur.Bleu, Position.P("2,1")), plateau.PionSur(Position.P("2,1")));
      Assert.IsNull(plateau[departDuBleu].Pion);
    }
  }

  public static class PlateauTestsExtensions
  {
    public static void AssertPions(this Plateau plateau, Couleur couleurAttendue, params Position [] positions)
    {
      foreach (var position in positions)
      {
        var pionAttendu = new Pion(couleurAttendue, position);
        Assert.AreEqual(pionAttendu, plateau.PionSur(position));
      }
    }

    public static void AssertTrouVide(this Plateau plateau, params Position [] positions)
    {
      foreach (var position in positions)
        Assert.IsTrue(plateau[position].EstVide, $"{position} n'est pas vide");
    }
  }
}