using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTO
{
    public class MemberEntity
    {
        [DisplayName("Identificateur")]
        public int id { get; set; }
        [DisplayName("Prénom")]
        public string first_name { get; set; }
        [DisplayName("Nom")]
        public string last_name { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string email { get; set; }
        [DisplayName("Pays")]
        public EnumPays country { get; set; }
        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [DisplayName("Pseudo")]
        [MaxLength(20)]
        [MinLength(2)]
        [Required]
        public string username { get; set; }
        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(30)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmation du mot de passe")]
        [Compare("password", ErrorMessage = "Les mots de passe doivent être identiques")]
        public string confirmPassword { get; set; }
        [DisplayName("Administrateur")]
        public bool admin { get; set; }
        [DisplayName("Super administrateur")]
        public bool super_admin { get; set; }
        [DisplayName("Statut Actif")]
        public bool active { get; set; }
        public virtual ICollection<RentRoomMemberEntity> rent_room_member { get; set; }

        public MemberEntity()
        {
            this.rent_room_member = new HashSet<RentRoomMemberEntity>();
        }
        public MemberEntity(string username)
        {
            this.username = username;
        }
        public MemberEntity(int id, string first_name, string last_name, string email, EnumPays country, string phone, string username, string password, bool admin, bool super_admin, bool active)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.country = country;
            this.phone = phone;
            this.username = username;
            this.password = password;
            this.admin = admin;
            this.super_admin = super_admin;
            this.active = active;
        }
    }
}