using Project_Intra_Maurice.ViewModels;
using Project_Intra_Maurice.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project_Intra_Maurice
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListDevicePage), typeof(ListDevicePage));
        }

    }
}
