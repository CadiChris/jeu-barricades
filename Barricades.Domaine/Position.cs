using System.Collections.Generic;
using Value;

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
  }
}