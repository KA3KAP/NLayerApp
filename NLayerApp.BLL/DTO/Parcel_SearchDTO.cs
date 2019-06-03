using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class Parcel_SearchDTO
    {
        public int Id { get; set; }
        public string Name_of_Receiver { get; set; }
        public string Name_of_Sender { get; set; }
        public string Current_State { get; set; }
    }
}
