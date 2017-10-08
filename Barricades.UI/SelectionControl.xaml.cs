using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Barricades.Domaine;
using static Barricades.UI.CouleursUI;

namespace Barricades.UI
{
  public partial class SelectionControl : UserControl, INotifyPropertyChanged
  {
    private int _chiffre;

    public int Chiffre
    {
      get { return _chiffre; }
      private set { _chiffre = value; OnPropertyChanged();}
    }

    public SelectionControl()
    {
      InitializeComponent();
      DataContext = this;
    }

    public void Selectionner(Trou selection)
    {
      if (selection.EstVide)
        _canvas.Children.Clear();
      else
        _canvas.Children.Add(new Ellipse { Fill = BrushDeCouleur(selection.Pion.Couleur), Width = 50, Height = 60 });
    }

    private void LancerLeDe_Click(object sender, RoutedEventArgs e)
    {
      LancerLeDe();
    }

    private void LancerLeDe()
    {
      Chiffre = De.Lancer();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
