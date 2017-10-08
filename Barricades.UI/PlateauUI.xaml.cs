using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Barricades.Domaine;
using static System.Windows.Application;
using static System.Windows.HorizontalAlignment;
using static Barricades.Domaine.Position;

namespace Barricades.UI
{
  public partial class PlateauUI : UserControl
  {
    public Plateau Plateau { get; }

    public PlateauUI()
    {
      InitializeComponent();

      Plateau = new Plateau();
      Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(DessinerLePlateau));
    }

    private void DessinerLePlateau()
    {
      for (var x = 0; x < 10; x++)
        for (var y = 0; y < 9; y++)
          if (Plateau[P($"{x},{y}")] != null)
            DessinerTrou(Plateau[P($"{x},{y}")], FindName($"_{x}{y}") as Canvas);
    }

    private void DessinerTrou(Trou trou, Canvas ui)
    {
      ui.Background = (ImageBrush) Resources["ImageTrou"];
      if (!trou.EstVide)
        ui.Children.Add(new Ellipse() { Margin = new Thickness(27, 25, 0, 0), Width = 45, Height = 50, Fill = Couleurs[trou.Pion.Couleur]});

      foreach (var successeur in trou.Successeurs)
      {
        var successeurUi = FindName($"_{successeur.Position.X}{successeur.Position.Y}") as Canvas;
        var positionDuSuccesseur = successeurUi.TransformToAncestor(this).Transform(new Point(0, 0));
        var maPosition = ui.TransformToAncestor(this).Transform(new Point(0, 0));
        var x1 = positionDuSuccesseur.X + successeurUi.ActualWidth / 2;
        var y1 = positionDuSuccesseur.Y + successeurUi.ActualHeight / 2 + 15;
        var chemin = new Line
        {
          Stroke = Brushes.Black,
          StrokeThickness = 3,
          Opacity = .5,
          X1 = x1,
          Y1 = y1,
          X2 = maPosition.X + ui.ActualWidth / 2,
          Y2 = maPosition.Y + ui.ActualHeight / 2 + 15,
        };
        _canvas.Children.Add(chemin);
      }
    }

    private static readonly Dictionary<Couleur, SolidColorBrush> Couleurs = new Dictionary<Couleur, SolidColorBrush>
    {
      {Couleur.Bleu, new SolidColorBrush(Colors.DodgerBlue)},
      {Couleur.Jaune, new SolidColorBrush(Colors.Gold)},
      {Couleur.Vert, new SolidColorBrush(Colors.OliveDrab)},
      {Couleur.Rouge, new SolidColorBrush(Colors.Tomato)},
      {Couleur.Barricade, new SolidColorBrush(Colors.Brown)},
    };
  }
}
