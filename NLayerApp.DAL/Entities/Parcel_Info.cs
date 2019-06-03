using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Parcel_Info
    {
        public int Id { get; set; }
        public string Address_of_Receiver { get; set; }
        public string Address_of_Sender { get; set; }
        public string Current_State { get; set; }
        public Parcel_Search Parcel_Search { get; set; }
        public int Parcel_SearchID { get; set; }

    }
}
