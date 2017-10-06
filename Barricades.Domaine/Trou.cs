using System.Collections.Generic;
using System.Linq;
using Value;

namespace Barricades.Domaine
{
  public class Trou : ValueType<Trou>
  {
    public Position Position { get; }
    public List<Trou> Successeurs { get; }
    public Pion Pion { get; }

    public int X => Position.X;
    public int Y => Position.Y;
    public bool EstVide => Pion == null;
    
    public Trou(Position position, params Trou[] successeurs): this(position, null, successeurs.ToList())
    {
    }

    private Trou(Position position, Pion pion, List<Trou> successeurs)
    {
      Position = position;
      Pion = pion;
      Successeurs = successeurs;
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    {
      return new List<object> { Position };
    }

    public override string ToString() => $"{Position} > {Pion}";

    public IEnumerable<Trou> AccessiblesPour(int nombre)
    {
      if (nombre == 1)
        yield return this;
    }

    public Trou Poser(Pion pion)
    {
      return new Trou(Position, pion, Successeurs);
    }

    public Trou Vider()
    {
      return new Trou(Position, null, Successeurs);
    }
  }
}