using System.Collections.Generic;
using System.Linq;

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
  }
}