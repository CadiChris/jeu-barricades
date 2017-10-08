using System.Collections.Generic;
using System.Linq;

namespace Barricades.Domaine
{
  public class Gps
  {
    private readonly Trou _depart;

    public Gps(Trou depart)
    {
      _depart = depart;
    }

    public IEnumerable<Trajet> TrajetsPour(int deplacements, Position provenance = null)
    {
      var arrivee = deplacements == 0;
      if (arrivee)
      {
        yield return new Trajet(_depart.Position);
        yield break;
      }

      var versLavant = _depart.Successeurs.Where(s => s.Position != provenance).ToList();
      foreach (var successeur in versLavant)
      {
        var trajet = new Trajet(_depart.Position);
        if (successeur.EstVide)
          foreach (var continuation in new Gps(successeur).TrajetsPour(deplacements - 1, _depart.Position))
            yield return trajet.ContinuerAvec(continuation);
        else
          yield return deplacements == 1 ? trajet.QuiPrend(successeur.Pion) : trajet.Bloquer();
      }
      if (!versLavant.Any())
        yield return new Trajet(_depart.Position).Bloquer();
    }
  }
}
