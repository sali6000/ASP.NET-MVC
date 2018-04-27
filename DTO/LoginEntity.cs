using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginEntity
    {
        [Required]
        [DisplayName("Pseudo")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginEntity()
        {

        }
        public LoginEntity(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
