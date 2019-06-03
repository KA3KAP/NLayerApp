using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ParcelContext db;
        private Parcel_SearchRepository parcel_searchRepository;
        private Parcel_InfoRepository parcel_infoRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ParcelContext(connectionString);
        }
        public IRepository<Parcel_Search> Parcel_Searchs
        {
            get
            {
                if (parcel_searchRepository == null)
                    parcel_searchRepository = new Parcel_SearchRepository (db);
                return parcel_searchRepository;
            }
        }

        public IRepository<Parcel_Info> Parcel_Infos
        {
            get
            {
                if (parcel_infoRepository == null)
                    parcel_infoRepository = new Parcel_InfoRepository(db);
                return parcel_infoRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
