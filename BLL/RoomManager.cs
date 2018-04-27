using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomManager
    {
        public static RoomEntity GetById(int id) { return new RoomProvider().SelectRoom(id); }
        public static List<RoomEntity> GetList() { return new RoomProvider().SelectRooms(); }
        public static List<RoomEntity> GetListByTag(string tag) { return new RoomProvider().SelectRoomsByTag(tag); }
        public static void Add(RoomEntity room) { new RoomProvider().AddRoom(room); }
        public static void Update(RoomEntity room) { new RoomProvider().UpdateRoom(room); }
        public static void Delete(int id) { new RoomProvider().DeleteRoom(id); }

    }
}
