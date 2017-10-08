using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Value;

namespace Barricades.Domaine
{
  public class Trou : ValueType<Trou>
  {
    public Position Position { get; }
    public Pion Pion { get; private set; }
    private List<Trou> _successeurs;
    public ReadOnlyCollection<Trou> Successeurs { get; private set; }

    public int X => Position.X;
    public int Y => Position.Y;
    public bool EstVide => Pion == null;

    public Trou(Position position, params Trou[] successeurs) : this(position, null, successeurs.ToList())
    {
    }

    private Trou(Position position, Pion pion, List<Trou> successeurs)
    {
      Position = position;
      Pion = pion;
      _successeurs = successeurs;
      Successeurs = new ReadOnlyCollection<Trou>(successeurs);
    }

    public void RemplacerSuccesseurs(params Trou[] nouveauxSuccesseurs)
    {
      _successeurs = nouveauxSuccesseurs.ToList();
      Successeurs = new ReadOnlyCollection<Trou>(_successeurs);
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    {
      return new List<object> {Position};
    }

    public override string ToString() => $"{Position} > {Pion}";

    public void Poser(Pion pion)
    {
      Pion = pion;
    }

    public void Vider()
    {
      Pion = null;
    }
  }
}