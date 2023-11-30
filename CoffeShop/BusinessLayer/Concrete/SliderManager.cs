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
    public class SliderManager : ISliderService
    {
        ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal; 
        }
        public void TCreate(Slider model)
        {
            _sliderDal.TCreate(model);
        }

        public void TDelete(Slider model)
        {
           _sliderDal.TDelete(model);
        }

        public List<Slider> TGetAll()
        {
          return  _sliderDal.TGetAll();
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.TGetById(id);
        }

        public void TUpdate(Slider model)
        {
           _sliderDal.TUpdate(model);
        }
    }
}
