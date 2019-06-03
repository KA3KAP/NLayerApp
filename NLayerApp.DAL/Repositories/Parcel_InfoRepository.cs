using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;

namespace NLayerApp.DAL.Repositories
{
    public class Parcel_InfoRepository : IRepository<Parcel_Info>
    {
        private ParcelContext db;

        public Parcel_InfoRepository(ParcelContext context)
        {
            this.db = context;
        }

        public IEnumerable<Parcel_Info> GetAll()
        {
            return db.Parcel_Infos.Include(o => o.Parcel_Search);
        }

        public Parcel_Info Get(int id)
        {
            return db.Parcel_Infos.Find(id);
        }

        public void Create(Parcel_Info order)
        {
            db.Parcel_Infos.Add(order);
        }

        public void Update(Parcel_Info order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Parcel_Info> Find(Func<Parcel_Info, Boolean> predicate)
        {
            return db.Parcel_Infos.Include(o => o.Parcel_Search).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Parcel_Info order = db.Parcel_Infos.Find(id);
            if (order != null)
                db.Parcel_Infos.Remove(order);
        }
    }
}
