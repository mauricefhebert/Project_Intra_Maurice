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
    public class TelephoneDeviceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SmartDevice> SmartDevices { get; set; }
        public Command AddItemToCartCmd { get; private set; }

        public TelephoneDeviceViewModel()
        {
            this.SmartDevices = new ObservableCollection<SmartDevice>();
            this.AddItemToCartCmd = new Command(AddItemToCart);
        }

        private void AddItemToCart(object obj)
        {
            App.panier.AddProduct(obj as SmartDevice);
        }

        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadItem()
        {
            try
            {
                this.SmartDevices.Clear();
                var items = await App.Context.GetAllByTypeAsync("Téléphone");
                foreach (var item in items)
                {
                    this.SmartDevices.Add(item);
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
