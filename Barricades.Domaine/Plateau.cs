using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

      var ligne1 = new LigneDeTrous(0);
      ligne1.TrouerEn(Enumerable.Range(0, 9).ToArray());
      _lignes.Add(ligne1);

      var ligne2 = new LigneDeTrous(1);
      ligne2.TrouerEn(Enumerable.Range(0, 9).ToArray());
      _lignes.Add(ligne2);
    }

    private void PoserLesPions()
    {
      PoserPion(new Pion(Couleur.Bleu), this[new LigneDeTrous(0), 0]);
      PoserPion(new Pion(Couleur.Bleu), this[new LigneDeTrous(0), 1]);
      PoserPion(new Pion(Couleur.Bleu), this[new LigneDeTrous(1), 0]);
      PoserPion(new Pion(Couleur.Bleu), this[new LigneDeTrous(1), 1]);
    }


    public void PoserPion(Pion pion, Trou trou)
    {
      this[trou.Ligne, trou.Y].Poser(pion);
    }
  }
}
