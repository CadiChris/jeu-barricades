using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Barricades.Domaine;
using static Barricades.Domaine.Position;

namespace Barricades.UI
{
  public partial class PlateauUI : UserControl
  {
    public Plateau Plateau { get; private set; }

    public PlateauUI()
    {
      InitializeComponent();

      Plateau = new Plateau();
      DessinerLePlateau();
    }

    private void DessinerLePlateau()
    {
      for (var y = 0; y < 9; y++)
        DessinerTrou(Plateau[P($"0,{y}")], FindName($"_0{y}") as Button);

      for (var y = 0; y < 9; y++)
        DessinerTrou(Plateau[P($"1,{y}")], FindName($"_1{y}") as Button);

      DessinerTrou(Plateau[P("2,1")], _21);
    }

    private void DessinerTrou(Trou trou, ContentControl ui)
    {
      ui.Background = (ImageBrush) Resources["ImageTrou"];
      if (!trou.EstVide)
      {
        ui.Content = "<__>";
        ui.Foreground = Couleurs[trou.Pion.Couleur];
      }
    }

    private static readonly Dictionary<Couleur, SolidColorBrush> Couleurs = new Dictionary<Couleur, SolidColorBrush>
    {
      {Couleur.Bleu, new SolidColorBrush(Colors.CornflowerBlue)},
      {Couleur.Jaune, new SolidColorBrush(Colors.Gold)},
      {Couleur.Vert, new SolidColorBrush(Colors.OliveDrab)},
      {Couleur.Rouge, new SolidColorBrush(Colors.Crimson)},
      {Couleur.Barricade, new SolidColorBrush(Colors.SaddleBrown)},
    };
  }
}
