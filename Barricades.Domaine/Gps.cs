using System.Collections.Generic;

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
      foreach (var successeur in _depart.Successeurs)
      {
        var trajet = new Trajet();
        trajet.NouvelleEtape(_depart.Position);

        while (nombre > 0)
        {
          if (!successeur.EstVide) break;
          trajet.NouvelleEtape(successeur.Position);
          nombre--;
        }  
        yield return trajet;
      }
    }
  }
}
