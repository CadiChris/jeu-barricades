using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;

namespace Barricades.Domaine
{
  public class Plateau
  {
    private Trou[,] _trous;
    public Trou this[Position position] => _trous[position.X, position.Y];

    public Plateau()
    {
      TrouerLePlateau();
      PoserLesPions();
      DefinirLesPonts();
    }

    private void TrouerLePlateau()
    {
      _trous = new Trou[8,9];

      foreach (var x in Range(0, 8))
      foreach (var y in Range(0, 9))
      {
        _trous[x,y] = new Trou(new Position(x, y));
      }
    }

    private void PoserLesPions()
    {
      PoserPion(new Pion(Bleu), this[new Position(0, 0)]);
      PoserPion(new Pion(Bleu), this[new Position(0, 1)]);
      PoserPion(new Pion(Bleu), this[new Position(1, 0)]);
      PoserPion(new Pion(Bleu), this[new Position(1, 1)]);
      PoserPion(new Pion(Vert), this[new Position(0, 2)]);
      PoserPion(new Pion(Vert), this[new Position(0, 3)]);
      PoserPion(new Pion(Vert), this[new Position(1, 2)]);
      PoserPion(new Pion(Vert), this[new Position(1, 3)]);
      PoserPion(new Pion(Jaune), this[new Position(0, 4)]);
      PoserPion(new Pion(Jaune), this[new Position(0, 5)]);
      PoserPion(new Pion(Jaune), this[new Position(1, 4)]);
      PoserPion(new Pion(Jaune), this[new Position(1, 5)]);
      PoserPion(new Pion(Rouge), this[new Position(0, 6)]);
      PoserPion(new Pion(Rouge), this[new Position(0, 7)]);
      PoserPion(new Pion(Rouge), this[new Position(1, 6)]);
      PoserPion(new Pion(Rouge), this[new Position(1, 7)]);
      PoserPion(new Pion(Barricade),this[new Position(3, 3)] );
    }

    private void DefinirLesPonts()
    {
      var bleu1 = this[new Position(1, 0)];
      var trou_ligne1_2 = this[new Position(2, 1)];
      bleu1.AjouterSuccesseur(trou_ligne1_2);
    }

    public void PoserPion(Pion pion, Trou trou)
    {
      pion.PoserSur(trou);
      this[new Position(trou.X, trou.Y)].Poser(pion);
    }
  }
}
