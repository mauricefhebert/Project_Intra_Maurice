using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
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