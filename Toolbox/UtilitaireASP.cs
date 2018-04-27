using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox
{
    public class UtilitaireASP
    {
        #region CRUD

        // CRUD générique :

        /// <summary>
        /// DELETE FROM... WHERE ID = ...
        /// </summary>
        /// <param name="connectionStringAdo">Connection string ADO</param>
        /// <param name="id">Identity</param>
        /// <param name="tableName">Name of table</param>
        /// <returns></returns>
        public string Update(string connectionStringAdo, int id, string tableName, string columnElement, string valueElement)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionStringAdo);
                SqlCommand cmd = new SqlCommand("UPDATE " + tableName.ToUpper() + " SET "+columnElement+" = "+valueElement+" " +" WHERE id = @1", con);

                cmd.Parameters.AddWithValue("@1", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();

                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
