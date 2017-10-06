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

    public IEnumerable<Trajet> TrajetsPour(int nombre)
    {
      var trajet = new Trajet(_depart.Position);
      
      var suivant = _depart.Successeurs[0];

      while (nombre > 0 && suivant.EstVide)
      {
        trajet.NouvelleEtape(suivant.Position);
        nombre--;
        if (suivant.Successeurs.Any())
          suivant = suivant.Successeurs[0];
        else
          break;
      }
      
      yield return trajet;
    }
  }
}
