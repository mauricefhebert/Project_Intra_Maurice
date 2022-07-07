using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.ViewModels;
using Project_Intra_Maurice.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Project_Intra_Maurice
{
    public partial class AppShell : Shell, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new PanierViewModel();
            Routing.RegisterRoute(nameof(AccueilPage), typeof(AccueilPage));
            Routing.RegisterRoute(nameof(TelephoneDevicePage), typeof(TelephoneDevicePage));
            Routing.RegisterRoute(nameof(TabletteDevicePage), typeof(TabletteDevicePage));
            Routing.RegisterRoute(nameof(MontreIntelligentePage), typeof(MontreIntelligentePage));
            Routing.RegisterRoute(nameof(PanierPage), typeof(PanierPage));
        }

        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
