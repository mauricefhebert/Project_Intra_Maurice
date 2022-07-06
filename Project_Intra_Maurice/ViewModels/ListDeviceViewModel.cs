using Project_Intra_Maurice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project_Intra_Maurice.ViewModels
{
    public class ListDeviceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SmartDevice> SmartDevices { get; set; }

        public ListDeviceViewModel()
        {
            this.SmartDevices = new ObservableCollection<SmartDevice>();
        }
        
        //Permet l'utilisation de PropertyChanged sans specifier la proprieter a changer
        public void OnProperyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadTaches()
        {
            try
            {
                this.SmartDevices.Clear();
                var items = await App.Context.GetAllAsync();
                foreach (var item in items)
                {
                    this.SmartDevices.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void RefreshList()
        {
            LoadTaches();
        }

    }
}
