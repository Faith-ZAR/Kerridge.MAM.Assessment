using Kerridge.MAM.Data;
using Kerridge.MAM.Data.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Kerridge.MAM.Services.Repositories
{
    public class JsonDBRepository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;
        private readonly string _dataSet;

        public JsonDBRepository(string filePath, string dataSet)
        {
            _filePath = filePath;
            _dataSet = dataSet;
        }

        #region JSON DATA MANAGEMENT
        internal JObject LoadData()
        {
            if(!File.Exists(_filePath))
            {
                return new JObject();
            }

            var data = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<JObject>(data);
        }

        private void StoreData(JObject jsonObject)
        {
            var data = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(_filePath, data);
        }

        internal List<T> GetObjects(JObject jsonObject)
        {
            return jsonObject[_dataSet]?.ToObject<List<T>>() ?? new List<T>();
        }

        private void SetObject(JObject jsonObject, List<T> data)
        {
            jsonObject[_dataSet] = JArray.FromObject(data);
        }

        #endregion

        #region CRUD MANAGEMENT
        public void Add(T entity)
        {
            var jsonObject = LoadData();
            var allObjects = GetObjects(jsonObject);
            allObjects.Add(entity);
            SetObject(jsonObject, allObjects);
            StoreData(jsonObject); 
        }

        public void Delete(int id)
        {
            var jsonObject = LoadData();
            var allObjects = GetObjects(jsonObject);
            var currentObject = allObjects.FirstOrDefault(x => (int)x.GetType().GetProperty(this.GetType().Name + "Id").GetValue(x) == id);

            if (currentObject != null)
            {
                allObjects.Remove(currentObject);
                SetObject(jsonObject, allObjects);
                StoreData(jsonObject);
            }
        }

        public IEnumerable<T> GetAll()
        {
            var jsonObject = LoadData();
            var allObjects = GetObjects(jsonObject);

            return allObjects;
        }

        public T GetById(int id)
        {
            var jsonObject = LoadData();
            var allObjects = GetObjects(jsonObject);
            var objName = this.GetType().Name;
            var currentObject = allObjects.FirstOrDefault(x => (int)x.GetType().GetProperty(x.GetType().Name + "Id").GetValue(x) == id);
            return currentObject;
        }

        public void Update(T entity)
        {
            var jsonObject = LoadData();
            var allObjects = GetObjects(jsonObject);
            var objectId = (int)entity.GetType().GetProperty(entity.GetType().Name + "Id").GetValue(entity);
            var index = allObjects.FindIndex(x => (int)x.GetType().GetProperty(x.GetType().Name + "Id").GetValue(x) == objectId);

            if(index > 0)
            {
                allObjects[index] = entity;
                SetObject(jsonObject, allObjects);
                StoreData(jsonObject);
            }
        }
        #endregion
    }
}
