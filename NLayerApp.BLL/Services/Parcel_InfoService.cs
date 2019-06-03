using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;
//using NLayerApp.BLL.BusinessModels;
using NLayerApp.DAL.Interfaces;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using AutoMapper;

namespace NLayerApp.BLL.Services
{
    public class Parcel_InfoService : IParcel_InfoService
    {
        IUnitOfWork Database { get; set; }

        public Parcel_InfoService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void DoSearch(Parcel_InfoDTO parcel_infoDto)
        {
            Parcel_Search parcel_search = Database.Parcel_Searchs.Get(parcel_infoDto.Parcel_SearchId);

            // валидация
            if (parcel_search == null)
                throw new ValidationException("Посылка не найдена", "");
            Parcel_Info parcel_info = new Parcel_Info
            {
                Parcel_SearchID = parcel_infoDto.Parcel_SearchId,
                Address_of_Receiver = parcel_infoDto.Address_of_Receiver,
                Address_of_Sender = parcel_infoDto.Address_of_Sender,
                Current_State = parcel_infoDto.Current_State
            };
            Database.Parcel_Infos.Create(parcel_info);
            Database.Save();
        }

        public IEnumerable<Parcel_SearchDTO> GetParcel_Searchs()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Parcel_Search, Parcel_SearchDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Parcel_Search>, List < Parcel_SearchDTO>>(Database.Parcel_Searchs.GetAll());
        }

        public Parcel_SearchDTO GetParcel_Search(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id посылки", "");
            var parcel_search = Database.Parcel_Searchs.Get(id.Value);
            if (parcel_search == null)
                throw new ValidationException("Посылка не найдена", "");

            return new Parcel_SearchDTO { Id = parcel_search.Id, Name_of_Receiver = parcel_search.Name_of_Receiver, Name_of_Sender = parcel_search.Name_of_Sender, Current_State = parcel_search.Current_State };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
