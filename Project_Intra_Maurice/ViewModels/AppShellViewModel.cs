using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project_Intra_Maurice.ViewModels
{
    internal class AppShellViewModel : BaseViewModel
    {
        private int counter = 0;
        public int Counter
        {
            get { return counter; }
            set { counter = value; OnPropertyChanged(); }
        }
    }
}
