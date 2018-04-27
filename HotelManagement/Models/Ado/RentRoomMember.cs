using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Ado
{
    public class RentRoomMember
    {
        public RentRoomMember()
        {
            this.id_member = UserSession.CurrentUser.id;
        }

        public RentRoomMember(int id, int id_room, int id_member, DateTime firstdate, DateTime lastdate, int adult, int child, int price, bool assurance, bool validation)
        {
            this.id = id;
            this.id_room = id_room;
            this.id_member = id_member;
            this.firstdate = firstdate;
            this.lastdate = lastdate;
            this.adult = adult;
            this.child = child;
            this.price = price;
            this.assurance = assurance;
            this.validation = validation;
            //this.member = UserSession.CurrentUser;
        }


        [DisplayName("Réservation")]
        public int id { get; set; }

        [DisplayName("Chambre")]
        public int id_room { get; set; }

        [DisplayName("Nom et prenom")]
        public int id_member { get; set; }

        [Required]
        [DisplayName("Date de départ")]
        [DataType(DataType.Date)]
        public DateTime firstdate { get; set; }

        [Required]
        [DisplayName("Date de fin")]
        [DataType(DataType.Date)]
        public DateTime lastdate { get; set; }

        [DisplayName("Nombre d'adultes")]
        public int adult { get; set; }

        [DisplayName("Nombre d'enfants")]
        public int child { get; set; }

        [DisplayName("Prix")]
        public decimal price { get; set; }
        
        [DisplayName("Assurance")]
        public bool assurance { get; set; }

        [DisplayName("Validation")]
        public bool validation { get; set; }

        //public virtual Member member { get; set; }

        public virtual ICollection<Room> rooms { get; set; }
    }
}