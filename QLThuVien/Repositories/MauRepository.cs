using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace QLThuVien.Repositories
{
    public class MauRepository<T> where T : class
    {
        protected QuanLyThuVienDataContext db;

        public MauRepository()
        {
            string connStr = ConfigurationManager.ConnectionStrings["QLThuVienConn"].ConnectionString;
            db = new QuanLyThuVienDataContext(connStr);
        }

        public List<T> GetAll() => db.GetTable<T>().ToList();

        public void Insert(T entity)
        {
            db.GetTable<T>().InsertOnSubmit(entity);
            db.SubmitChanges();
        }

        public void Update(T entity)
        {
            var id = GetPrimaryKeyValue(entity);

            var allItems = db.GetTable<T>().ToList();

            var oldEntity = allItems.FirstOrDefault(x => GetPrimaryKeyValue(x) == id);

            if (oldEntity != null)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.Name.StartsWith("Ma") && prop.PropertyType == typeof(int)) continue;
                    var newValue = prop.GetValue(entity, null);
                    prop.SetValue(oldEntity, newValue, null);
                }
                db.SubmitChanges();
            }
        }

        public void Delete(T entity)
        {
            var id = GetPrimaryKeyValue(entity);

         
            var allItems = db.GetTable<T>().ToList();

            var oldEntity = allItems.FirstOrDefault(x => GetPrimaryKeyValue(x) == id);

            if (oldEntity != null)
            {
                db.GetTable<T>().DeleteOnSubmit(oldEntity);
                db.SubmitChanges();
            }
        }

        private int GetPrimaryKeyValue(T entity)
        {
            var prop = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name.StartsWith("Ma") && p.PropertyType == typeof(int));
            if (prop != null)
                return (int)prop.GetValue(entity);
            return -1;
        }
    }
}