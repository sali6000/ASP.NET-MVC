using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RoomProvider
    {
        public RoomEntity SelectRoom(int id)
        {
            RoomEntity room = null;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = $"SELECT * FROM ROOM WHERE id ={id}";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    cmd.CommandText = query;

                    db.Open();

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {

                        room = new RoomEntity(
                            (int)read[0],
                            (int)read[1],
                            read[2].ToString(),
                            read[3].ToString(),
                            read[4].ToString(),
                            read[5].ToString(),
                            (int)read[6],
                            read[7].ToString(),
                            (int)read[8],
                            (int)read[9],
                            (bool)read[10],
                            (bool)read[11],
                            (bool)read[12],
                            (bool)read[13],
                            (bool)read[14],
                            (bool)read[15],
                            (bool)read[16],
                            (decimal)read[17],
                            (int)read[18],
                            (int)read[19],
                            (bool)read[20]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return room;
        }
        public List<RoomEntity> SelectRooms()
        {
            List<RoomEntity> rooms = new List<RoomEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM ROOM WHERE ACTIVE = 1";

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
                        rooms.Add(new RoomEntity(
                            int.Parse(temp[0, tempInt]),
                            int.Parse(temp[1, tempInt]),
                            temp[2, tempInt],
                            temp[3, tempInt],
                            temp[4, tempInt],
                            temp[5, tempInt],
                            int.Parse(temp[6, tempInt]),
                            temp[7, tempInt],
                            int.Parse(temp[8, tempInt]),
                            int.Parse(temp[9, tempInt]),
                            bool.Parse(temp[10, tempInt]),
                            bool.Parse(temp[11, tempInt]),
                            bool.Parse(temp[12, tempInt]),
                            bool.Parse(temp[13, tempInt]),
                            bool.Parse(temp[14, tempInt]),
                            bool.Parse(temp[15, tempInt]),
                            bool.Parse(temp[16, tempInt]),
                            decimal.Parse(temp[17, tempInt]),
                            int.Parse(temp[18, tempInt]),
                            int.Parse(temp[19, tempInt]),
                            bool.Parse(temp[20, tempInt])));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return rooms;
        }
        public int AddRoom(RoomEntity room)
        {
            using (SqlConnection db = new SqlConnection())
            {
                try
                {
                    string query = "INSERT INTO ROOM VALUES (@ArgHotelId, @ArgName, @ArgDetailShort, @ArgDetailLong, @ArgType, @ArgCapacity, @ArgImage, @ArgCapacityBathroom, @ArgCapacityWC, @ArgBalcon, @ArgAirCondition, @ArgWifi, @ArgMiniBar, @ArgAnimals, @ArgTVInclude, @ArgBreakFast, @ArgPrice, @ArgAdult, @ArgChild, @ArgActive)";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    cmd.Parameters.Add(new SqlParameter("@ArgHotelId", room.id_hotel));
                    cmd.Parameters.Add(new SqlParameter("@ArgName", room.name));
                    cmd.Parameters.Add(new SqlParameter("@ArgDetailShort", room.detail_short));
                    cmd.Parameters.Add(new SqlParameter("@ArgDetailLong", room.detail_long));
                    cmd.Parameters.Add(new SqlParameter("@ArgType", room.type));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacity", room.capacity_room));
                    cmd.Parameters.Add(new SqlParameter("@ArgImage", room.image == null ? "" : room.image));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacityBathroom", room.capacity_bathroom));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacityWC", room.capacity_wc));
                    cmd.Parameters.Add(new SqlParameter("@ArgBalcon", room.balcony_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgAirCondition", room.air_condition_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgWifi", room.wifi_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgMiniBar", room.small_bar_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgAnimals", room.autorization_animals));
                    cmd.Parameters.Add(new SqlParameter("@ArgTVInclude", room.tv_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgBreakFast", room.breakfast_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgPrice", room.price));
                    cmd.Parameters.Add(new SqlParameter("@ArgAdult", room.adult));
                    cmd.Parameters.Add(new SqlParameter("@ArgChild", room.child));
                    cmd.Parameters.Add(new SqlParameter("@ArgActive", true));

                    cmd.CommandText = query;

                    db.Open();

                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur: " + ex.Message);
                }

            }
        }
        public void UpdateRoom(RoomEntity room)
        {
            using (SqlConnection db = new SqlConnection())
            {
                try
                {
                    string query = "UPDATE ROOM SET " +
                        "[id_hotel] = @ArgIdHotel, " +
                        "[name] = @ArgName, " +
                        "[detail_short] = @ArgDetailShort, " +
                        "[detail_long] = @ArgDetailLong, " +
                        "[type] = @ArgType, " +
                        "[capacity_room] = @ArgCapacityRoom, " +
                        "[image] = @ArgImage, " +
                        "[capacity_bathroom] = @ArgCapacityBathroom, " +
                        "[capacity_wc] = @ArgCapacityWC, " +
                        "[balcony_include] = @ArgBalconyInclude, " +
                        "[air_condition_include] = @ArgAirConditionInclude, " +
                        "[wifi_include] = @ArgWifiInclude, " +
                        "[small_bar_include] = @ArgSmallBarInclude, " +
                        "[autorization_animals] = @ArgAutorizationAnimals, " +
                        "[tv_include] = @ArgTvInclude, " +
                        "[breakfast_include] = @ArgBreakfastInclude, " +
                        "[price] = @ArgPrice, " +
                        "[adult] = @ArgAdult, " +
                        "[child] = @ArgChild WHERE id =" + room.id;

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    cmd.Parameters.Add(new SqlParameter("@ArgIdHotel", room.id_hotel));
                    cmd.Parameters.Add(new SqlParameter("@ArgName", room.name));
                    cmd.Parameters.Add(new SqlParameter("@ArgDetailShort", room.detail_short));
                    cmd.Parameters.Add(new SqlParameter("@ArgDetailLong", room.detail_long));
                    cmd.Parameters.Add(new SqlParameter("@ArgType", room.type));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacityRoom", room.capacity_room));
                    cmd.Parameters.Add(new SqlParameter("@ArgImage", room.image == null ? "" : room.image));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacityBathroom", room.capacity_bathroom));
                    cmd.Parameters.Add(new SqlParameter("@ArgCapacityWC", room.capacity_wc));
                    cmd.Parameters.Add(new SqlParameter("@ArgBalconyInclude", room.balcony_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgAirConditionInclude", room.air_condition_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgWifiInclude", room.wifi_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgSmallBarInclude", room.small_bar_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgAutorizationAnimals", room.autorization_animals));
                    cmd.Parameters.Add(new SqlParameter("@ArgTvInclude", room.tv_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgBreakfastInclude", room.breakfast_include));
                    cmd.Parameters.Add(new SqlParameter("@ArgPrice", room.price));
                    cmd.Parameters.Add(new SqlParameter("@ArgAdult", room.adult));
                    cmd.Parameters.Add(new SqlParameter("@ArgChild", room.child));

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
        public void DeleteRoom(int id)
        {
            try
            {
                string query = "UPDATE ROOM SET ACTIVE = 0 WHERE id = @0";

                SqlConnection con = new SqlConnection();
                con.ConnectionString = AppConfig.ConnectionStringAdo;

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@0", id);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
        }
        public List<RoomEntity> SelectRoomsByTag(string tag)
        {
            List<RoomEntity> rooms = new List<RoomEntity>();

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM ROOM WHERE ACTIVE = 1 AND Name LIKE '%" + tag + "%' OR detail_short LIKE '%" + tag + "%' OR detail_long LIKE '%" + tag + "%' OR [type] LIKE '%" + tag + "%'";

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
                        while (tempInt < temp.GetLongLength(1))
                        {
                            rooms.Add(new RoomEntity(
                                int.Parse(temp[0, tempInt]),
                                int.Parse(temp[1, tempInt]),
                                temp[2, tempInt],
                                temp[3, tempInt],
                                temp[4, tempInt],
                                temp[5, tempInt],
                                int.Parse(temp[6, tempInt]),
                                temp[7, tempInt],
                                int.Parse(temp[8, tempInt]),
                                int.Parse(temp[9, tempInt]),
                                bool.Parse(temp[10, tempInt]),
                                bool.Parse(temp[11, tempInt]),
                                bool.Parse(temp[12, tempInt]),
                                bool.Parse(temp[13, tempInt]),
                                bool.Parse(temp[14, tempInt]),
                                bool.Parse(temp[15, tempInt]),
                                bool.Parse(temp[16, tempInt]),
                                decimal.Parse(temp[17, tempInt]),
                                int.Parse(temp[18, tempInt]),
                                int.Parse(temp[19, tempInt]),
                                bool.Parse(temp[20, tempInt])));
                            tempInt++;
                        }
                    }
                    else
                    {
                        return rooms;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur: ", ex);
            }
            return rooms;
        }
    }
}