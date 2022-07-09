using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Intra_Maurice.Models
{
    public class Facture
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public string CarteCredit { get; set; }
        public double Montant { get; set; }
    }
}
