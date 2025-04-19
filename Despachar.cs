using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControLSInsumos
{
    public partial class Despachar : Form
    {
        public Despachar()
        {
            InitializeComponent();
        }

        private void Despachar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBInsumosDataSet.insumos' Puede moverla o quitarla según sea necesario.
            this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);

        }

        private void btnDar_Click(object sender, EventArgs e)
        {
            string codigo = label13.Text;
            int cantidad = int.Parse(textBox1.Text);
            int cantDisp = int.Parse(label9.Text);
            int cantRest = cantDisp - cantidad;
            DateTime DT = DateTimePinker.Value;
            string fecha = DT.ToString("dd/MM/yyyy");

            SqlConnection Conexion = conexionDB.ObtenerConexion();
            SqlCommand Comando = new SqlCommand(string.Format("insert Into Despachos(CODIGO, CANTIDAD, FECHA) values('{0}','{1}','{2}')", codigo, cantidad, fecha), Conexion);
            int Resultado = Comando.ExecuteNonQuery();
            Conexion.Close();
            if (Resultado > 0)
            {
                // actualiza tabla de insumo
                SqlConnection Conex = conexionDB.ObtenerConexion();
                SqlCommand Cmd = new SqlCommand(string.Format("UPDATE insumos SET CANTIDAD='" + cantRest + "' WHERE CODIGO = '" + label3.Text + "' "), Conex);
                int Resul = Cmd.ExecuteNonQuery();
                Conex.Close();      

                limpiar();
                label1.Text = "Despacho procesado...";
                this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);
            }
            else
            {
                MessageBox.Show("No se pudo Guardar!!", "Error al Guardar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           
        }
        public void limpiar()
        {
            lbnombre.Text = "nada seleccionado"; // nombre
            label6.Text = ""; //descripcion
            label9.Text = ""; //cantidad disponible
            textBox1.Text = ""; // cantidad a solicitar
            textBox5.Text = ""; //buscar
            label3.Text = "";  // codigo
            label1.Text = ""; //texto 'despacho procesado'
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbnombre.Text = dataGridView1.SelectedCells[0].Value.ToString();    //nombre
            label6.Text = dataGridView1.SelectedCells[3].Value.ToString(); //descripcion
            label9.Text = dataGridView1.SelectedCells[2].Value.ToString(); //cantidad
            label1.Text = dataGridView1.SelectedCells[1].Value.ToString();  // codigo

            //debo idicar la cantidad disponible y marcar stop
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string codigo = textBox5.Text;
            SqlConnection Conexion = conexionDB.ObtenerConexion();
            SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM insumos WHERE CODIGO='" + textBox5.Text + "' "), Conexion);
            int Resultado = Comando.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "NOMBRE";
            dataGridView1.Columns[1].HeaderText = "CODIGO";
            dataGridView1.Columns[2].HeaderText = "CANTIDAD";
            dataGridView1.Columns[3].HeaderText = "DETALLES";
            Conexion.Close();
        }

        // ACTUALIZAR
        private void button3_Click(object sender, EventArgs e)
        {
            string codigo = textBox5.Text;
            SqlConnection Conexion = conexionDB.ObtenerConexion();
            SqlCommand Comando = new SqlCommand(string.Format("SELECT * FROM insumos"), Conexion);
            int Resultado = Comando.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter(Comando);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "NOMBRE";
            dataGridView1.Columns[1].HeaderText = "CODIGO";
            dataGridView1.Columns[2].HeaderText = "CANTIDAD";
            dataGridView1.Columns[3].HeaderText = "DETALLES";
            Conexion.Close();
            limpiar();
        }
    }
}
