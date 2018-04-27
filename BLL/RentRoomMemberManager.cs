using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RentRoomMemberManager
    {
        public static List<RentRoomMemberEntity> GetListValidateById(int id) { return new RentRoomMemberProvider().SelectValidateRentRoomMemberById(id); }
        public static List<RentRoomMemberEntity> GetListNotValidateById(int id) { return new RentRoomMemberProvider().SelectNotValidateRentRoomMemberById(id); }
        public static List<RentRoomMemberEntity> GetList() { return new RentRoomMemberProvider().SelectRentRoomMember(); }
        public static void Add(int idRoom, int idMember, DateTime firstDate, DateTime lastDate, int adult, int child, decimal price, bool assurance) { new RentRoomMemberProvider().AddRentRoomMember(idRoom, idMember, firstDate, lastDate, adult, child, price, assurance); }
    }
}
