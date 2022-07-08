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
        public int Counter { get; set; }

        public AppShellViewModel()
        {
            MessagingCenter.Subscribe<Panier, int>(this, "update counter", (x, data) =>
            {
                Counter = x.CountPanier();
                OnPropertyChanged(nameof(Counter));
            });
        }
    }
}
