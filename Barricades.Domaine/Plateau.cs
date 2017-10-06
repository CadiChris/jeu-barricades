using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;

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
      _trous = new Trou[8, 9];

      _trous[2,1] = new Trou(new Position(2,1));
      _trous[1, 0] = new Trou(new Position(1,0), _trous[2, 1]);
      _trous[1, 1] = new Trou(new Position(1,1), _trous[2, 1]);

      foreach (var y in Range(0, 9))
      {
        _trous[0, y] = new Trou(new Position(0, y));
      }

      foreach (var y in Range(2, 9-2))
      {
        _trous[1, y] = new Trou(new Position(1, y));
      }

      _trous[2,0] = new Trou(new Position(2,0));
      foreach (var y in Range(2, 9-2))
      {
        _trous[2, y] = new Trou(new Position(2, y));
      }

      foreach (var x in Range(3, 8-3))
        foreach (var y in Range(0, 9))
        {
          _trous[x, y] = new Trou(new Position(x, y));
        }
    }

    private void PoserLesPions()
    {
      Poser(Bleu, new Position(0, 0));
      Poser(Bleu, new Position(0, 1));
      Poser(Bleu, new Position(1, 0));
      Poser(Bleu, new Position(1, 1));
      Poser(Vert, new Position(0, 2));
      Poser(Vert, new Position(0, 3));
      Poser(Vert, new Position(1, 2));
      Poser(Vert, new Position(1, 3));
      Poser(Jaune, new Position(0, 4));
      Poser(Jaune, new Position(0, 5));
      Poser(Jaune, new Position(1, 4));
      Poser(Jaune, new Position(1, 5));
      Poser(Rouge, new Position(0, 6));
      Poser(Rouge, new Position(0, 7));
      Poser(Rouge, new Position(1, 6));
      Poser(Rouge, new Position(1, 7));
      Poser(Barricade, new Position(3, 3));
    }

    private void Poser(Couleur couleur, Position position)
    {
      var pion = new Pion(couleur, position);
      var trouRempli = this[position].Poser(pion);
      this[position] = trouRempli;
    }
 
    public List<Trajet> TrajetsPour(Position position, int nombre)
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
