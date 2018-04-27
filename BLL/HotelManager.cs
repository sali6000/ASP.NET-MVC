using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HotelManager
    {
        public static HotelEntity GetById(int id) { return new HotelProvider().SelectHotel(id); }
        public static List<HotelEntity> GetList() { return new HotelProvider().SelectHotels(); }
    }
}
