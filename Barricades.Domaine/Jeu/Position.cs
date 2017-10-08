using System;
using System.Collections.Generic;
using Value;

namespace Barricades.Domaine.Jeu
{
  public class Position : ValueType<Position>
  {
    public int X { get; }
    public int Y { get; }

    private Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()=> new List<object>
    {
      X, Y
    };

    public override string ToString() => $"[{X},{Y}]";

    public static Position P(string coordonnees)
    {
      coordonnees = coordonnees.Replace(" ", "");
      return new Position(Int32.Parse(coordonnees.Split(',')[0]), Int32.Parse(coordonnees.Split(',')[1]));
    }
  }
}