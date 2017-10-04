using System.Collections.Generic;
using Value;

namespace Barricades.Domaine
{
  public class Ligne : ValueType<Ligne>
  {
    public List<Trou> Trous { get; }
    public int X { get; private set; }

    public Ligne(int x)
    {
      X = x;
      Trous = new List<Trou>();
    }
    
    public void TrouerEn(int y)
    {
      Trous.Add(new Trou(this, y));
    }

    public void TrouerEn(IEnumerable<int> ys)
    {
      foreach (var y in ys)
      {
        TrouerEn(y);
      }
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() => new List<object>
    {
      X
    };

    public override string ToString() => $"Ligne {X}";
  }
}