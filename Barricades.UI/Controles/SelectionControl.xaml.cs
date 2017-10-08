using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Barricades.Domaine.Jeu;
using Barricades.UI.Jeu;

namespace Barricades.UI.Controles
{
  public partial class SelectionControl : UserControl, INotifyPropertyChanged
  {
    private int? _chiffre;
    public int? Chiffre
    {
      get { return _chiffre; }
      private set { _chiffre = value; OnPropertyChanged();}
    }

    public bool EstComplete => Chiffre.HasValue && Trou != null && !Trou.EstVide;
    public Trou Trou { get; private set; }

    public SelectionControl()
    {
      InitializeComponent();
      DataContext = this;
    }

    public void Selectionner(Trou trou)
    {
      Trou = trou;
      DessinerSelection();
    }

    private void DessinerSelection()
    {
      if (Trou.EstVide)
        _canvas.Children.Clear();
      else
        _canvas.Children.Add(new Ellipse {Fill = CouleursUI.BrushDeCouleur(Trou.Pion.Couleur), Width = 50, Height = 60});
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

    public void Effacer()
    {
      Chiffre = null;
      Trou = null;
    }
  }
}
