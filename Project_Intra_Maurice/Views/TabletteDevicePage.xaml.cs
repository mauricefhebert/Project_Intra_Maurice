﻿using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabletteDevicePage : ContentPage
    {
        TabletteDeviceViewModel viewModel;
        public TabletteDevicePage()
        {
            InitializeComponent();
            viewModel = new TabletteDeviceViewModel();
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