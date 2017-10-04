using System.Collections.Generic;
using Value;

namespace Barricades.Domaine
{
  public class Trou : ValueType<Trou>
  {
    public Ligne Ligne { get; }
    public int Y { get; }
    public Pion Pion { get; private set; }
    public bool EstVide => Pion == null;
    public List<Trou> Successeurs { get; }

    public Trou(Ligne ligne, int y)
    {
      Ligne = ligne;
      Y = y;
      Successeurs = new List<Trou>();
    }

    public void AjouterSuccesseur(Trou trou)
    {
      Successeurs.Add(trou);
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    {
      return new List<object> { Ligne, Y };
    }

    public void Poser(Pion pion)
    {
      Pion = pion;
    }

    public override string ToString() => $"[{Ligne}, Trou {Y}]";

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