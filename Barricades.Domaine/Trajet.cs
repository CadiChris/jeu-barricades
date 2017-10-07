using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static System.String;

namespace Barricades.Domaine
{
  public class Trajet
  {
    public ReadOnlyCollection<Position> Etapes { get; }

    public Position Depart => Etapes.First();
    public Position Arrivee => Etapes.Last();
    public bool EstBloque { get; }

    public Trajet(Position depart) : this(false, new [] { depart })
    {
    }

    public Trajet(bool estBloque, params Position[] etapes)
    {
      EstBloque = estBloque;
      Etapes = new ReadOnlyCollection<Position>(etapes);
    }
    
    public Trajet NouvelleEtape(Position position)
    {
      var avecNouvellePosition = new List<Position>(Etapes) {position};
      return new Trajet(EstBloque, avecNouvellePosition.ToArray());
    }

    public Trajet ContinuerAvec(Trajet suite)
    {
      var toutesLesEtapes = new List<Position>(Etapes);
      toutesLesEtapes.AddRange(suite.Etapes);
      return new Trajet(EstBloque | suite.EstBloque, toutesLesEtapes.ToArray());
    }

    public override string ToString() => Join("->", Etapes.Select(e => $"{e}"));

    public Trajet Bloquer()
    {
      return new Trajet(true, Etapes.ToArray());
    }
  }
}