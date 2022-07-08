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

namespace Project_Intra_Maurice.ViewModels
{
    internal class PanierViewModel : BaseViewModel
    {  
        public ObservableCollection<SmartDevice> PanierContentsList { get; private set; }

        private double total { get; set; }
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }

        public Command RemoveItemFromCartCmd { get; private set; }

        public PanierViewModel()
        {
            this.PanierContentsList = new ObservableCollection<SmartDevice>();
            this.RemoveItemFromCartCmd = new Command(RemoveItemFromCart);
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
                Total = this.PanierContentsList.Sum(x => x.Prix);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
