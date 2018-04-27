using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DTO
{
    public class HotelEntity
    {
        public int id { get; set; }
        [DisplayName("Nom")]
        public string name { get; set; }
        [DisplayName("Étoiles")]
        public int star_number { get; set; }
        [DisplayName("Code postal")]
        public string cp { get; set; }
        [DisplayName("Numéro")]
        public int num { get; set; }
        [DisplayName("Rue")]
        public string street { get; set; }
        [DisplayName("Pays")]
        public string country { get; set; }
        [DisplayName("Lattitude géographique")]
        public string geo_lat { get; set; }
        [DisplayName("Longitude géographique")]
        public string geo_lon { get; set; }
        [DisplayName("Téléphone")]
        public string phone { get; set; }
        [DisplayName("Email")]
        public string mail { get; set; }
        [DisplayName("Nombre de lits")]
        public int capacity_rooms { get; set; }
        [DisplayName("Piscine inclu")]
        public bool swimming_pool { get; set; }
        [DisplayName("Chauffeur")]
        public bool driver { get; set; }
        [DisplayName("Serveur")]
        public bool room_service { get; set; }
        [DisplayName("Image")]
        public string image { get; set; }

        public HotelEntity()
        {
        }
        public HotelEntity(int id, string name, int star_number, string cp, int num, string street, string country, string geo_lat, string geo_lon, string phone, string mail, int capacity_rooms, bool swimming_pool, bool driver, bool room_service, string image)
        {
            this.id = id;
            this.name = name;
            this.star_number = star_number;
            this.cp = cp;
            this.num = num;
            this.street = street;
            this.country = country;
            this.geo_lat = geo_lat;
            this.geo_lon = geo_lon;
            this.phone = phone;
            this.mail = mail;
            this.capacity_rooms = capacity_rooms;
            this.swimming_pool = swimming_pool;
            this.driver = driver;
            this.room_service = room_service;
            this.image = image;
        }
    }
}