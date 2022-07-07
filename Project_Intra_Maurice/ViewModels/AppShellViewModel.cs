using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project_Intra_Maurice.ViewModels
{
    internal class AppShellViewModel : BaseViewModel
    {
        private string counter { get; set; }
        public string Counter
        {
            get => counter;
            set
            {
                counter = App.panier.CountPanier().ToString();
                OnPropertyChanged();
            }
        }
    }
}
