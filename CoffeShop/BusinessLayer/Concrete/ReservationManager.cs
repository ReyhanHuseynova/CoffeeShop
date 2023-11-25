using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;   
        }
        public void TCreate(Reservation model)
        {
            _reservationDal.TCreate(model);
        }

        public void TDelete(Reservation model)
        {
            _reservationDal.TDelete(model);
        }

        public List<Reservation> TGetAll()
        {
            return _reservationDal.TGetAll();
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.TGetById(id);
        }

        public void TUpdate(Reservation model)
        {
           _reservationDal.TUpdate(model);
        }
    }
}
