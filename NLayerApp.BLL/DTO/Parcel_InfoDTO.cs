using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.BLL.DTO
{
    public class Parcel_InfoDTO
    {
        public int Id { get; set; }
        public string Address_of_Receiver { get; set; }
        public string Address_of_Sender { get; set; }
        public string Current_State { get; set; }
        public int Parcel_SearchId { get; set; }
    }
}
