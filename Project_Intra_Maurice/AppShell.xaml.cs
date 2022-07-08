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
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AccueilPage), typeof(AccueilPage));
            Routing.RegisterRoute(nameof(TelephoneDevicePage), typeof(TelephoneDevicePage));
            Routing.RegisterRoute(nameof(TabletteDevicePage), typeof(TabletteDevicePage));
            Routing.RegisterRoute(nameof(MontreIntelligentePage), typeof(MontreIntelligentePage));
            Routing.RegisterRoute(nameof(PanierPage), typeof(PanierPage));

            this.BindingContext = new AppShellViewModel();
        }
    }
}
