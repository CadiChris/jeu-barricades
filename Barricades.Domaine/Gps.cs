using System.Collections.Generic;
using System.Linq;

namespace Barricades.Domaine
{
  public class Gps
  {
    private readonly Trou _depart;
    private readonly Trou _origine;

    public Gps(Trou depart) :this(depart, depart)
    {
    }

    private Gps(Trou depart, Trou origine)
    {
      _depart = depart;
      _origine = origine;
    }

    public IEnumerable<Trajet> TrajetsPour(int deplacements, Position provenance = null)
    {
      var arrivee = deplacements == 0;
      if (arrivee)
      {
        yield return new Trajet(_depart.Position);
        yield break;
      }

      var enAvant = _depart.Successeurs.Where(s => s.Position != provenance).ToList();
      
      foreach (var suivant in enAvant)
      {
        var bloqueParLaMemeCouleur = deplacements == 1
                                     && !_origine.EstVide
                                     && !suivant.EstVide
                                     && _origine.Pion.Couleur == suivant.Pion.Couleur;

        if (bloqueParLaMemeCouleur)
        {
          yield return new Trajet(_depart.Position).Bloquer();
          yield break;
        }

        var trajet = new Trajet(_depart.Position);
        if (suivant.EstVide)
          foreach (var continuation in new Gps(suivant, _origine).TrajetsPour(deplacements - 1, _depart.Position))
            yield return trajet.ContinuerAvec(continuation);
        else
          yield return deplacements == 1 ? trajet.QuiPrend(suivant.Pion) : trajet.Bloquer();
      }
      if (!enAvant.Any())
        yield return new Trajet(_depart.Position).Bloquer();
    }
  }
}
