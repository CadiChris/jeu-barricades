using System.Collections.Generic;

namespace Barricades.Domaine
{
  public class Trajet
  {
    public List<Trou> Trous { get; private set; }

    public Trajet(List<Trou> trous)
    {
      Trous = trous;
    }
  }
}