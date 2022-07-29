using Newtonsoft.Json;
using Project_Intra_Maurice.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace Project_Intra_Maurice.Data
{
    public class DbContext
    {
        private static string BaseAddress = "https://apiprojectfinalmobile.azurewebsites.net";
        private HttpClient httpClient;
        private JsonSerializerSettings serialiserOptions;

        public DbContext()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            };
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(BaseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.serialiserOptions = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };
            SeedDatabaseAsync();
        }

        public async Task<List<SmartDevice>> GetAllAsync()
        {
            List<SmartDevice> smartDevices = new List<SmartDevice>();
            try
            {
                Uri uri = new Uri($"{BaseAddress}/api/smartdevice");
                HttpResponseMessage res = await httpClient.GetAsync(uri);
                if(res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    smartDevices = JsonConvert.DeserializeObject<List<SmartDevice>>(content);
                }

            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return smartDevices;
        }

        public async Task<SmartDevice> InsertDevice(SmartDevice device)
        {
            Uri uri = new Uri($"{BaseAddress}/api/smartdevice");
            try
            {
                string json = JsonConvert.SerializeObject(device, serialiserOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await httpClient.PostAsync(uri,content);
                if (res.IsSuccessStatusCode)
                {
                    // on récupère l'usager retourné par l'api
                    string repcontent = await res.Content.ReadAsStringAsync();
                    device = JsonConvert.DeserializeObject<SmartDevice>(repcontent);
                    return device;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
        //public async Task<int> InsertFactureAsync(Facture facture)
        //{
        //    //return await InsertDevice(facture);
        //}

        public async Task LoadItem(ObservableCollection<SmartDevice> collection, string type)
        {
            try
            {
                collection.Clear();
                var items = await GetAllAsync();
                foreach (var item in items)
                {
                    if(item.Type == type)
                        collection.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void SeedDatabaseAsync()
        {
            try
            {
                SmartDevice smartDevice;
                // Téléphone
                smartDevice = new SmartDevice()
                {
                    Modele = "Iphone 13",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Téléphone intelligent",
                    Prix = 1300,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-13-pro-silver-select?wid=940&hei=1112&fmt=png-alpha&.v=1645552345849"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Pixel 5",
                    Fabriquant = "Google",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1000,
                    ImageURL = "https://9to5google.com/wp-content/uploads/sites/4/2020/09/Eir8AzbWkAMQPaG.png"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy s21",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1200,
                    ImageURL = "https://the-hub.cellucity.co.za/wp-content/uploads/2022/01/Samsung-galaxy-S21-FE-in-Olive-green.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Moto g pure",
                    Fabriquant = "Motorola",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 800,
                    ImageURL = "https://motorolacaen.vtexassets.com/arquivos/ids/156824-1200-auto?width=1200&height=auto&aspect=true"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Iphone 13",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Téléphone intelligent",
                    Prix = 1300,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-13-pro-silver-select?wid=940&hei=1112&fmt=png-alpha&.v=1645552345849"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Pixel 5",
                    Fabriquant = "Google",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1000,
                    ImageURL = "https://9to5google.com/wp-content/uploads/sites/4/2020/09/Eir8AzbWkAMQPaG.png"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy s21",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1200,
                    ImageURL = "https://the-hub.cellucity.co.za/wp-content/uploads/2022/01/Samsung-galaxy-S21-FE-in-Olive-green.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Moto g pure",
                    Fabriquant = "Motorola",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 800,
                    ImageURL = "https://motorolacaen.vtexassets.com/arquivos/ids/156824-1200-auto?width=1200&height=auto&aspect=true"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Iphone 13",
                    Fabriquant = "Apple",
                    Platform = "IOS",
                    Type = "Téléphone intelligent",
                    Prix = 1300,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-13-pro-silver-select?wid=940&hei=1112&fmt=png-alpha&.v=1645552345849"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Pixel 5",
                    Fabriquant = "Google",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1000,
                    ImageURL = "https://9to5google.com/wp-content/uploads/sites/4/2020/09/Eir8AzbWkAMQPaG.png"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy s21",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 1200,
                    ImageURL = "https://the-hub.cellucity.co.za/wp-content/uploads/2022/01/Samsung-galaxy-S21-FE-in-Olive-green.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Moto g pure",
                    Fabriquant = "Motorola",
                    Platform = "Android",
                    Type = "Téléphone intelligent",
                    Prix = 800,
                    ImageURL = "https://motorolacaen.vtexassets.com/arquivos/ids/156824-1200-auto?width=1200&height=auto&aspect=true"
                };
                await InsertDevice(smartDevice);

                //Tablette
                smartDevice = new SmartDevice()
                {
                    Modele = "iPad Pro",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Tablette",
                    Prix = 1399,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ipad-pro-12-11-select-202104?wid=545&hei=550&fmt=jpeg&qlt=95&.v=1617067380000"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Tab S6 Lite",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Tablette",
                    Prix = 430,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/1500x1500/145/14584/14584045.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Tab A7 Lite",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Tablette",
                    Prix = 230,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/1500x1500/157/15745/15745832.jpeg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Surface Pro",
                    Fabriquant = "Microsoft",
                    Platform = "Autre",
                    Type = "Tablette",
                    Prix = 880,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/155/15541/15541379.png"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "iPad Pro",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Tablette",
                    Prix = 1399,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ipad-pro-12-11-select-202104?wid=545&hei=550&fmt=jpeg&qlt=95&.v=1617067380000"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Tab S6 Lite",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Tablette",
                    Prix = 430,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/1500x1500/145/14584/14584045.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Tab A7 Lite",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Tablette",
                    Prix = 230,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/1500x1500/157/15745/15745832.jpeg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Surface Pro",
                    Fabriquant = "Microsoft",
                    Platform = "Autre",
                    Type = "Tablette",
                    Prix = 880,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/155/15541/15541379.png"
                };
                await InsertDevice(smartDevice);
                //Montre
                smartDevice = new SmartDevice()
                {
                    Modele = "Series 7",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Montre intelligente",
                    Prix = 959,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ML6H3ref_VW_34FR+watch-45-stainless-gold-cell-7s_VW_34FR_WF_CO?wid=700&hei=700&trim=1%2C0&fmt=p-jpg&qlt=95&.v=1630364962000%2C1631661863000"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Versa 3",
                    Fabriquant = "Fitbit",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 310,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/148/14882/14882492.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Watch4",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 270,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/158/15887/15887537.jpeg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "GT 2 Pro",
                    Fabriquant = "HUAWEI",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 430,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/148/14882/14882492.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Series 7",
                    Fabriquant = "Apple",
                    Platform = "iOS",
                    Type = "Montre intelligente",
                    Prix = 959,
                    ImageURL = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ML6H3ref_VW_34FR+watch-45-stainless-gold-cell-7s_VW_34FR_WF_CO?wid=700&hei=700&trim=1%2C0&fmt=p-jpg&qlt=95&.v=1630364962000%2C1631661863000"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Versa 3",
                    Fabriquant = "Fitbit",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 310,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/148/14882/14882492.jpg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "Galaxy Watch4",
                    Fabriquant = "Samsung",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 270,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/158/15887/15887537.jpeg"
                };
                await InsertDevice(smartDevice);
                smartDevice = new SmartDevice()
                {
                    Modele = "GT 2 Pro",
                    Fabriquant = "HUAWEI",
                    Platform = "Android",
                    Type = "Montre intelligente",
                    Prix = 430,
                    ImageURL = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/148/14882/14882492.jpg"
                };
                await InsertDevice(smartDevice);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
