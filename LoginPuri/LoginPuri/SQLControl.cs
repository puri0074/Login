using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginPuri
{
    internal class SQLControl
    {
        string connectionString = "Data Source=DESKTOP-IIVGJML\\LOCALDB#0C466D40;Initial Catalog=nombre_basedatos;Integrated Security=True;";

        public int Login(string usuario, string pass)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spLogin", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        resultado = 1; // Credenciales válidas
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            return resultado;
        }
    }
}

