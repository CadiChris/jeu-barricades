using System;
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
    public bool PrendUnPion => Prise != null;
    public Pion Prise { get; }

    public Trajet(Position depart) : this(false, null, new [] { depart })
    {
    }

    public Trajet(bool estBloque, Pion prise, params Position[] etapes)
    {
      EstBloque = estBloque;
      Prise = prise;
      Etapes = new ReadOnlyCollection<Position>(etapes);
    }
    
    public Trajet NouvelleEtape(Position position)
    {
      var avecNouvellePosition = new List<Position>(Etapes) {position};
      return new Trajet(EstBloque, Prise, avecNouvellePosition.ToArray());
    }

    public Trajet ContinuerAvec(Trajet suite)
    {
      var toutesLesEtapes = new List<Position>(Etapes);
      toutesLesEtapes.AddRange(suite.Etapes);
      return new Trajet(
        EstBloque | suite.EstBloque,
        suite.Prise,
        toutesLesEtapes.ToArray());
    }

    public override string ToString() => Join("->", Etapes.Select(e => $"{e}"));

    public Trajet Bloquer()
    {
      return new Trajet(true, Prise, Etapes.ToArray());
    }

    internal Trajet QuiPrend(Pion prise)
    {
      return new Trajet(EstBloque, prise, Etapes.ToArray());
    }
  }
}