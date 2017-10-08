using System;

namespace Barricades.UI.Jeu
{
  public class De
  {
    public static int Lancer()
    {
      return new Random().Next(1, 6);
    }
  }
}
