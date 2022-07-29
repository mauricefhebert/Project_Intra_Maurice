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

        public async Task<Facture> InsertFactureAsync(Facture facture)
        {
            Uri uri = new Uri($"{BaseAddress}/api/facture");
            try
            {
                string json = JsonConvert.SerializeObject(facture, serialiserOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await httpClient.PostAsync(uri, content);
                if (res.IsSuccessStatusCode)
                {
                    // on récupère l'usager retourné par l'api
                    string repcontent = await res.Content.ReadAsStringAsync();
                    facture = JsonConvert.DeserializeObject<Facture>(repcontent);
                    return facture;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

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
    }
}
