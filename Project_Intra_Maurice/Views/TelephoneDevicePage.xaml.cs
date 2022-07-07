using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice.Views
{
    public partial class TelephoneDevicePage : ContentPage
    {
        TelephoneDeviceViewModel viewModel;
        public TelephoneDevicePage()
        {
            InitializeComponent();
            viewModel = new TelephoneDeviceViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = null;
            BindingContext = this.viewModel;
            viewModel.RefreshList();
        }
    }
}