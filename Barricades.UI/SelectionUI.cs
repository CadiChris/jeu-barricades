using System.Windows;
using System.Windows.Shapes;
using Barricades.Domaine;
using static Barricades.UI.CouleursUI;

namespace Barricades.UI
{
  public class SelectionUI
  {
    private readonly Window _window;

    public SelectionUI()
    {
      _window = new Window()
      {
        Width = 150,
        Height = 150,
        Title = "Barricades ! - Sélection",
        ResizeMode = ResizeMode.NoResize,
      };
    }

    public void Afficher()
    {
      _window.Show();
    }

    public void Fermer()
    {
      _window.Close();
    }

    public void Selectionner(Trou selection)
    {
     _window.Content = selection.EstVide ? null : new Ellipse { Fill = BrushDeCouleur(selection.Pion.Couleur), Width = 50, Height = 60 };
    }
  }
}