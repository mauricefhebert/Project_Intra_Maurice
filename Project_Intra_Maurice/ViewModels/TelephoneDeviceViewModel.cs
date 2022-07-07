﻿using Project_Intra_Maurice.Models;
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
    public class TelephoneDeviceViewModel : BaseViewModel
    {
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

        public void RefreshList()
        {
            App.Context.LoadItem(SmartDevices, "Téléphone");
        }

    }
}
