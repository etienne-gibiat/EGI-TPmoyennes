using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    internal class Classe
    {
            
        public List<Eleve> eleves;
        public List<String> matieres;
        public readonly int maxEleves = 30;
        public readonly int maxMatieres = 10;
        public string nomClasse;

        

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();   
            this.matieres = new List<String>(); 
        }

        internal void ajouterEleve(string nom, string Prenom)
        {
            if (maxEleves <= eleves.Count)
                throw new IndexOutOfRangeException($"The collection eleves can hold only {maxEleves} elements.");
            eleves.Add(new Eleve(nom, Prenom));
            
        }

        internal void ajouterMatiere(string nomMatiere)
        {
            if (maxMatieres <= matieres.Count)
                throw new IndexOutOfRangeException($"The collection matieres can hold only {maxMatieres} elements.");
            matieres.Add(nomMatiere);

        }

        internal float moyenneGeneral()
        {
            float cumulMoyenne = 0;
            for (int i = 0; i < matieres.Count; i++){
                cumulMoyenne += moyenneMatiere(i);
            }
            return (float)(Math.Truncate(100 * (cumulMoyenne / matieres.Count)) / 100);
        }

        internal float moyenneMatiere(int nMatiere)
        {
            float cumulMoyenne = 0;
            for(int i = 0; i < eleves.Count; i++)
            {
                cumulMoyenne += eleves[i].moyenneMatiere(nMatiere);
            }
            return (float)(Math.Truncate(100 * (cumulMoyenne / eleves.Count)) / 100);
        }
    }
}
