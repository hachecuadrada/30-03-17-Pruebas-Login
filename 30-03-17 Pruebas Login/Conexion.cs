using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _30_03_17_Pruebas_Login
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=HECTOR\\INSTANCIA1;Initial Catalog=PruebaLogin;Persist Security Info=True;User ID=sa;Password=1234");
                cn.Open();
                MessageBox.Show("Funciona");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string Insertar(int id, string contraseña, string usuario)
        {
            string salida = "Sí";
            string sentencia = "";
            try
            {
                sentencia = $"Insert into Usuarios values ({id}, '{contraseña}', '{usuario}')";
                cmd = new SqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                salida = "No insert: " + sentencia + "\br" + ex;
            }
            return salida;
        }

        public int PersonaRegistrada(int id)
        {
            int contador = 0;
            
            try
            {
                string sentencia = $"Select * from Usuarios where id = {id}";
                cmd = new SqlCommand(sentencia, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No consulta: " + ex);
            }
            return contador;
        }
    }
}
