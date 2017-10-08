using System.Windows;
using System.Windows.Shapes;
using Barricades.Domaine;
using static Barricades.UI.CouleursUI;

namespace Barricades.UI
{
  public class SelectionUI
  {
    private readonly Window _window;
    private readonly SelectionControl _selectionControl;

    public SelectionUI(SelectionControl selectionControl)
    {
      _selectionControl = selectionControl;
      _window = new Window()
      {
        Width = 300,
        Height = 300,
        Title = "Barricades ! - Sélection",
        ResizeMode = ResizeMode.NoResize,
        Content = _selectionControl
      };
    }

    public bool EstComplete => _selectionControl.EstComplete;
    public int Chiffre => _selectionControl.Chiffre.Value;
    public Trou Trou => _selectionControl.Trou;

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
      _selectionControl.Selectionner(selection);
    }

    public void Effacer()
    {
      _selectionControl.Effacer();
    }
  }
}