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

namespace Project_Intra_Maurice.ViewModels
{
    internal class PanierViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private ObservableCollection<SmartDevice> panierList;
        public ObservableCollection<SmartDevice> PanierContentsList
        {
            get => panierList;
            set
            {
                this.panierList = value;
                OnProperyChanged();
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

        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadItem()
        {
            try
            {
                this.PanierContentsList.Clear();
                var items = App.panier.GetContent();
                foreach (var item in items)
                {
                    this.PanierContentsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void RefreshList()
        {
            LoadItem();
        }

    }
}
