using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class ParcelContext : DbContext
    {
        public DbSet<Parcel_Info> Parcel_Infos { get; set; }
        public DbSet<Parcel_Search> Parcel_Searchs { get; set; }

        static ParcelContext()
        {
            Database.SetInitializer<ParcelContext>(new DeliveryDbInitializer());
        }
        public ParcelContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class DeliveryDbInitializer : DropCreateDatabaseIfModelChanges<ParcelContext>
    {
        protected override void Seed(ParcelContext db)
        {
            db.Parcel_Searchs.Add(new Parcel_Search { Name_of_Receiver = "Vladimir Kashpirovskiy", Name_of_Sender = "WineMarket", Current_State = "processing" });
            db.Parcel_Searchs.Add(new Parcel_Search { Name_of_Receiver = "Vasiliy Pupkin", Name_of_Sender = "Citrus", Current_State = "accepted" });
            db.Parcel_Searchs.Add(new Parcel_Search { Name_of_Receiver = "Katerine Duska", Name_of_Sender = "BetterLove", Current_State = "in a way" });
            db.Parcel_Searchs.Add(new Parcel_Search { Name_of_Receiver = "Marin Mokun", Name_of_Sender = "Bags", Current_State = "delivered" });
            db.Parcel_Searchs.Add(new Parcel_Search { Name_of_Receiver = "Joce Papai", Name_of_Sender = "Yamaha", Current_State = "delivered" });
            db.SaveChanges();
        }
    }
}
