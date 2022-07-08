using Project_Intra_Maurice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Project_Intra_Maurice.ViewModels
{
    internal class AppShellViewModel : BaseViewModel
    {
        private int counter = 0;
        public int Counter
        {
            get { return counter; }
            set 
            { 
                MessagingCenter.Subscribe<Panier, int>(this, "update counter", (x, data) =>
                {
                    counter = x.CountPanier();
                    OnPropertyChanged(nameof(Counter));
                });
            }
        }
    }
}
