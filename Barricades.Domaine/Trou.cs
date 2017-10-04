using System.Collections.Generic;
using Value;

namespace Barricades.Domaine
{
  public class Trou : ValueType<Trou>
  {
    public LigneDeTrous Ligne { get; }
    public int Y { get; }

    public Trou(LigneDeTrous ligne, int y)
    {
      Ligne = ligne;
      Y = y;
    }

    public Pion Pion { get; private set; }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    {
      return new List<object> { Ligne, Y };
    }

    public void Poser(Pion pion)
    {
      Pion = pion;
    }

    public override string ToString() => $"[{Ligne}, Trou {Y}]";
  }
}