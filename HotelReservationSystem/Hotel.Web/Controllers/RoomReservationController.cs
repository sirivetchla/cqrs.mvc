using Hotel.CQRS.Commands;
using Hotel.CQRS.Configuration;
using Hotel.CQRS.Exceptions;
using Hotel.CQRS.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Controllers
{
    public class RoomReservationController : Controller
    {
        // GET: RoomReservation
        public ActionResult Index()
        {
            ViewBag.Model = ServiceLocator.ReportDatabase.GetItems();
            return View();
        }
        public ActionResult RoomBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoomBook(HotelDto item)
        {
            ServiceLocator.CommandBus.Send(new CreateCommand(Guid.NewGuid(), item.CustomerName, item.Email,item.PhoneNo,item.RoomNo, -1, item.CheckIn, item.CheckOut,false));
            return RedirectToAction("Index");
        }
        public ActionResult RoomCancel(Guid id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(id);
            if (!item.IsCheckedIn)
            {
                ServiceLocator.CommandBus.Send(new CancelCommand(item.Id, item.Version));
            }
            else
            {
                ViewData["message"] = "The Room is Checked In Can not Cancel";
                
            }
            return RedirectToAction("Index");
        }       
        public ActionResult RoomCheckedIn(Guid id)
        {
            try
            {
                var item = ServiceLocator.ReportDatabase.GetById(id);
                var model = new HotelDto()
                {
                    CustomerName = item.CustomerName,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    RoomNo = item.RoomNo,
                    CheckIn = item.CheckIn,
                    CheckOut = item.CheckOut,
                    IsCheckedIn = true,
                    Id = item.Id,
                    Version = item.Version
                };
                ServiceLocator.CommandBus.Send(new ChangeCommand(item.Id, item.CustomerName, item.Email, item.PhoneNo, item.RoomNo, -1,item.CheckIn,item.CheckOut,true));
            }
            catch (ConcurrencyException err)
            {

                ViewBag.error = err.Message;
                ModelState.AddModelError("", err.Message);
                return View();

            }

            return RedirectToAction("Index");
        }
    }
}