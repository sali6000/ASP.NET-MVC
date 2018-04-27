using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberProvider
    {
        public MemberEntity SelectMember(int id)
        {
            MemberEntity member = null;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = $"SELECT * FROM MEMBER WHERE id ={id}";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

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
        public List<MemberEntity> SelectMembers()
        {
            List<MemberEntity> members = new List<MemberEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM MEMBER WHERE ACTIVE = 1";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = db.CreateCommand();
                    da.SelectCommand.CommandText = query;

                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    string[,] temp = new string[ds.Tables[0].Columns.Count, ds.Tables[0].Rows.Count];

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            for (iterateurCol = 0; iterateurCol < ds.Tables[0].Columns.Count; iterateurCol++)
                            {
                                temp[iterateurCol, iterateurLig] = string.Concat(item[iterateurCol]);
                            }
                            iterateurLig++;
                        }
                    }
                    do
                    {
                        members.Add(new MemberEntity(
                            int.Parse(temp[0, tempInt]),
                            temp[1, tempInt],
                            temp[2, tempInt],
                            temp[3, tempInt],
                            (EnumPays)Enum.Parse(typeof(EnumPays), temp[4, tempInt]),
                            temp[5, tempInt],
                            temp[6, tempInt],
                            temp[7, tempInt],
                            bool.Parse(temp[8, tempInt]),
                            bool.Parse(temp[9, tempInt]),
                            bool.Parse(temp[10, tempInt])));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return members;
        }
        public int AddMember(MemberEntity member)
        {
            int result = 0;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = "INSERT INTO MEMBER (first_name,last_name,email,country,phone,username,[password]) VALUES (@ArgFirstName, @ArgLastName, @ArgEmail, @ArgCountry, @ArgPhone, @ArgUsername, @ArgPassword)";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    /*(object)member... Permet de définir si la 1ère valeur est null, si c'est le cas, il passe à la suivante (après les ?? séparé par des ;) ainsi de suite jusqu'à ce qu'il trouve une valeur non null car la base de donnée ne supporte pas les champs vides pour les string*/
                    cmd.Parameters.Add(new SqlParameter("@ArgFirstName", (object)member.first_name ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ArgLastName", (object)member.last_name ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ArgEmail", member.email));
                    cmd.Parameters.Add(new SqlParameter("@ArgCountry", (object)member.country ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ArgPhone", (object)member.phone ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ArgUsername", member.username));
                    cmd.Parameters.Add(new SqlParameter("@ArgPassword", member.password));
                    cmd.CommandText = query;

                    db.Open();

                    return result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
        }

        public void UpdateMember(MemberEntity member)
        {
            using (SqlConnection db = new SqlConnection())
            {
                try
                {
                    string query = "UPDATE MEMBER SET " +
                        "[first_name] = @ArgFirstName, " +
                        "[last_name] = @ArgLastName, " +
                        "[email] = @ArgEmail, " +
                        "[country] = @ArgCountry, " +
                        "[phone] = @ArgPhone, " +
                        "[username] = @ArgUsername, " +
                        "[password] = @ArgPassword, " +
                        "[admin] = @ArgAdmin, " +
                        "[super_admin] = @ArgSuperAdmin WHERE id =" + member.id;

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    cmd.Parameters.Add(new SqlParameter("@ArgFirstName", member.first_name));
                    cmd.Parameters.Add(new SqlParameter("@ArgLastName", member.last_name));
                    cmd.Parameters.Add(new SqlParameter("@ArgEmail", member.email));
                    cmd.Parameters.Add(new SqlParameter("@ArgCountry", member.country));
                    cmd.Parameters.Add(new SqlParameter("@ArgPhone", member.phone));
                    cmd.Parameters.Add(new SqlParameter("@ArgUsername", member.username));
                    cmd.Parameters.Add(new SqlParameter("@ArgPassword", member.password));
                    cmd.Parameters.Add(new SqlParameter("@ArgAdmin", member.admin));
                    cmd.Parameters.Add(new SqlParameter("@ArgSuperAdmin", member.super_admin));
                    cmd.CommandText = query;

                    db.Open();

                    int rowAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur: ", ex);
                }
            }
        }
        public void DeleteMember(int id)
        {
            try
            {
                string query = "DELETE FROM MEMBER WHERE id = " + id;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = AppConfig.ConnectionStringAdo;

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;

                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
        }
        public bool UsernameExist(MemberEntity member)
        {
            bool exist = false;
            int scalar = 0;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = "SELECT count(*) FROM MEMBER WHERE USERNAME = @ArgPseudo";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();
                    cmd.Parameters.AddWithValue("@ArgPseudo", member.username);

                    cmd.CommandText = query;

                    db.Open();

                    scalar = (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return exist = scalar > 0 ? true : false;
        }
        public bool EmailExist(MemberEntity member)
        {
            bool exist = false;
            int scalar = 0;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = "SELECT count(*) FROM MEMBER WHERE EMAIL = @ArgEmail";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();
                    cmd.Parameters.AddWithValue("@ArgEmail", member.email);

                    cmd.CommandText = query;

                    db.Open();

                    scalar = (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return exist = scalar > 0 ? true : false;
        }
    }
}