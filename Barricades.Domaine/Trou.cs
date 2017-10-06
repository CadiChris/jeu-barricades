using System.Collections.Generic;
using Value;

namespace Barricades.Domaine
{
  public class Trou : ValueType<Trou>
  {
    public int X => Position.X;
    public int Y => Position.Y;
    public Pion Pion { get; private set; }
    public bool EstVide => Pion == null;
    public List<Trou> Successeurs { get; }
    
    public Trou(Position position)
    {
      Position = position;
      Successeurs = new List<Trou>();
    }

    public Position Position { get; private set; }

    public void AjouterSuccesseur(Trou trou)
    {
      Successeurs.Add(trou);
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    {
      return new List<object> { Position };
    }

    public void Poser(Pion pion)
    {
      Pion = pion;
    }

    public override string ToString() => $"[{Position}]";

    public IEnumerable<Trou> AccessiblesPour(int nombre)
    {
      if (nombre == 1)
      yield return this;
    }

    public void Vider()
    {
      Pion = null;
    }
  }
}