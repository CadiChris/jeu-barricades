using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace Barricades.Domaine
{
  public class Trajet
  {
    public List<Position> Etapes { get; }

    public Position Depart => Etapes.First();
    public Position Arrivee => Etapes.Last();

    public Trajet(Position depart = null)
    {
      Etapes = new List<Position>();
      if (depart != null) NouvelleEtape(depart);
    }

    public void NouvelleEtape(Position position)
    {
      Etapes.Add(position);
    }

    public override string ToString() => Join("->", Etapes.Select(e => $"{e}"));
  }
}