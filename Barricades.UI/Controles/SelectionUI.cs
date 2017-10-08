using System.Windows;
using Barricades.Domaine.Jeu;

namespace Barricades.UI.Controles
{
  public class SelectionUI
  {
    private readonly Window _window;
    private readonly Controles.SelectionControl _selectionControl;

    public SelectionUI(Controles.SelectionControl selectionControl)
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