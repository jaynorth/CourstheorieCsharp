using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetModel
{
    public class Auteur : Base
    {
        public int CodeAuteur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        public Auteur()
        {
            this.nomDeLaTable = "Auteur";
        }

        public string DateNaissanceString()
        {
           
                return DateNaissance.ToString("dd.MM.yyyy");
            
        }

        public override string GetInfos()
        {
            return $"CodeAuteur = {CodeAuteur}, Nom = {Nom}, Prenom = {Prenom}, Date de naissance = {DateNaissanceString()}";
        }



 

    }
}
