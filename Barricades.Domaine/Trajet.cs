using System.Collections.Generic;

namespace Barricades.Domaine
{
  public class Trajet
  {
    public List<Trou> Trous { get; private set; }

    public Trajet()
    {
      Trous = new List<Trou>();
    }

    public void Ajouter(Trou trou)
    {
      Trous.Add(trou);
    }
  }
}