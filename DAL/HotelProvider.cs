using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class HotelProvider
    {
        public HotelEntity SelectHotel(int id)
        {
            HotelEntity hotel = null;

            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    string query = $"SELECT * FROM HOTEL WHERE id ={id}";

                    db.ConnectionString = AppConfig.ConnectionStringAdo;

                    SqlCommand cmd = db.CreateCommand();

                    cmd.CommandText = query;

                    db.Open();

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        hotel = new HotelEntity(
                            (int)read[0],
                            read[1].ToString(),
                            (int)read[2],
                            read[3].ToString(),
                            (int)read[4],
                            read[5].ToString(),
                            read[6].ToString(),
                            read[7].ToString(),
                            read[8].ToString(),
                            read[9].ToString(),
                            read[10].ToString(),
                            (int)read[11],
                            (bool)read[12],
                            (bool)read[13],
                            (bool)read[14],
                            read[15].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de DAL", ex);
            }
            return hotel;
        }
        public List<HotelEntity> SelectHotels()
        {
            List<HotelEntity> hotels = new List<HotelEntity>();
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    int iterateurCol = 0;
                    int iterateurLig = 0;
                    int tempInt = 0;

                    string query = "SELECT * FROM HOTEL";

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
                        hotels.Add(new HotelEntity(// L'hotel n'a pas de chambres en foreign key car principe du 0-n => 1-1
                            int.Parse(temp[0, tempInt]),
                            temp[1, tempInt],
                            int.Parse(temp[2, tempInt]),
                            temp[3,tempInt],
                            int.Parse(temp[4,tempInt]),
                            temp[5,tempInt],
                            temp[6,tempInt],
                            temp[7, tempInt],
                            temp[8, tempInt],
                            temp[9, tempInt],
                            temp[10, tempInt],
                            int.Parse(temp[11, tempInt]),
                            bool.Parse(temp[12, tempInt]),
                            bool.Parse(temp[13, tempInt]),
                            bool.Parse(temp[14, tempInt]),
                            temp[15, tempInt]));
                        tempInt++;
                    }
                    while (tempInt < temp.GetLongLength(1));
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erreur :", ex);
            }
            return hotels;
        }
    }
}