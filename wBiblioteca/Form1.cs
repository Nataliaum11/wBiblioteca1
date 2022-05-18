using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace wBiblioteca
{
    public partial class frmBiblioteca : Form
    {
        public frmBiblioteca()
        {
            InitializeComponent();
        }

        private void frmBiblioteca_Load(object sender, EventArgs e)
        {

        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCargo.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
            txtHoraEntrada.Text = "";
            txtHoraSalida.Text = "";
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("server=LAPTOP-EDL61KRN\\TEW_SQLEXPRESS; database=dboBiblioteca; integrated security= true");
                conexion.Open();

                clsDatosPersonales p1 = new clsDatosPersonales(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtCedula.Text), Convert.ToInt32(txtCelular.Text), txtFecha.Text, txtHoraEntrada.Text, txtHoraSalida.Text, txtCargo.Text, txtCorreo.Text);
                p1.insertarDato();

                MessageBox.Show("Dato Ingresado");
                dtgBiblioteca.DataSource = p1.consultarDato();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al ingresar el dato" + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("server=LAPTOP-EDL61KRN\\TEW_SQLEXPRESS; database=dboBiblioteca; integrated security= true");
                conexion.Open();

                if (txtCedula.Text == "")
                {
                    clsDatosPersonales p1 = new clsDatosPersonales();
                    dtgBiblioteca.DataSource = p1.consultarDato();

                }
                else
                {
                    clsDatosPersonales p1 = new clsDatosPersonales();
                    dtgBiblioteca.DataSource = p1.seleccionarDato(Convert.ToInt32(txtCedula.Text));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el dato" + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("server =LAPTOP-EDL61KRN\\TEW_SQLEXPRESS; database=dboBiblioteca; integrated security= true");
                conexion.Open();

                clsDatosPersonales p1 = new clsDatosPersonales(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtCedula.Text), Convert.ToInt32(txtCelular.Text), txtFecha.Text, txtHoraEntrada.Text, txtHoraSalida.Text, txtCargo.Text, txtCorreo.Text);
                p1.modificarDato();
                MessageBox.Show("Dato modificados");
                dtgBiblioteca.DataSource = p1.consultarDato();
                MessageBox.Show("los datos fueron actualizados correctamente");




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el dato " + ex.Message); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection("server=LAPTOP-EDL61KRN\\TEW_SQLEXPRESS; database=dboBiblioteca; integrated security= true");
                conexion.Open();

                clsDatosPersonales p1 = new clsDatosPersonales();
                
                string Eliminar = "DELETE FROM tblEmpleado WHERE intCedEmpleado = @intCedEmpleado";
                SqlCommand cmd = new SqlCommand(Eliminar, conexion);
            
                cmd.Parameters.AddWithValue("@intCedEmpleado", txtCedula.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dato Eliminado");
                dtgBiblioteca.DataSource = p1.consultarDato();






            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el dato" + ex.Message);
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            Stream myStream;
            int counter = 0;
            string line;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Nombre";
            col1.Width = 200;
            col1.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col1);


            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Apellido";
            col2.Width = 200;
            col2.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Cedula";
            col3.Width = 200;
            col3.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Celular";
            col4.Width = 200;
            col4.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Fecha";
            col5.Width = 200;
            col5.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col5);

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Hora Entrada";
            col6.Width = 200;
            col6.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col6);

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "Hora Salida";
            col7.Width = 200;
            col7.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col7);

            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.HeaderText = "Cargo";
            col8.Width = 200;
            col8.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col8);

            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
            col9.HeaderText = "Correo";
            col9.Width = 200;
            col9.ReadOnly = true;
            dtgBiblioteca.Columns.Add(col9);


            char delimitador = ';';
            string[] valores;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos (*.CSV)  |  *.CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);

                        while ((line = file.ReadLine()) != null)
                        {
                            if (counter >= 1)
                            {
                                valores = line.Split(delimitador);
                                dtgBiblioteca.Rows.Add(valores.ToArray());
                                counter++;


                            }
                            else
                            {
                                counter++;
                            }

                        }
                        file.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void frmBiblioteca_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("¿Realmente deseas salir?", "Confirmacion",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
