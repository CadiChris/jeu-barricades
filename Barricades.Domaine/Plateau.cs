using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Barricades.Domaine.Couleur;

namespace Barricades.Domaine
{
  public class Plateau
  {
    private List<LigneDeTrous> _lignes;
    public Trou this[LigneDeTrous ligne, int y] => _lignes[ligne.X].Trous[y];

    public Plateau()
    {
      TrouerLePlateau();
      PoserLesPions();
    }

    private void TrouerLePlateau()
    {
      _lignes = new List<LigneDeTrous>();

      var depart1 = new LigneDeTrous(0);
      depart1.TrouerEn(Enumerable.Range(0, 8).ToArray());
      _lignes.Add(depart1);

      var depart2 = new LigneDeTrous(1);
      depart2.TrouerEn(Enumerable.Range(0, 8).ToArray());
      _lignes.Add(depart2);
    }

    private void PoserLesPions()
    {
      PoserPion(new Pion(Bleu), this[new LigneDeTrous(0), 0]);
      PoserPion(new Pion(Bleu), this[new LigneDeTrous(0), 1]);
      PoserPion(new Pion(Bleu), this[new LigneDeTrous(1), 0]);
      PoserPion(new Pion(Bleu), this[new LigneDeTrous(1), 1]);
      PoserPion(new Pion(Vert), this[new LigneDeTrous(0), 2]);
      PoserPion(new Pion(Vert), this[new LigneDeTrous(0), 3]);
      PoserPion(new Pion(Vert), this[new LigneDeTrous(1), 2]);
      PoserPion(new Pion(Vert), this[new LigneDeTrous(1), 3]);
      PoserPion(new Pion(Jaune), this[new LigneDeTrous(0), 4]);
      PoserPion(new Pion(Jaune), this[new LigneDeTrous(0), 5]);
      PoserPion(new Pion(Jaune), this[new LigneDeTrous(1), 4]);
      PoserPion(new Pion(Jaune), this[new LigneDeTrous(1), 5]);
      PoserPion(new Pion(Rouge), this[new LigneDeTrous(0), 6]);
      PoserPion(new Pion(Rouge), this[new LigneDeTrous(0), 7]);
      PoserPion(new Pion(Rouge), this[new LigneDeTrous(1), 6]);
      PoserPion(new Pion(Rouge), this[new LigneDeTrous(1), 7]);
    }
    
    public void PoserPion(Pion pion, Trou trou)
    {
      this[trou.Ligne, trou.Y].Poser(pion);
      pion.PoserSur(trou);
    }
  }
}
