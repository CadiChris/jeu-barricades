using System.Collections.Generic;

namespace Barricades.Domaine
{
  public static class NomsDesCouleurs
  {
    private static Dictionary<Couleur, string> Noms { get; } = new Dictionary<Couleur, string>
    {
      { Couleur.Bleu, "Bleu" },
      { Couleur.Vert, "Vert" },
      { Couleur.Jaune, "Jaune" },
      { Couleur.Rouge, "Rouge" },
    };

    public static string NomDe(Couleur c) => Noms[c];
  }
}
