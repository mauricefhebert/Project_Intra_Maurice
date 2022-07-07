using Project_Intra_Maurice.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Project_Intra_Maurice.Data
{
    public class DbContext
    {
        private const SQLite.SQLiteOpenFlags openFlags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // flag to create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        private readonly SQLiteAsyncConnection database;
        public DbContext(string dbName)
        {
            string baseDbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = Path.Combine(baseDbPath, dbName);
            database = new SQLiteAsyncConnection(dbPath, openFlags);
            // creer une table dans la base de donnee si elle n'existe pas et initialise la connexion
            var res = database.CreateTableAsync<SmartDevice>().Result;
            if (res == CreateTableResult.Created)
                SeedDatabase();
        }

        private async void SeedDatabase()
        {
            try
            {
                SmartDevice smartDevice;
                // inserer l'objet a la table
                smartDevice = new SmartDevice()
                {
                    Modele = "Iphone 13",
                    Farbiquant = "Apple",
                    Platform = "IOS",
                    Type = "Téléphone",
                    Prix = 1300,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-13-pro-silver-select?wid=940&hei=1112&fmt=png-alpha&.v=1645552345849"
                };
                await database.InsertAsync(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Pixel 5",
                    Farbiquant = "Google",
                    Platform = "Android",
                    Type = "Téléphone",
                    Prix = 1000,
                    ImageURL = "https://9to5google.com/wp-content/uploads/sites/4/2020/09/Eir8AzbWkAMQPaG.png"
                };
                await database.InsertAsync(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy s21",
                    Farbiquant = "Samsung",
                    Platform = "Android",
                    Type = "Téléphone",
                    Prix = 1200,
                    ImageURL = "https://the-hub.cellucity.co.za/wp-content/uploads/2022/01/Samsung-galaxy-S21-FE-in-Olive-green.jpg"
                };
                await database.InsertAsync(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Moto g pure",
                    Farbiquant = "Motorola",
                    Platform = "Android",
                    Type = "Téléphone",
                    Prix = 800,
                    ImageURL = "https://motorolacaen.vtexassets.com/arquivos/ids/156824-1200-auto?width=1200&height=auto&aspect=true"
                };
                await database.InsertAsync(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Series 7",
                    Farbiquant = "Apple",
                    Platform = "IOS",
                    Type = "Montre Intelligente",
                    Prix = 959,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ML6H3ref_VW_34FR+watch-45-stainless-gold-cell-7s_VW_34FR_WF_CO?wid=700&hei=700&trim=1%2C0&fmt=p-jpg&qlt=95&.v=1630364962000%2C1631661863000"
                };
                await database.InsertAsync(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "iPad Pro",
                    Farbiquant = "Apple",
                    Platform = "IOS",
                    Type = "Tablette",
                    Prix = 1399,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ipad-pro-12-11-select-202104?wid=545&hei=550&fmt=jpeg&qlt=95&.v=1617067380000"
                };
                await database.InsertAsync(smartDevice);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public Task<List<SmartDevice>> GetAllAsync()
        {
            //Lire toutes les taches.
            return database.Table<SmartDevice>().ToListAsync();
        }

        public Task<SmartDevice> GetByIdAsync(int id)
        {
            // Lire une tache spécifique avec son id.
            return database.Table<SmartDevice>().Where(i => i.Id == id).FirstOrDefaultAsync();
            // utiliser la methode GetAsync a la place du Table.Where
        }

        public Task<int> InsertAsync(SmartDevice smartDevice)
        {
            // insérer une nouvelle tache
            return database.InsertAsync(smartDevice);
        }

        //Delete those method later if i don't use them
        public Task<int> UpdateAsync(SmartDevice smartDevice)
        {
            // mettre à jours une tache existante.
            return database.UpdateAsync(smartDevice);
        }

        public Task<int> DeleteAsync(SmartDevice smartDevice)
        {
            // supprimer une tache existante
            return database.DeleteAsync(smartDevice);
        }

        public Task<int> DeleteAsyncById(int id)
        {
            // supprimer une tache existante par le id
            return database.DeleteAsync(id);
        }
    }
}
