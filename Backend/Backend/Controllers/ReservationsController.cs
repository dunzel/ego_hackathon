using Backend.Models;
using SchoolDataLayer;
using System;
using System.Linq;
using System.Web.Http;

namespace Backend.Controllers
{
    public class ReservationsController
    {

        private MyContext db = new MyContext();

        [HttpPost]
        public bool ReserveShortTerm([FromBody]ShortTermReserveModel reserveModel)
        {
            try
            {
                DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                sTime.AddSeconds(reserveModel.StartTime);

                DateTime fTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                sTime.AddSeconds(reserveModel.FinnishTime);


                ShortTermReservation reservation = new ShortTermReservation { Start = sTime, Finnish = fTime, Issuer = db.users.First(x => x.UserID == reserveModel.IssuerID) };
                db.shortTermReservations.Add(reservation);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public bool CancelShortTermReservation([FromBody]int reservationID)
        {
            try
            {
                ShortTermReservation reservationToDelete = db.shortTermReservations.First(x => x.ID == reservationID);
                db.shortTermReservations.Remove(reservationToDelete);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}