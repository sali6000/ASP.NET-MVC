using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomEntity
    {
        public int id { get; set; }
        [DisplayName("Hotel")]
        public int id_hotel { get; set; }
        [DisplayName("Nom")]
        public string name { get; set; }
        [DisplayName("Déscription")]
        public string detail_short { get; set; }
        [DisplayName("Déscription (longue)")]
        public string detail_long { get; set; }
        [DisplayName("Type de chambre")]
        public string type { get; set; }
        [DisplayName("Nombre de lits")]
        public int capacity_room { get; set; }
        [DisplayName("Image")]
        public string image { get; set; }
        [DisplayName("Nombre de salles de bain")]
        public int capacity_bathroom { get; set; }
        [DisplayName("Nombre de WC")]
        public int capacity_wc { get; set; }
        [DisplayName("Balcon inclu")]
        public bool balcony_include { get; set; }
        [DisplayName("Air conditionné inclu")]
        public bool air_condition_include { get; set; }
        [DisplayName("Wifi inclu")]
        public bool wifi_include { get; set; }
        [DisplayName("Mini bar inclu")]
        public bool small_bar_include { get; set; }
        [DisplayName("Animaux autorisés")]
        public bool autorization_animals { get; set; }
        [DisplayName("TV inclu")]
        public bool tv_include { get; set; }
        [DisplayName("Petit déjeuner inclu")]
        public bool breakfast_include { get; set; }
        [DisplayName("Prix")]
        [Range(0, 3)]
        public decimal price { get; set; }
        [DisplayName("Nombre d'adultes")]
        [Range(0, 5)]
        public int adult { get; set; }
        [DisplayName("Nombre d'enfants")]
        public int child { get; set; }
        [DisplayName("Active")]
        public bool active { get; set; }
        [DisplayName("Hotel")]
        public virtual HotelEntity hotel { get; set; }
        [DisplayName("Liste des hotels")]
        public virtual ICollection<HotelEntity> hotel1 { get; set; }
        public virtual ICollection<RentRoomMemberEntity> rent_room_member { get; set; }

        public RoomEntity()
        {
            this.hotel1 = new HashSet<HotelEntity>();
            this.rent_room_member = new HashSet<RentRoomMemberEntity>();
        }
        public RoomEntity(int id, int id_hotel, string name, string detail_short, string detail_long, string type, int capacity_room, string image, int capacity_bathroom, int capacity_wc, bool balcony_include, bool air_condition_include, bool wifi_include, bool small_bar_include, bool autorization_animals, bool tv_include, bool breakfast_include, decimal price, int adult, int child, bool active)
        {
            this.id = id;
            this.id_hotel = id_hotel;
            this.name = name;
            this.detail_short = detail_short;
            this.detail_long = detail_long;
            this.type = type;
            this.capacity_room = capacity_room;
            this.image = image;
            this.capacity_bathroom = capacity_bathroom;
            this.capacity_wc = capacity_wc;
            this.balcony_include = balcony_include;
            this.air_condition_include = air_condition_include;
            this.wifi_include = wifi_include;
            this.small_bar_include = small_bar_include;
            this.autorization_animals = autorization_animals;
            this.tv_include = tv_include;
            this.breakfast_include = breakfast_include;
            this.price = price;
            this.adult = adult;
            this.child = child;
            this.active = active;
        }
        public string GetImageHotel(int id)
        {
            HotelProvider hotel = new HotelProvider();
            return hotel.SelectHotel(id).image;
        }
    }
}
