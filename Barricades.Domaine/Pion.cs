using System.Collections.Generic;
using Value;
using static Barricades.Domaine.NomsDesCouleurs;
using System.Linq;

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
      var trajets = new List<Trajet>();
      foreach (var successeur in _trou.Successeurs)
      {
        var trajet = new Trajet();
        if (successeur.EstVide)
        {
          trajet.Ajouter(successeur);
        }
        trajets.Add(trajet);
      }

      return trajets;
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

    public void Emprunter(Trajet trajet)
    {
      _trou.Vider();
      trajet.Trous.Last().Poser(this);
    }
  }
}