using Project_Intra_Maurice.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project_Intra_Maurice.Models
{
    public class Panier : BaseViewModel
    {
        private ObservableCollection<SmartDevice> content;
        public Panier()
        {
            this.content = new ObservableCollection<SmartDevice>();
        }
        public ObservableCollection<SmartDevice> GetContent() { return content; }
        public  SmartDevice GetProductById(int id)
        {
            return this.content.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(SmartDevice product)
        {
            this.content.Add(product);
            MessagingCenter.Send(this, "update counter", this.CountPanier());
        }
        public void RemoveProduct(int id)
        {
            SmartDevice product = this.content.FirstOrDefault(p => p.Id == id);
            this.content.Remove(product);
            MessagingCenter.Send(this, "update counter", this.CountPanier());
        }
        public void ClearPanier()
        {
            this.content.Clear();
            MessagingCenter.Send(this, "update counter", this.CountPanier());
        }
        public int CountPanier()
        {
            return this.content.Count;
        }
        public double GetTotal()
        {
            return this.content.Sum(p => p.Prix);
        }

    }
}
