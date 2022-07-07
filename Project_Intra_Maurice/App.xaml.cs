using Project_Intra_Maurice.Data;
using Project_Intra_Maurice.Models;
using Project_Intra_Maurice.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice
{
    public partial class App : Application
    {
        private static DbContext context;
        public static Panier panier;
        public static DbContext Context => context;
        public App()
        {
            InitializeComponent();
            panier = new Panier();
            MainPage = new AppShell();
            context = new DbContext("DbSmartDevice.db3");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
