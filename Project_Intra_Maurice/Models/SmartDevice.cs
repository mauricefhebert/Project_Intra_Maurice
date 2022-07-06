using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Intra_Maurice.Models
{
    public class SmartDevice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Modele { get; set; }
        public string Farbiquant { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public string Prix { get; set; }
        public string ImageURL { get; set; }
    }
}
