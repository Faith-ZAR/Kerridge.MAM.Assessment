﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerridge.MAM.Data
{
    public class JsonDatabase
    {
        private readonly string _filePath;

        public JsonDatabase(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> LoadData<T>()
        {
            if(!File.Exists(_filePath))
            {
                return new List<T>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }

        public void SaveData<T>(List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
