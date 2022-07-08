using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Intra_Maurice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacturePage : ContentPage
    {
        public FacturePage()
        {
            InitializeComponent();
            this.BindingContext = new FactureViewModel();
        }
    }
}