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
            textBox2.Enabled = false;
            textBox3.Enabled = false;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbnombre.Text = dataGridView1.SelectedCells[0].Value.ToString();    //nombre
            label6.Text = dataGridView1.SelectedCells[3].Value.ToString(); //descripcion
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString(); //cantidad
            textBox3.Text = dataGridView1.SelectedCells[1].Value.ToString();  // codigo
            int leer = int.Parse(textBox2.Text);
            //debo idicar la cantidad disponible y marcar stop

            label7.Text = ""; //despacho procesado
            if (leer <= 5)
            {
                textBox2.BackColor = Color.Yellow;  label5.BackColor = Color.Yellow;
            }
            else
            {
                textBox2.BackColor = Color.White; 
            }
        }

        private void btnDar_Click(object sender, EventArgs e)
        {
         
            try
            {
                string codigo = textBox3.Text;
                int cantDesp = int.Parse(textBox1.Text);
                int cantDisp = int.Parse(textBox2.Text);
                int cantRest = cantDisp - cantDesp;
                DateTime DT = DateTimePinker.Value;
                string fecha = DT.ToString("dd/MM/yyyy");

                if (cantDisp < cantDesp)
                {
                    MessageBox.Show("la cantidad solicitata no esta disponible");
                    textBox1.Text = ""; // cantidad a solicitar
                }
                else
                {
                    SqlConnection Cone = conexionDB.ObtenerConexion();
                    SqlCommand Com = new SqlCommand(string.Format("insert Into despachosProc(CODIGO, CANTIDAD, FECHA) values('" + codigo + "', '" + cantDesp + "','" + fecha + "')"), Cone);
                    int Resulta = Com.ExecuteNonQuery();
                    Cone.Close();
                    if (Resulta > 0)
                    {
                        // actualiza tabla de insumos
                        SqlConnection Conex = conexionDB.ObtenerConexion();
                        SqlCommand Cmd = new SqlCommand(string.Format("UPDATE insumos SET CANTIDAD='" + cantRest + "' WHERE CODIGO = '" + codigo + "' "), Conex);
                        int Resul = Cmd.ExecuteNonQuery();
                        Conex.Close();

                        limpiar();
                        label7.Text = "Despacho procesado...";
                        this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Guardar!!", "Error al Guardar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception dar)
            {
                MessageBox.Show(dar.Message);
            }
         

        }
        public void limpiar()
        {
            lbnombre.Text = "nada seleccionado"; // nombre
            label6.Text = ""; //descripcion
            textBox2.Text = ""; // cantidad a disponible
            textBox1.Text = ""; // cantidad a solicitar
            textBox5.Text = ""; //buscar
            textBox3.Text = "";  // codigo
            label7.Text = ""; //texto 'despacho procesado'
            textBox2.BackColor = Color.White; label5.ForeColor= Color.Black;
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
        private void button3_Click(object sender, EventArgs e) //actualizar
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                textBox3.Text = "";
                label2.Text = "Solo Numeros";
            }
        }
    }
}
