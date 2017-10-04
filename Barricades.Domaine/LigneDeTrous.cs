using System.Collections.Generic;
using Value;

namespace Barricades.Domaine
{
  public class LigneDeTrous : ValueType<LigneDeTrous>
  {
    public List<Trou> Trous { get; }
    public int X { get; private set; }

    public LigneDeTrous(int x)
    {
      X = x;
      Trous = new List<Trou>();
    }
    
    public void TrouerEn(int y)
    {
      Trous.Add(new Trou(this, y));
    }

    public void TrouerEn(params int[] ys)
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