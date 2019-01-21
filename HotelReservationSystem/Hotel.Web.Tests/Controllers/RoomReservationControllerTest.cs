using Hotel.CQRS.Reporting;
using Hotel.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotel.Web.Tests.Controllers
{
    [TestClass]
    public class RoomReservationControllerTest
    {
        HotelDto hotelDto = null;
       [TestInitialize]
       public void Intialize()
        {
             hotelDto = new HotelDto
            {
                CustomerName = "test",
                Email = "Siri@gmail.com",
                PhoneNo = "1234567890",
                RoomNo = 305,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                IsCheckedIn = false

            };
        }
        [TestMethod]
        public void RoomBookTest()
        {
            RoomReservationController reservationController = new RoomReservationController();
            ActionResult result = reservationController.RoomBook(hotelDto);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }
    }
}
