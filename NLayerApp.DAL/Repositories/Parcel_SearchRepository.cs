using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL.Repositories
{
    public class Parcel_SearchRepository : IRepository<Parcel_Search>
    {
        private ParcelContext db;

        public Parcel_SearchRepository(ParcelContext context)
        {
            this.db = context;
        }

        public IEnumerable<Parcel_Search> GetAll()
        {
            return db.Parcel_Searchs;
        }

        public Parcel_Search Get(int id)
        {
            return db.Parcel_Searchs.Find(id);
        }

        public void Create(Parcel_Search book)
        {
            db.Parcel_Searchs.Add(book);
        }

        public void Update(Parcel_Search book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Parcel_Search> Find(Func<Parcel_Search, Boolean> predicate)
        {
            return db.Parcel_Searchs.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Parcel_Search book = db.Parcel_Searchs.Find(id);
            if (book != null)
                db.Parcel_Searchs.Remove(book);
        }
    }
}

