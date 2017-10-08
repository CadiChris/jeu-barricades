using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Barricades.Domaine;
using static Barricades.Domaine.Position;

namespace Barricades.UI
{
  public partial class PlateauUI : UserControl
  {
    public Plateau Plateau { get; }
    private Window _selection;

    public PlateauUI()
    {
      InitializeComponent();
      AfficherFenetreDeSelection();

      Plateau = new Plateau();
      var gps = new Gps(Plateau[P("1,1")]);
      var trajets = gps.TrajetsPour(3);
      Plateau.Deplacer(trajets.ToList()[1]);
      Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(DessinerLePlateau));
    }

    private void AfficherFenetreDeSelection()
    {
      _selection = new Window()
      {
        Width = 150,
        Height = 150,
        Title = "Barricades ! - Sélection",
        ResizeMode = ResizeMode.NoResize,
      };
      _selection.Show();
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
      DessinerPion(trou, ui);
      DessinerLesChemins(trou, ui);
      AbonnerAuClic(trou, ui);
    }

    private void AbonnerAuClic(Trou trou, Canvas ui)
    {
      ui.MouseLeftButtonDown += (sender, args) => Selectionner(trou);
    }

    private void Selectionner(Trou selection)
    {
      _selection.Content = selection.EstVide ? null : new Ellipse {Fill = Couleurs[selection.Pion.Couleur], Width = 50, Height = 60};
    }

    private static void DessinerPion(Trou trou, Canvas ui)
    {
      if (!trou.EstVide)
        ui.Children.Add(new Ellipse()
        {
          Margin = new Thickness(27, 25, 0, 0),
          Width = 45,
          Height = 50,
          Fill = Couleurs[trou.Pion.Couleur]
        });
    }

    private void DessinerLesChemins(Trou trou, Canvas ui)
    {
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
        _canvas.Children.Insert(0, chemin);
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

    private void PlateauUI_Unloaded(object sender, RoutedEventArgs e)
    {
      _selection.Close();
    }
  }
}
