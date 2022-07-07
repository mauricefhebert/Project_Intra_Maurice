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
    internal class MontreIntelligenteDeviceViewModel : BaseViewModel
    {
        public ObservableCollection<SmartDevice> SmartDevices { get; set; }
        public Command AddItemToCartCmd { get; private set; }

        public MontreIntelligenteDeviceViewModel()
        {
            this.SmartDevices = new ObservableCollection<SmartDevice>();
            this.AddItemToCartCmd = new Command(AddItemToCart);
        }

        private void AddItemToCart(object obj)
        {
            App.panier.AddProduct(obj as SmartDevice);
        }

        private async void LoadItem()
        {
            try
            {
                this.SmartDevices.Clear();
                var items = await App.Context.GetAllByTypeAsync("Montre Intelligente");
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
