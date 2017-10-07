using System.Collections.Generic;
using Value;
using static System.Int32;

namespace Barricades.Domaine
{
  public class Position : ValueType<Position>
  {
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
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
      return new Position(Parse(coordonnees.Split(',')[0]), Parse(coordonnees.Split(',')[1]));
    }
  }
}