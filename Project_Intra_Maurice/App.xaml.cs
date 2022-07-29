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
        public static Panier panier;
        public static DbContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            Context = new DbContext();
            panier = new Panier();
            MainPage = new AppShell();
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
