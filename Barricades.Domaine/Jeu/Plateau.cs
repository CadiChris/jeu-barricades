using System.Collections.Generic;
using Barricades.Domaine.Deplacement;

namespace Barricades.Domaine.Jeu
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
      _trous = Plateaux.PlateauClassique();

    }

    private void PoserLesPions()
    {
      Poser(Couleur.Bleu, Position.P("0, 0"));
      Poser(Couleur.Bleu, Position.P("0, 1"));
      Poser(Couleur.Bleu, Position.P("1, 0"));
      Poser(Couleur.Bleu, Position.P("1, 1"));
      Poser(Couleur.Vert, Position.P("0, 2"));
      Poser(Couleur.Vert, Position.P("0, 3"));
      Poser(Couleur.Vert, Position.P("1, 2"));
      Poser(Couleur.Vert, Position.P("1, 3"));
      Poser(Couleur.Jaune, Position.P("0, 4"));
      Poser(Couleur.Jaune, Position.P("0, 5"));
      Poser(Couleur.Jaune, Position.P("1, 4"));
      Poser(Couleur.Jaune, Position.P("1, 5"));
      Poser(Couleur.Rouge, Position.P("0, 6"));
      Poser(Couleur.Rouge, Position.P("0, 7"));
      Poser(Couleur.Rouge, Position.P("1, 6"));
      Poser(Couleur.Rouge, Position.P("1, 7"));
      Poser(Couleur.Barricade, Position.P("3, 3"));
      Poser(Couleur.Barricade, Position.P("4, 2"));
      Poser(Couleur.Barricade, Position.P("4, 5"));
      Poser(Couleur.Barricade, Position.P("5, 2"));
      Poser(Couleur.Barricade, Position.P("7, 3"));
      Poser(Couleur.Barricade, Position.P("7, 4"));
      Poser(Couleur.Barricade, Position.P("8, 4"));
    }

    private void Poser(Couleur couleur, Position position)
    {
      var pion = new Pion(couleur, position);
      this[position].Poser(pion);
    }
 
    public IEnumerable<Trajet> TrajetsPour(Position position, int nombre)
    {
      var gps = new Gps(this[position]);
      return gps.TrajetsPour(nombre);
    }

    public void Deplacer(Trajet trajet)
    {
      var pionDeDepart = this[trajet.Depart].Pion;
      this[trajet.Depart].Vider();
      Poser(pionDeDepart.Couleur, trajet.Arrivee);
    }
  }
}
