using Project_Intra_Maurice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Internals;
using System.Threading.Tasks;
using Project_Intra_Maurice.Views;

namespace Project_Intra_Maurice.ViewModels
{
    internal class PanierViewModel : BaseViewModel
    {  
        public ObservableCollection<SmartDevice> PanierContentsList { get; private set; }
        public double Total { get; set; }

        public Command RemoveItemFromCartCmd { get; private set; }
        public Command NavigateToPaymentCmd { get; private set; }
        public Command ViderPanierCmd { get; private set; }

        public PanierViewModel()
        {
            this.PanierContentsList = new ObservableCollection<SmartDevice>();
            this.RemoveItemFromCartCmd = new Command(RemoveItemFromCart);
            this.NavigateToPaymentCmd = new Command(NavigateToPayment, ValidateNavigation);
            this.ViderPanierCmd = new Command(ViderPanier, ValidationViderPanier);
            //Pour chaque changement apporter au panier active ou desactive le boutton
            this.PropertyChanged += (_, __) => NavigateToPaymentCmd.ChangeCanExecute();
            this.PropertyChanged += (_,__) => ViderPanierCmd.ChangeCanExecute();
        }

        private bool ValidationViderPanier(object arg)
        {
            return App.panier.GetContent().Count > 0 ? true : false;
        }

        private async void ViderPanier(object obj)
        {
            var res = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment vider le panier?", "Non", "Oui");
            if (res) return;

            App.panier.ClearPanier();
            LoadItem();
        }

        private void NavigateToPayment(object obj)
        {
            Shell.Current.GoToAsync(nameof(FacturePage));
        }

        private bool ValidateNavigation(object arg)
        {
            return App.panier.CountPanier() > 0 ? true : false;
        }

        private async void RemoveItemFromCart(object obj)
        {
            var res = await Application.Current.MainPage.DisplayAlert("Confirmation", $"Voulez-vous vraiment supprimer {(obj as SmartDevice).Modele}?", "Non", "Oui");
            if (res) return;
                
            App.panier.RemoveProduct((obj as SmartDevice).Id);
            LoadItem();
        }

        public void LoadItem()
        {
            try
            {
                this.PanierContentsList.Clear();
                App.panier.GetContent().ForEach(x => this.PanierContentsList.Add(x));
                Total = App.panier.GetTotal();
                OnPropertyChanged(nameof(Total));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
