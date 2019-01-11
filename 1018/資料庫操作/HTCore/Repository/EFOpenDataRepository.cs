
using HTCore.Database;
using HTCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HTCore.Repository
{
    public class EFOpenDataRepository : IOpenDataRepository
    {
        private OpenDataDbContext OpenDataDbContext { get; set; }

        public EFOpenDataRepository()
        {
            OpenDataDbContext = new OpenDataDbContext();
        }

        public List<OpenData> SelectAll(string name)
        {
            var result = new List<OpenData>();
            var query = OpenDataDbContext.OpenData.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.園區別 == name);
            }
            return query.ToList();
        }
        public void Insert(OpenData item)
        {
            OpenDataDbContext.OpenData.Add(item);
            OpenDataDbContext.SaveChanges();
        }
        public void Update(OpenData item)
        {
            var exist = OpenDataDbContext.OpenData
                .Where(x => x.id == item.id).SingleOrDefault();
            if (exist == null)
                return;
            exist.園區別 = item.園區別;
            exist.廠商名稱 = item.廠商名稱;
            exist.地址 = item.地址;
            OpenDataDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var exist = OpenDataDbContext.OpenData
                .Where(x => x.id == id).SingleOrDefault();
            if (exist == null)
                return;
            OpenDataDbContext.OpenData.Remove(exist);
            OpenDataDbContext.SaveChanges();

        }

    }
}
