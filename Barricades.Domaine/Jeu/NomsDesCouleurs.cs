using System.Collections.Generic;

namespace Barricades.Domaine.Jeu
{
  public static class NomsDesCouleurs
  {
    private static Dictionary<Couleur, string> Noms { get; } = new Dictionary<Couleur, string>
    {
      { Couleur.Bleu, "Bleu" },
      { Couleur.Vert, "Vert" },
      { Couleur.Jaune, "Jaune" },
      { Couleur.Rouge, "Rouge" },
      { Couleur.Barricade, "Barricade" },
    };

    public static string NomDe(Couleur c) => Noms[c];
  }
}
