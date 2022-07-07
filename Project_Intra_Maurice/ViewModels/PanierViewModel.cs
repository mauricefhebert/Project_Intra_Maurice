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

namespace Project_Intra_Maurice.ViewModels
{
    internal class PanierViewModel : BaseViewModel
    {  
        private ObservableCollection<SmartDevice> panierList;
        public ObservableCollection<SmartDevice> PanierContentsList
        {
            get => panierList;
            set
            {
                this.panierList = value;
                OnPropertyChanged();
            }
        }

        public Command RemoveItemFromCartCmd { get; private set; }

        public PanierViewModel()
        {
            this.PanierContentsList = new ObservableCollection<SmartDevice>();
            this.RemoveItemFromCartCmd = new Command(RemoveItemFromCart);
            this.PropertyChanged += (_, __) => RemoveItemFromCartCmd.ChangeCanExecute();
            
        }

        private void RemoveItemFromCart(object obj)
        {
            App.panier.RemoveProduct((obj as SmartDevice).Id);
            LoadItem();
        }

        public void LoadItem()
        {
            try
            {
                this.PanierContentsList.Clear();
                App.panier.GetContent().ForEach(x => this.PanierContentsList.Add(x));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
