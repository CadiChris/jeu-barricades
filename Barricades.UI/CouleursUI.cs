using System.Collections.Generic;
using System.Windows.Media;
using Barricades.Domaine;

namespace Barricades.UI
{
  public static class CouleursUI
  {
    private static readonly Dictionary<Couleur, SolidColorBrush> Couleurs = new Dictionary<Couleur, SolidColorBrush>
    {
      {Couleur.Bleu, new SolidColorBrush(Colors.DodgerBlue)},
      {Couleur.Jaune, new SolidColorBrush(Colors.Gold)},
      {Couleur.Vert, new SolidColorBrush(Colors.OliveDrab)},
      {Couleur.Rouge, new SolidColorBrush(Colors.Tomato)},
      {Couleur.Barricade, new SolidColorBrush(Colors.Brown)},
    };

    public static SolidColorBrush BrushDeCouleur(Couleur couleur) => Couleurs[couleur];
  }
}
