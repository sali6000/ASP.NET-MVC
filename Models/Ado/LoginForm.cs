using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Ado
{
    public class LoginForm
    {
        [Required]
        [DisplayName("Pseudo")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginForm()
        {

        }

        public LoginForm(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}