using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Barricades.Domaine;
using static Barricades.Domaine.Position;
using static Barricades.UI.CouleursUI;

namespace Barricades.UI
{
  public partial class PlateauUI : UserControl
  {
    public Plateau Plateau { get; }
    private SelectionUI _selection;

    public PlateauUI()
    {
      InitializeComponent();
      AfficherFenetreDeSelection();

      Plateau = new Plateau();
      Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(DessinerLePlateau));
    }

    private void AfficherFenetreDeSelection()
    {
      _selection = new SelectionUI(new SelectionControl());
      _selection.Afficher();
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
      ui.Background = (ImageBrush)Resources["ImageTrou"];
      DessinerPion(trou, ui);
      DessinerLesChemins(trou, ui);
      AbonnerAuClic(trou, ui);
    }

    private void AbonnerAuClic(Trou trou, Canvas ui)
    {
      ui.MouseLeftButtonDown += (sender, args) => Jouer(trou);
    }

    private void Jouer(Trou trou)
    {
      if (_selection.EstComplete)
      {
        var trajetsPermis = new Gps(_selection.Trou).TrajetsPour(_selection.Chiffre).ToList();
        var destinationVoulue = trou.Position;
        var deplacement = trajetsPermis.FirstOrDefault(t => t.MeneA(destinationVoulue));
        if (deplacement != null)
        {
          Plateau.Deplacer(deplacement);
          DeplacerPion(deplacement);
          _selection.Effacer();
        }
      }
      else
        _selection.Selectionner(trou);

    }

    private void DeplacerPion(Trajet deplacement)
    {
      var depart = FindName($"_{deplacement.Depart.X}{deplacement.Depart.Y}") as Canvas;
      var arrivee = FindName($"_{deplacement.Arrivee.X}{deplacement.Arrivee.Y}") as Canvas;
      var pointDeDepart = depart.TransformToAncestor(this).Transform(new Point(0, 0));
      var pointArrivee = arrivee.TransformToAncestor(this).Transform(new Point(0, 0));

      var pionQuiSeDeplace = EllipseDeCouleur(Plateau[deplacement.Arrivee].Pion.Couleur);
      _canvas.Children.Add(pionQuiSeDeplace);
      var animationX = new DoubleAnimation
      {
        From = pointDeDepart.X,
        To = pointArrivee.X,
        Duration = TimeSpan.FromSeconds(0.5)
      };
      var animationY = new DoubleAnimation
      {
        EasingFunction = new CircleEase {EasingMode = EasingMode.EaseOut},
        From = pointDeDepart.Y,
        To = pointArrivee.Y,
        Duration = TimeSpan.FromSeconds(0.5)
      };
      Storyboard.SetTarget(animationX, pionQuiSeDeplace);
      Storyboard.SetTarget(animationY, pionQuiSeDeplace);
      Storyboard.SetTargetProperty(animationX, new PropertyPath(Canvas.LeftProperty));
      Storyboard.SetTargetProperty(animationY, new PropertyPath(Canvas.TopProperty));
      var sb = new Storyboard();
      sb.Children.Add(animationX);
      sb.Children.Add(animationY);
      sb.Completed += (sender, args) =>
      {
        DessinerPion(Plateau[deplacement.Arrivee], FindName($"_{deplacement.Arrivee.X}{deplacement.Arrivee.Y}") as Canvas);
        _canvas.Children.Remove(pionQuiSeDeplace);
      };
      sb.Begin();
      DessinerPion(Plateau[deplacement.Depart], FindName($"_{deplacement.Depart.X}{deplacement.Depart.Y}") as Canvas);
    }

    private void DessinerPion(Trou trou, Canvas ui)
    {
      if (trou.EstVide)
        ui.Children.Clear();
      else
      {
        var pion = EllipseDeCouleur(trou.Pion.Couleur);
        pion.MouseLeftButtonUp += (sender, args) => Jouer(trou);
        ui.Children.Add(pion);
      }
    }

    private static Ellipse EllipseDeCouleur(Couleur couleur)
    {
      return new Ellipse()
      {
        Margin = new Thickness(27, 25, 0, 0),
        Width = 45,
        Height = 50,
        Fill = BrushDeCouleur(couleur)
      };
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

    private void PlateauUI_Unloaded(object sender, RoutedEventArgs e)
    {
      _selection.Fermer();
    }
  }
}
