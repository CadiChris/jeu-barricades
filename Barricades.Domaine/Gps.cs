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
      if (deplacements == 0) yield return new Trajet(_depart.Position);

      foreach (var successeur in _depart.Successeurs)
      {
        var trajet = new Trajet(_depart.Position);
        foreach (var continuation in new Gps(successeur).TrajetsPour(deplacements - 1))
        {
          yield return trajet.ContinuerAvec(continuation);
        }
      }
    }
  }
}
