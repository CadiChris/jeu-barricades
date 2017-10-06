using System.Collections.Generic;
using Value;
using static Barricades.Domaine.NomsDesCouleurs;
using System.Linq;

namespace Barricades.Domaine
{
  public class Pion : ValueType<Pion>
  {
    public Couleur Couleur { get; }
    public Position Position { get; }

    public Pion(Couleur couleur, Position position)
    {
      Couleur = couleur;
      Position = position;
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
    => new List<object>
    {
      Couleur,
      Position
    };

    public override string ToString() => $"{NomDe(Couleur)}, {Position}";

    public Pion Emprunter(Trajet trajet)
    {
      return new Pion(Couleur, trajet.Arrivee);
    }
  }
}