using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;
using static Barricades.Domaine.Position;

namespace Barricades.Domaine
{
  public class Plateau
  {
    private Trou[,] _trous;

    public Trou this[Position position]
    {
      get { return _trous[position.X, position.Y]; }
      private set { _trous[position.X, position.Y] = value; }
    }
    public Pion PionSur(Position position) => this[position].Pion;

    public Plateau()
    {
      TrouerLePlateau();
      PoserLesPions();
    }

    private void TrouerLePlateau()
    {
      _trous = new Trou[10, 9];

      _trous[2,1] = new Trou(P("2,1"));
      _trous[1, 0] = new Trou(P("1,0"), _trous[2, 1]);
      _trous[1, 1] = new Trou(P("1,1"), _trous[2, 1]);

      foreach (var y in Range(0, 9))
        _trous[0, y] = new Trou(P($"0, {y}"));

      foreach (var y in Range(2, 9-2))
        _trous[1, y] = new Trou(P($"1, {y}"));

      _trous[2,0] = new Trou(P("2,0"));
      foreach (var y in Range(2, 9-2))
        _trous[2, y] = new Trou(P($"2, {y}"));

      foreach (var x in Range(3, 10-3))
        foreach (var y in Range(0, 9))
          _trous[x, y] = new Trou(P($"{x},{y}"));
    }

    private void PoserLesPions()
    {
      Poser(Bleu, P("0, 0"));
      Poser(Bleu, P("0, 1"));
      Poser(Bleu, P("1, 0"));
      Poser(Bleu, P("1, 1"));
      Poser(Vert, P("0, 2"));
      Poser(Vert, P("0, 3"));
      Poser(Vert, P("1, 2"));
      Poser(Vert, P("1, 3"));
      Poser(Jaune, P("0, 4"));
      Poser(Jaune, P("0, 5"));
      Poser(Jaune, P("1, 4"));
      Poser(Jaune, P("1, 5"));
      Poser(Rouge, P("0, 6"));
      Poser(Rouge, P("0, 7"));
      Poser(Rouge, P("1, 6"));
      Poser(Rouge, P("1, 7"));
      Poser(Barricade, P("3, 3"));
      Poser(Barricade, P("4, 2"));
      Poser(Barricade, P("4, 5"));
      Poser(Barricade, P("5, 2"));
      Poser(Barricade, P("7, 3"));
      Poser(Barricade, P("7, 4"));
      Poser(Barricade, P("8, 4"));
    }

    private void Poser(Couleur couleur, Position position)
    {
      var pion = new Pion(couleur, position);
      var trouRempli = this[position].Poser(pion);
      this[position] = trouRempli;
    }
 
    public IEnumerable<Trajet> TrajetsPour(Position position, int nombre)
    {
      var gps = new Gps(this[position]);
      return gps.TrajetsPour(nombre);
    }

    public void Deplacer(Pion pion, Trajet trajet)
    {
      var trouDeDepartVide = this[trajet.Depart].Vider();
      this[trajet.Depart] = trouDeDepartVide;

      Poser(pion.Couleur, trajet.Arrivee);
    }
  }
}
