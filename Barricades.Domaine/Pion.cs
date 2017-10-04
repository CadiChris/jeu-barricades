using Barricades.Domaine;
using System.Collections.Generic;
using Value;
using static Barricades.Domaine.NomsDesCouleurs;
using System;

namespace Barricades.Domaine
{
  public class Pion : ValueType<Pion>
  {
    private readonly Couleur _couleur;
    private Trou _trou;

    public Pion(Couleur couleur)
    {
      _couleur = couleur;
    }

    public void PoserSur(Plateau plateau, Trou trou)
    {
      plateau.PoserPion(this, trou);
      _trou = trou;
    }

    public List<Trajet> TrajetsPour(int nombre)
    {
      return new List<Trajet>
      {
        new Trajet(new List<Trou>
        {
          new Trou(new LigneDeTrous(0), 1)
        })
      };
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    => new List<object>
    {
      _couleur,
      _trou
    };

    public override string ToString() => $"{NomDe(_couleur)}, {_trou}";

    public void PoserSur(Trou trou)
    {
      _trou = trou;
    }
  }
}