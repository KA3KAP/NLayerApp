using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.WEB.Models
{
    public class Parcel_SearchViewModel
    {
        public int Id { get; set; }
        public string Name_of_Receiver { get; set; }
        public string Name_of_Sender { get; set; }
        public string Current_State { get; set; }
    }
}
