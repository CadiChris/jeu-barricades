using System.Linq;
using static Barricades.Domaine.Position;

namespace Barricades.Domaine
{
  internal static class Plateaux
  {
    public static Trou[,] PlateauClassique()
    {
      var trous =  new Trou[10, 9];

      Ligne(trous, 9, nombreDeColonnes:1);
      Ligne(trous, 8, nombreDeColonnes:9);
      Ligne(trous, 7, nombreDeColonnes:8);
      Ligne(trous, 6, nombreDeColonnes:1);
      Ligne(trous, 5, nombreDeColonnes:5);
      Ligne(trous, 4, nombreDeColonnes:8);
      Ligne(trous, 3, nombreDeColonnes:7);
      Ligne(trous, 2, nombreDeColonnes:9);
      Ligne(trous, 1, nombreDeColonnes:8);
      Ligne(trous, 0, nombreDeColonnes:8);

      trous[1,0].RemplacerSuccesseurs(trous[2,1]);
      trous[1,1].RemplacerSuccesseurs(trous[2,1]);
      trous[1,2].RemplacerSuccesseurs(trous[2,3]);
      trous[1,3].RemplacerSuccesseurs(trous[2,3]);
      trous[1,4].RemplacerSuccesseurs(trous[2,5]);
      trous[1,5].RemplacerSuccesseurs(trous[2,5]);
      trous[1,6].RemplacerSuccesseurs(trous[2,7]);
      trous[1,7].RemplacerSuccesseurs(trous[2,7]);

      trous[2,0].RemplacerSuccesseurs(trous[3,0], trous[2,1]);
      trous[2,1].RemplacerSuccesseurs(trous[2,0], trous[2,2]);
      trous[2,2].RemplacerSuccesseurs(trous[2,1], trous[2,3], trous[3,1]);
      trous[2,3].RemplacerSuccesseurs(trous[2,2], trous[2,4]);
      trous[2,4].RemplacerSuccesseurs(trous[2,3], trous[2,5]);
      trous[2,5].RemplacerSuccesseurs(trous[2,4], trous[2,6]);
      trous[2,6].RemplacerSuccesseurs(trous[2,5], trous[2,7], trous[3,5]);
      trous[2,7].RemplacerSuccesseurs(trous[2,6], trous[2,8]);
      trous[2,8].RemplacerSuccesseurs(trous[2,7], trous[3,6]);

      trous[3,0].RemplacerSuccesseurs(trous[2,0], trous[3,1]);
      trous[3,1].RemplacerSuccesseurs(trous[3,0], trous[3,2], trous[2,2]);
      trous[3,2].RemplacerSuccesseurs(trous[3,1], trous[3,3]);
      trous[3,3].RemplacerSuccesseurs(trous[3,2], trous[3,4], trous[4,3], trous[4,4]);
      trous[3,4].RemplacerSuccesseurs(trous[3,3], trous[3,5]);
      trous[3,5].RemplacerSuccesseurs(trous[3,4], trous[3,6], trous[2,6]);
      trous[3,6].RemplacerSuccesseurs(trous[3,5], trous[2,8]);

      trous[4,0].RemplacerSuccesseurs(trous[5,0], trous[4,1]);
      trous[4,1].RemplacerSuccesseurs(trous[4,0], trous[4,2]);
      trous[4,2].RemplacerSuccesseurs(trous[4,1], trous[4,3], trous[5,1]);
      trous[4,3].RemplacerSuccesseurs(trous[4,2], trous[4,4], trous[3,3]);
      trous[4,4].RemplacerSuccesseurs(trous[4,3], trous[4,5], trous[3,3]);
      trous[4,5].RemplacerSuccesseurs(trous[4,4], trous[4,6]);
      trous[4,6].RemplacerSuccesseurs(trous[4,5], trous[4,7]);
      trous[4,7].RemplacerSuccesseurs(trous[4,6], trous[5,4]);

      trous[5,0].RemplacerSuccesseurs(trous[5,1], trous[4,0]);
      trous[5,1].RemplacerSuccesseurs(trous[5,0], trous[5,2], trous[4,2]);
      trous[5,2].RemplacerSuccesseurs(trous[5,1], trous[5,3], trous[6,0]);
      trous[5,3].RemplacerSuccesseurs(trous[5,2], trous[5,4], trous[4,5]);
      trous[5,4].RemplacerSuccesseurs(trous[5,3], trous[4,7]);

      trous[6,0].RemplacerSuccesseurs(trous[5,2], trous[7,3], trous[7,4]);

      trous[7,0].RemplacerSuccesseurs(trous[8,0], trous[7,1]);
      trous[7,1].RemplacerSuccesseurs(trous[7,0], trous[7,2]);
      trous[7,2].RemplacerSuccesseurs(trous[7,1], trous[7,3]);
      trous[7,3].RemplacerSuccesseurs(trous[7,2], trous[7,4], trous[6,0]);
      trous[7,4].RemplacerSuccesseurs(trous[7,3], trous[7,5], trous[6,0]);
      trous[7,5].RemplacerSuccesseurs(trous[7,4], trous[7,6]);
      trous[7,6].RemplacerSuccesseurs(trous[7,5], trous[7,7]);
      trous[7,7].RemplacerSuccesseurs(trous[7,6], trous[8,8]);

      trous[8,0].RemplacerSuccesseurs(trous[7,0], trous[8,1]);
      trous[8,1].RemplacerSuccesseurs(trous[8,0], trous[8,2]);
      trous[8,2].RemplacerSuccesseurs(trous[8,1], trous[8,3]);
      trous[8,3].RemplacerSuccesseurs(trous[8,2], trous[8,4]);
      trous[8,4].RemplacerSuccesseurs(trous[8,3], trous[8,5], trous[9,0]);
      trous[8,5].RemplacerSuccesseurs(trous[8,4], trous[8,6]);
      trous[8,6].RemplacerSuccesseurs(trous[8,5], trous[8,7]);
      trous[8,7].RemplacerSuccesseurs(trous[8,6], trous[8,8]);
      trous[8,8].RemplacerSuccesseurs(trous[8,7], trous[7,7]);

      trous[9,0].RemplacerSuccesseurs(trous[8,4]);

      return trous;
    }

    private static void Ligne(int ligne, Trou[,] trous, int nombreDeColonnes)
    {
      for (var y = 0; y < nombreDeColonnes; y++)
        trous[ligne, y] = new Trou(P($"{ligne},{y}"));
    }
  }
}