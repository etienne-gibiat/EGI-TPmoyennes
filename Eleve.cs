using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{
    internal class Eleve
    {
        public string nom;
        public string prenom;
        public List<Note> notes;
        public readonly int maxNotes = 200;
        private int nextNoteIndex = 0;

        public Eleve(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.notes = new List<Note>();
        }

        internal void ajouterNote(Note note)
        {

            if (maxNotes <= notes.Count)
                throw new IndexOutOfRangeException($"The collection notes can hold only {maxNotes} elements.");
            notes.Add(note);
            
        }

        internal float moyenneGeneral()
        {
            float cumulNotes = 0;
            int compteurNotes = 0;
            float moyenneMatiere;
            for (int i = 0; i < 10; i++) {
                moyenneMatiere = this.moyenneMatiere(i);
                if(moyenneMatiere != -1)
                {
                    cumulNotes += moyenneMatiere;
                    compteurNotes++;
                }         
            }
            return (float)(Math.Truncate(100 * (cumulNotes / compteurNotes)) / 100);
        }

        internal float moyenneMatiere(int nMatiere)
        {
            float cumulNotes = 0;
            int compteurNotes = 0;
            for(int i = 0;i < notes.Count; i++){
                if (notes[i].matiere == nMatiere)
                {
                    cumulNotes += notes[i].note;
                    compteurNotes++;
                }
                    
            }
            if(compteurNotes == 0)
                return -1;
            else
                return (float)(Math.Truncate(100 * (cumulNotes / compteurNotes)) / 100);
        }
    }
}
