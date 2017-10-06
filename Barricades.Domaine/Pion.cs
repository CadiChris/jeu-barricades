using System.Collections.Generic;
using Value;
using static Barricades.Domaine.NomsDesCouleurs;
using System.Linq;

namespace Barricades.Domaine
{
  public class Pion : ValueType<Pion>
  {
    private readonly Couleur _couleur;
    public Position Position { get; }

    public Pion(Couleur couleur, Position position)
    {
      _couleur = couleur;
      Position = position;
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    => new List<object>
    {
      _couleur,
      Position
    };

    public override string ToString() => $"{NomDe(_couleur)}, {Position}";

    public Pion Emprunter(Trajet trajet)
    {
      return new Pion(_couleur, trajet.Arrivee);
    }
  }
}