using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Linq.Enumerable;
using static Barricades.Domaine.Couleur;

namespace Barricades.Domaine
{
  public class Plateau
  {
    private List<Ligne> _lignes;
    public Trou this[Ligne ligne, int y] => _lignes[ligne.X].Trous[y];

    public Plateau()
    {
      TrouerLePlateau();
      PoserLesPions();
    }

    private void TrouerLePlateau()
    {
      _lignes = new List<Ligne>();

      var depart1 = new Ligne(0);
      depart1.TrouerEn(Range(0, 8));
      _lignes.Add(depart1);

      var depart2 = new Ligne(1);
      depart2.TrouerEn(Range(0, 8));
      _lignes.Add(depart2);

      var ligne1 = new Ligne(2);
      ligne1.TrouerEn(Range(0, 9));
      _lignes.Add(ligne1);

      var ligne2 = new Ligne(3);
      ligne2.TrouerEn(Range(0, 6));
      _lignes.Add(ligne2);
    }

    private void PoserLesPions()
    {
      PoserPion(new Pion(Bleu), this[new Ligne(0), 0]);
      PoserPion(new Pion(Bleu), this[new Ligne(0), 1]);
      PoserPion(new Pion(Bleu), this[new Ligne(1), 0]);
      PoserPion(new Pion(Bleu), this[new Ligne(1), 1]);
      PoserPion(new Pion(Vert), this[new Ligne(0), 2]);
      PoserPion(new Pion(Vert), this[new Ligne(0), 3]);
      PoserPion(new Pion(Vert), this[new Ligne(1), 2]);
      PoserPion(new Pion(Vert), this[new Ligne(1), 3]);
      PoserPion(new Pion(Jaune), this[new Ligne(0), 4]);
      PoserPion(new Pion(Jaune), this[new Ligne(0), 5]);
      PoserPion(new Pion(Jaune), this[new Ligne(1), 4]);
      PoserPion(new Pion(Jaune), this[new Ligne(1), 5]);
      PoserPion(new Pion(Rouge), this[new Ligne(0), 6]);
      PoserPion(new Pion(Rouge), this[new Ligne(0), 7]);
      PoserPion(new Pion(Rouge), this[new Ligne(1), 6]);
      PoserPion(new Pion(Rouge), this[new Ligne(1), 7]);
      PoserPion(new Pion(Barricade),this[new Ligne(3), 3] );
    }
    
    public void PoserPion(Pion pion, Trou trou)
    {
      this[trou.Ligne, trou.Y].Poser(pion);
      pion.PoserSur(trou);
    }
  }
}
