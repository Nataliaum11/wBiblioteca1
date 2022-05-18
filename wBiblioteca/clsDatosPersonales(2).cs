using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace wBiblioteca
{
    class clsDatosPersonales
    {
        public string strNomEmpleado { get; set; }
        public string strApellEmpleado { get; set; }
        public int intCedEmpleado { get; set; }
        public int intNumCelular { get; set; }
        public DateTime datFecha { get; set; }
        public string strHoraEntrada { get; set; }
        public string strHoraSalida { get; set; }
        public string strCargo { get; set; }
        public string strCorreo { get; set; }



        public clsDatosPersonales()
        {

        }

        public clsDatosPersonales(string strNomEmpleado, string strApellEmpleado, int intCedEmpleado, int intNumCelular, DateTime datFecha, string strHoraEntrada, string strHoraSalida, string strCargo, string strCorreo)
        {
      
            this.strNomEmpleado = strNomEmpleado;
            this.strApellEmpleado = strApellEmpleado;
            this.intCedEmpleado = intCedEmpleado;
            this.intNumCelular = intNumCelular;
            this.datFecha = datFecha;
            this.strHoraEntrada = strHoraEntrada;
            this.strHoraSalida = strHoraSalida;
            this.strCargo = strCargo;
            this.strCorreo = strCorreo;
        }

        public bool insertarDato()
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-9FU5T22P\\SQLEXPRESS; database=dboBiblioteca; integrated security= true");
            conexion.Open();
            string insertar = "insert into tblEmpleado values(@strNomEmpleado, @strApellEmpleado, @intCedEmpleado, @intNumCelular, @datFecha, @strHoraEntrada, @strHoraSalida, @strCargo, @strCorreo)";

            SqlCommand sql = new SqlCommand(insertar, conexion);

            sql.Parameters.AddWithValue("@strNomEmpleado", this.strNomEmpleado);
            sql.Parameters.AddWithValue("@strApellEmpleado", this.strApellEmpleado);
            sql.Parameters.AddWithValue("@intCedEmpleado", this.intCedEmpleado);
            sql.Parameters.AddWithValue("@intNumCelular", this.intNumCelular);
            sql.Parameters.AddWithValue("@datFecha", this.datFecha);
            sql.Parameters.AddWithValue("@strHoraEntrada", this.strHoraEntrada);
            sql.Parameters.AddWithValue("@strHoraSalida", this.strHoraSalida);
            sql.Parameters.AddWithValue("@strCargo", this.strCargo);
            sql.Parameters.AddWithValue("@strCorreo", this.strCorreo);
            sql.ExecuteNonQuery();

            return true;
        }

        public DataTable consultarDato()
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-9FU5T22P\\SQLEXPRESS; database=dboBiblioteca; integrated security= true");
            conexion.Open();
            DataTable Date = new DataTable();
            string consulta = "select * from tblEmpleado";
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Date);


            return Date;
        }

        public bool eliminarDato()
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-9FU5T22P\\SQLEXPRESS; database=dboBiblioteca; integrated security= true");
            conexion.Open();

            this.intCedEmpleado = intCedEmpleado;
            string eliminar = "delete tblEmpleado where intCedEmpleado = @intCedEmpleado";
            SqlCommand sql = new SqlCommand(eliminar, conexion);
            sql.ExecuteNonQuery();

            return true;
        }

        public bool modificarDato()
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-9FU5T22P\\SQLEXPRESS; database=dboBiblioteca; integrated security= true");
            conexion.Open();

            string modificar = "update tblEmpleado set strNomEmpleado = @strNomEmpleado, strApellEmpleado = @strApellEmpleado, intCedEmpleado = @intCedEmpleado, intNumCelular = @intNumCelular, datFecha= @datFecha, strHoraEntrada = @strHoraEntrada, strHoraSalida = @strHoraSalida, strCargo = @strCargo, strCorreo = @strCorreo";
            SqlCommand sql = new SqlCommand(modificar, conexion);



            sql.Parameters.AddWithValue("@strNomEmpleado", this.strNomEmpleado);
            sql.Parameters.AddWithValue("@strApellEmpleado", this.strApellEmpleado);
            sql.Parameters.AddWithValue("@intCedEmpleado", this.intCedEmpleado);
            sql.Parameters.AddWithValue("@intNumCelular", this.intNumCelular);
            sql.Parameters.AddWithValue("@datFecha", this.datFecha);
            sql.Parameters.AddWithValue("@strHoraEntrada", this.strHoraEntrada);
            sql.Parameters.AddWithValue("@strHoraSalida", this.strHoraSalida);
            sql.Parameters.AddWithValue("@strCargo", this.strCargo);
            sql.Parameters.AddWithValue("@strCorreo", this.strCorreo);

            return true;
        }

        public DataTable seleccionarDato(int intCedEmpleado)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-9FU5T22P\\SQLEXPRESS; database=dboBiblioteca; integrated security= true");
            conexion.Open();

            this.intCedEmpleado = intCedEmpleado;
            DataTable dt = new DataTable();
            string seleccionar = "select*from tblEmpleado where intCedEmpleado = @intCedEmpleado ";
            SqlCommand cmd = new SqlCommand(seleccionar, conexion);
            cmd.Parameters.AddWithValue("@intCedEmpleado", this.intCedEmpleado);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            return dt;
        }
    }
}
