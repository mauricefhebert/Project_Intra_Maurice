using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.Views;
using System;
using System.Collections.Generic;
using System.Text;
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

        public string Nom { get => nom; set { nom = value; OnPropertyChanged(); } }
        public string Prenom { get => prenom; set { prenom = value; OnPropertyChanged(); } }
        public string Adresse { get => adresse; set { adresse = value; OnPropertyChanged(); } }
        public string Courriel { get => courriel; set { courriel = value; OnPropertyChanged(); } }
        public string CarteCredit { get => carteCredit; set { carteCredit = value; OnPropertyChanged();} }
        public double Montant { get => montant; set { montant = value; OnPropertyChanged(); } }

        public Command PayementConfirmCmd { get; private set; }
        public Command PayementCancelCmd { get; private set; }
        public FactureViewModel()
        {
            this.PayementConfirmCmd = new Command(PayementConfirm);
            this.PayementCancelCmd = new Command(PayementCancel);
            this.Montant = App.panier.GetTotal();
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
                Courriel = this.Courriel,
                CarteCredit = this.CarteCredit,
                Montant = this.Montant,
            };

            App.Context.InsertFactureAsync(facture);
            App.panier.ClearPanier();

            await Shell.Current.GoToAsync(nameof(AccueilPage));
;            
        }

        private void PayementCancel(object obj)
        {

        }
    }
}
