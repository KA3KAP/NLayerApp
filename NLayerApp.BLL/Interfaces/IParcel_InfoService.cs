using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.BLL.DTO;

namespace NLayerApp.BLL.Interfaces
{
    public interface IParcel_InfoService
    {
        void DoSearch(Parcel_InfoDTO parcel_infoDto);
        Parcel_SearchDTO GetParcel_Search(int? id);
        IEnumerable<Parcel_SearchDTO> GetParcel_Searchs();
        void Dispose();
    }
}
