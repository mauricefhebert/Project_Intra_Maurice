using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice.Views
{
    public partial class ListDevicePage : ContentPage
    {
        ListDeviceViewModel viewModel;
        public ListDevicePage()
        {
            InitializeComponent();
            viewModel = new ListDeviceViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshList();
            BindingContext = null;
            BindingContext = this.viewModel;
        }
    }
}