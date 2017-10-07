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

    public IEnumerable<Trajet> TrajetsPour(int deplacements)
    {
      foreach (var successeur in _depart.Successeurs)
      {
        var deplacementsRestants = deplacements;
        var trajet = new Trajet(_depart.Position);

        var suivant = successeur;

        while (deplacementsRestants > 0 && suivant.EstVide)
        {
          trajet.NouvelleEtape(suivant.Position);
          deplacementsRestants--;
          if (suivant.Successeurs.Any())
            suivant = suivant.Successeurs[0];
          else
            break;
        }

        yield return trajet; 
      }
    }
  }
}
