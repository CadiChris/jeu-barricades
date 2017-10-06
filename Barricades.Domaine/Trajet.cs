using System.Collections.Generic;
using System.Linq;

namespace Barricades.Domaine
{
  public class Trajet
  {
    public List<Position> Positions { get; }

    public Position Depart => Positions.First();
    public Position Arrivee => Positions.Last();

    public Trajet()
    {
      Positions = new List<Position>();
    }

    public void Ajouter(Position position)
    {
      Positions.Add(position);
    }
  }
}