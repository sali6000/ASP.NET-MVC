using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginProvider
    {
        public MemberEntity SelectLogin(LoginEntity LoginForm)
        {
            MemberEntity member = null;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {

                    string query = "SELECT * FROM MEMBER WHERE USERNAME = @Username AND PASSWORD = @Password;";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();
                    cmd.Parameters.AddWithValue("@Username", LoginForm.Username);
                    cmd.Parameters.AddWithValue("@Password", LoginForm.Password);
                    cmd.CommandText = query;

                    db.Open();

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {

                        member = new MemberEntity(
                            (int)read[0],
                            read[1].ToString(),
                            read[2].ToString(),
                            read[3].ToString(),
                            (EnumPays)Enum.Parse(typeof(EnumPays), read[4].ToString()),
                            read[5].ToString(),
                            read[6].ToString(),
                            read[7].ToString(),
                            (bool)read[8],
                            (bool)read[9],
                            (bool)read[10]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return member;
        }
    }
}