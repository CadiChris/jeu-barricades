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
      DefinirLesPonts();
    }

    private void TrouerLePlateau()
    {
      _trous = new Trou[8, 9];

      foreach (var x in Range(0, 8))
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

    private void DefinirLesPonts()
    {
      var bleu1 = this[new Position(1, 0)];
      var trou_ligne1_2 = this[new Position(2, 1)];
      bleu1.AjouterSuccesseur(trou_ligne1_2);
    }

    public List<Trajet> TrajetsPour(Position position, int nombre)
    {
      var trajets = new List<Trajet>();
      foreach (var successeur in this[position].Successeurs)
      {
        var trajet = new Trajet();
        trajet.Ajouter(position);
        if (successeur.EstVide)
        {
          trajet.Ajouter(successeur.Position);
        }
        trajets.Add(trajet);
      }

      return trajets;
    }

    public void Deplacer(Pion pion, Trajet trajet)
    {
      var trouDeDepartVide = this[trajet.Depart].Vider();
      this[trajet.Depart] = trouDeDepartVide;

      Poser(pion.Couleur, trajet.Arrivee);
    }
  }
}
