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
    public partial class PanierPage : ContentPage
    {
        PanierViewModel viewModel;
        public PanierPage()
        {
            InitializeComponent();
            this.viewModel = new PanierViewModel();
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.viewModel.RefreshList();
            this.BindingContext = null;
            this.BindingContext = viewModel;
        }
    }
}