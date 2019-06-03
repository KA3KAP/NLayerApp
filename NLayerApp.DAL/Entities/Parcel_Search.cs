using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Parcel_Search
    {
        public int Id { get; set; }
        public string Name_of_Receiver { get; set; }
        public string Name_of_Sender { get; set; }
        public string Current_State { get; set; }
        public ICollection<Parcel_Info> Parcel_Infos { get; set; }
    }
}
