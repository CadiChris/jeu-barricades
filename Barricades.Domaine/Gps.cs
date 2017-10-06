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

    public List<Trajet> TrajetsPour(int nombre)
    {
      var trajets = new List<Trajet>();

      foreach (var successeur in _depart.Successeurs)
      {
        var trajet = new Trajet();
        trajet.Ajouter(_depart.Position);
        if (successeur.EstVide)
        {
          trajet.Ajouter(successeur.Position);
        }
        trajets.Add(trajet);
      }

      return trajets;
    }
  }
}
