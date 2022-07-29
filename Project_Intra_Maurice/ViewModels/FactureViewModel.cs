using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Project_Intra_Maurice.ViewModels
{
    internal class FactureViewModel : BaseViewModel
    {
        private string nom;
        private string prenom;
        private string adresse;
        private string courriel;
        private string carteCredit;
        private double montant;
        private bool prenomValide;
        private bool nomValide;
        private bool adresseValide;
        private bool telephoneValide;
        private bool courrielValide;
        private bool carteCreditValide;
        private string telephone;

        public string Nom { get => nom; set { nom = value; OnPropertyChanged(); } }
        public string Prenom { get => prenom; set { prenom = value; OnPropertyChanged(); } }
        public string Adresse { get => adresse; set { adresse = value; OnPropertyChanged(); } }
        public string Telephone { get => telephone; set { telephone = value; OnPropertyChanged(); } }
        public string Courriel { get => courriel; set { courriel = value; OnPropertyChanged(); } }
        public string CarteCredit { get => carteCredit; set { carteCredit = value; OnPropertyChanged(); } }
        public double Montant { get => montant; set { montant = value; OnPropertyChanged(); } }
        public bool PrenomValide { get => prenomValide; set { prenomValide = value; OnPropertyChanged(); } }
        public bool NomValide { get => nomValide; set { nomValide = value; OnPropertyChanged(); } }
        public bool AdresseValide { get => adresseValide; set { adresseValide = value; OnPropertyChanged(); } }
        public bool TelephoneValide { get => telephoneValide; set { telephoneValide = value; OnPropertyChanged(); } }
        public bool CourrielValide { get => courrielValide; set { courrielValide = value; OnPropertyChanged(); } }
        public bool CarteCreditValide { get => carteCreditValide; set { carteCreditValide = value; OnPropertyChanged(); } }


        public Command PayementConfirmCmd { get; private set; }
        public Command PayementCancelCmd { get; private set; }
        public FactureViewModel()
        {
            this.PayementConfirmCmd = new Command(PayementConfirm, CanConfirmPayement);
            this.PayementCancelCmd = new Command(PayementCancel);
            this.Montant = App.panier.GetTotal();
            this.PropertyChanged += (_,__) => PayementConfirmCmd.ChangeCanExecute();
        }

        //Fait la validation pour la confirmation du payment si une des validation retourn false desactive le boutton
        //Si tous les validation passe active le boutton de confirmation de payment
        private bool CanConfirmPayement(object arg)
        {
            return !string.IsNullOrEmpty(this.Prenom)
                && !string.IsNullOrEmpty(this.Nom)
                && !string.IsNullOrEmpty(this.Adresse)
                && !string.IsNullOrEmpty(this.Telephone)
                && Regex.IsMatch(this.Telephone, @"^\d{3} \d{3}-\d{4}$")
                && !string.IsNullOrEmpty(this.Courriel)
                && Regex.IsMatch(this.Courriel, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                && !string.IsNullOrEmpty(this.CarteCredit)
                && Regex.IsMatch(this.CarteCredit, @"^\d{14,16}$");
        }

        private async void PayementConfirm(object obj)
        {

            var res = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous passez la commande?", "Oui", "Non");
            if (!res) return;

            Facture facture = new Facture()
            {
                Prenom = this.Prenom,
                Nom = this.Nom,
                Adresse = this.Adresse,
                Telephone = this.Telephone,
                Courriel = this.Courriel,
                CarteCredit = this.CarteCredit,
                Montant = this.Montant,
            };

            //App.Context.InsertFactureAsync(facture);
            App.panier.ClearPanier();
         
            await Shell.Current.GoToAsync("..");
        }

        private async void PayementCancel(object obj)
        {
            var res = await Application.Current.MainPage.DisplayAlert("Annulation", "Voulez-vous annuler la commande?", "Oui", "Non");
            if (!res) return;

            this.Prenom = string.Empty;
            this.Nom = string.Empty;
            this.Adresse = string.Empty;
            this.Telephone = string.Empty;
            this.Courriel = string.Empty;
            this.CarteCredit = string.Empty;
            await Shell.Current.GoToAsync("..");
        }
    }
}
