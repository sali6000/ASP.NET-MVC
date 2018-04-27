using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class ViewModelManager
    {
        public MemberEntity Member { get; set; }
        public List<MemberEntity> Members { get; set; }
        public RoomEntity Room { get; set; }
        public List<RoomEntity> Rooms { get; set; } 
        public HotelEntity Hotel { get; set; }
        public List<HotelEntity> Hotels { get; set; }
        public RentRoomMemberEntity RentRoomMember { get; set; }
        public List<RentRoomMemberEntity> RentRoomMemberValidates { get; set; }
        public List<RentRoomMemberEntity> RentRoomMemberNotValidates { get; set; }
        public decimal TotalPrice { get; set; }

        public ViewModelManager()
        {
            Member = null;
            Members = null;
            Room = null;
            Rooms = null;
            Hotel = null;
            Hotels = null;
            RentRoomMember = null;
            RentRoomMemberValidates = null;
            RentRoomMemberNotValidates = null;
        }

        public RoomEntity RoomGetById(int id)
        {
            return RoomManager.GetById(id);
        }

        public List<RoomEntity> RoomGetListByTag(string tag)
        {
            return RoomManager.GetListByTag(tag);
        }

    }
}
