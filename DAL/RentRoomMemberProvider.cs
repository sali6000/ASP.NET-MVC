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
    public class RentRoomMemberProvider
    {
        public List<RentRoomMemberEntity> SelectValidateRentRoomMemberById(int id)
        {
            List<RentRoomMemberEntity> rentRoomMembers = new List<RentRoomMemberEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM RENT_ROOM_MEMBER WHERE id_member=" + id + " AND validation=1";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = db.CreateCommand();
                    da.SelectCommand.CommandText = query;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    string[,] temp;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        temp = new string[ds.Tables[0].Columns.Count, ds.Tables[0].Rows.Count];

                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            for (iterateurCol = 0; iterateurCol < ds.Tables[0].Columns.Count; iterateurCol++)
                            {
                                temp[iterateurCol, iterateurLig] = string.Concat(item[iterateurCol]);
                            }
                            iterateurLig++;
                        }
                    }
                    else
                    {
                        return rentRoomMembers;
                    }
                    do
                    {
                        rentRoomMembers.Add(new RentRoomMemberEntity(
                        int.Parse(temp[0, tempInt]),
                        int.Parse(temp[1, tempInt]),
                        int.Parse(temp[2, tempInt]),
                        DateTime.Parse(temp[3, tempInt]),
                        DateTime.Parse(temp[4, tempInt]),
                        int.Parse(temp[5, tempInt]),
                        int.Parse(temp[6, tempInt]),
                        int.Parse(temp[7, tempInt]),
                        bool.Parse(temp[8, tempInt]),
                        bool.Parse(temp[9, tempInt])
                        ));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return rentRoomMembers;
        }
        public List<RentRoomMemberEntity> SelectNotValidateRentRoomMemberById(int id)
        {
            List<RentRoomMemberEntity> rentRoomMembers = new List<RentRoomMemberEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM RENT_ROOM_MEMBER WHERE id_member=" + id + " AND validation = 0";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = db.CreateCommand();
                    da.SelectCommand.CommandText = query;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    string[,] temp;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        temp = new string[ds.Tables[0].Columns.Count, ds.Tables[0].Rows.Count];

                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            for (iterateurCol = 0; iterateurCol < ds.Tables[0].Columns.Count; iterateurCol++)
                            {
                                temp[iterateurCol, iterateurLig] = string.Concat(item[iterateurCol]);
                            }
                            iterateurLig++;
                        }
                    }
                    else
                    {
                        return rentRoomMembers;
                    }
                    do
                    {
                        rentRoomMembers.Add(new RentRoomMemberEntity(
                        int.Parse(temp[0, tempInt]),
                        int.Parse(temp[1, tempInt]),
                        int.Parse(temp[2, tempInt]),
                        DateTime.Parse(temp[3, tempInt]),
                        DateTime.Parse(temp[4, tempInt]),
                        int.Parse(temp[5, tempInt]),
                        int.Parse(temp[6, tempInt]),
                        int.Parse(temp[7, tempInt]),
                        bool.Parse(temp[8, tempInt]),
                        bool.Parse(temp[9, tempInt])
                        ));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                    return rentRoomMembers;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
        }
        public List<RentRoomMemberEntity> SelectRentRoomMember()
        {
            List<RentRoomMemberEntity> rentRoomMembers = new List<RentRoomMemberEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM RENT_ROOM_MEMBER";

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
                        rentRoomMembers.Add(new RentRoomMemberEntity(
                            int.Parse(temp[0, tempInt]),
                            int.Parse(temp[1, tempInt]),
                            int.Parse(temp[2, tempInt]),
                            DateTime.Parse(temp[3, tempInt]),
                            DateTime.Parse(temp[4, tempInt]),
                            int.Parse(temp[5, tempInt]),
                            int.Parse(temp[6, tempInt]),
                            int.Parse(temp[7, tempInt]),
                            bool.Parse(temp[8, tempInt]),
                            bool.Parse(temp[6, tempInt])
                            ));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return rentRoomMembers;
        }
        public void AddRentRoomMember(int idRoom, int idMember, DateTime firstDate, DateTime lastDate, int adult, int child, decimal price, bool assurance)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddRentMemberRoom";

                    cmd.Parameters.Add("@idRoom", SqlDbType.Int).Value = idRoom;
                    cmd.Parameters.Add("@idMember", SqlDbType.Int).Value = idMember;
                    cmd.Parameters.Add("@firstDate", SqlDbType.DateTime).Value = firstDate;
                    cmd.Parameters.Add("@lastDate", SqlDbType.DateTime).Value = lastDate;
                    cmd.Parameters.Add("@adult", SqlDbType.Int).Value = adult;
                    cmd.Parameters.Add("@child", SqlDbType.Int).Value = child;
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.Add("@assurance", SqlDbType.Bit).Value = assurance;
                    db.Open();
                    int result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur:", ex);
                //ViewBag.Error = ex.Message;
            }
        }
    }
}