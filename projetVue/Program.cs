using projetController;
using projetModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetVue
{
    class Program
    {
        static void Main(string[] args)
        {
            //lecture de la liste
            GestionAuteur ga = new GestionAuteur();
            string chemin = @"c:/users/yves/documents/bibliotheque.accdb";//

            File.Copy(chemin, chemin.Replace("bibliotheque", "bibiliotheque_xxx"));
            List<Auteur> listeAuteurs = ga.GetListeAuteurs(chemin);
            Console.WriteLine(listeAuteurs.Count);
            foreach(Auteur a in listeAuteurs)
            {
                Console.WriteLine(a.GetInfos());
            }

            Auteur auteur = new Auteur();
            auteur.Nom = "Ginier";
            auteur.Prenom = "Loic";
            auteur.DateNaissance = new DateTime(2000, 3, 20);
            //insertion d'un nouvel enregistrement
            //ga.InsertAuteur(chemin, auteur);
            ga.UpdateAuteur(chemin);
            ga.DeleteAuteur(chemin);
            //lecture liste
            listeAuteurs = ga.GetListeAuteurs(chemin);
            Console.WriteLine(listeAuteurs.Count);
            foreach (Auteur a in listeAuteurs)
            {
                Console.WriteLine(a.GetInfos());
            }

            Console.ReadLine();
        }
    }
}
