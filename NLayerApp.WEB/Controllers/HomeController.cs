using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IParcel_InfoService parcel_infoService;
        public HomeController(IParcel_InfoService serv)
        {
            parcel_infoService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<Parcel_SearchDTO> parcel_searchDtos = parcel_infoService.GetParcel_Searchs();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Parcel_SearchDTO, Parcel_SearchViewModel>()).CreateMapper();
            var parcel_searchs = mapper.Map<IEnumerable<Parcel_SearchDTO>, List<Parcel_SearchViewModel>>(parcel_searchDtos);
            return View(parcel_searchs);
        }

        public ActionResult DoSearch(int? id)
        {
            try
            {
                Parcel_SearchDTO parcel_search = parcel_infoService.GetParcel_Search(id);
                var parcel_info = new Parcel_InfoViewModel { Parcel_SearchID = parcel_search.Id };

                return View(parcel_info);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(Parcel_InfoViewModel parcel_info)
        {
            try
            {
                var parcel_infoDto = new Parcel_InfoDTO { Address_of_Receiver = parcel_info.Address_of_Receiver, Address_of_Sender = parcel_info.Address_of_Sender, Parcel_SearchId = parcel_info.Parcel_SearchID };
                parcel_infoService.DoSearch(parcel_infoDto);
                return Content("<h2>Посылка найдена</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(parcel_info);
        }
        protected override void Dispose(bool disposing)
        {
            parcel_infoService.Dispose();
            base.Dispose(disposing);
        }
    }
}