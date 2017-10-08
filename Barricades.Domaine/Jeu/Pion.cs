using System.Collections.Generic;
using Barricades.Domaine.Deplacement;
using Value;

namespace Barricades.Domaine.Jeu
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

    public override string ToString() => $"{NomsDesCouleurs.NomDe(Couleur)}, {Position}";

    public Pion Emprunter(Trajet trajet)
    {
      return new Pion(Couleur, trajet.Arrivee);
    }
  }
}