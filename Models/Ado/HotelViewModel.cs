using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Repository;
using System.Web.Mvc;

namespace HotelManagement.Models.Ado
{
    public class HotelViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public List<Member> Members { get; set; }
        public List<RentRoomMember> RentRoomMembers { get; set; }
        public List<Room> Rooms { get; set; }
        public Hotel Hotel { get; set; }
        public Member Member { get; set; }
        public Room Room { get; set; }
        public RentRoomMember RentRoomMember { get; set; }
}
    }