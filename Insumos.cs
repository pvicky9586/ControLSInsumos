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
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace ControLSInsumos
{
    public partial class Insumos : Form
    {
        public Insumos()
        {
            InitializeComponent();
        }
        private void Insumos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBInsumosDataSet.insumos' Puede moverla o quitarla según sea necesario.
            this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);
        }
//-----------NUEVO---------------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;           
            SqlConnection Conexion = conexionDB.ObtenerConexion();
            try
            {
                int cantidad = int.Parse(textBox3.Text);
                string cadena = "SELECT codigo FROM insumos  WHERE codigo='" + codigo + "'";
                SqlCommand cmdN = new SqlCommand(cadena, Conexion);
                SqlDataReader registroN = cmdN.ExecuteReader();
                if (registroN.Read())
                {
                    MessageBox.Show("Insumo ya registrado");
                    limpiar();
                }
                else
                {
                    registroN.Close();
                    SqlCommand ComandoN = new SqlCommand(string.Format("insert Into insumos(NOMBRE, CODIGO, CANTIDAD, DESCRIPCION) values('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text, cantidad, textBox4.Text), Conexion);
                    int ResultadoN = ComandoN.ExecuteNonQuery();
                    if (ResultadoN > 0)
                    {
                        label1.Text = "Insumo guardado";
                        //MessageBox.Show("Datos Guardados Correctamente!!", "Guardados!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("No se pudo Guardar!!", "Error al Guardar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception eN)
            {
                MessageBox.Show(eN.Message);
            }
            finally
            {

                Conexion.Close();
                limpiar();
            }
         
        }
        // ------------MODIFICAR -------------------
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;
            SqlConnection Conexion = conexionDB.ObtenerConexion();
            try
            {
                int cantidad = int.Parse(textBox3.Text);
                SqlCommand CmdMod = new SqlCommand(string.Format("UPDATE insumos SET NOMBRE='" + textBox1.Text + "', CANTIDAD='" + cantidad + "', descripcion ='" + textBox4.Text + "' WHERE CODIGO='" + textBox2.Text + "' "), Conexion);
                int ResultadoM = CmdMod.ExecuteNonQuery();
                if (ResultadoM > 0)
                {
                    //MessageBox.Show("Datos Guardados Correctamente!!", "Guardados!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se pudo Guardar los cambios!!", "Error al Guardar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }
            finally
            {
                Conexion.Close();
                limpiar();
            }
        }

// ---------- BORRAR------------
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
             //var resp = MessageBox.Show("¿Estas seguro que deseas eliminar este registro?", "Confirmacion", MessageBoxButtons.YesNo);
             //if (resp == DialogResult.Yes)
              try
              {
                 string codigo = textBox2.Text;
                // D --> de delete
                SqlConnection Conexion = conexionDB.ObtenerConexion();
                string cadena = "SELECT CODIGO FROM despachosProc  WHERE CODIGO='" + codigo + "'";
                SqlCommand comandoD = new SqlCommand(cadena, Conexion);
                SqlDataReader registroD = comandoD.ExecuteReader();
                if (registroD.Read())
                {
                    label4.Text = "Este Insumo no puede eliminarse";
                }
                else
                {
                    registroD.Close();
                    SqlCommand CmdD = new SqlCommand(string.Format("DELETE FROM insumos WHERE CODIGO='" + codigo + "' "), Conexion);
                    int ResultadoD = CmdD.ExecuteNonQuery();
                    Conexion.Close();
                    if (ResultadoD > 0)
                    {
                        this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Guardar los cambios!!", "Error al Guardar!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
        }

 // ---------- CARGAR INSUMOS ---------
        private void btnCargar_Click(object sender, EventArgs e)
        {

            SqlConnection Conexion = conexionDB.ObtenerConexion();
            SqlCommand Comando = new SqlCommand(string.Format("insert Into insumos(NOMBRE, CODIGO, CANTIDAD, DESCRIPCION) " +
                "values('CEPILLO', 'CEP -01', 10, 'CUALQUIER COSA'), ('DETERGENTE','DET-02',20,'EN LIQUIDO'),('BOLSAS NEGRAS','BOL-03',25,'DE 5K C/U')"), Conexion);
            int Resultado = Comando.ExecuteNonQuery();
            Conexion.Close();
            btnCargar.Enabled = false;
            limpiar();

            //btnCargar.Click += (o, ev) =>
            //{
            //    int a = 10;
            //    int b = 20;
            //    int suma = a + b;

            //    MessageBox.Show(suma.ToString());
            //};
        }

 // ----- BUSCAR -----------
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString(); //nombre
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString(); //codigo 
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString(); //cantidad
            textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString(); //descripcion
            btnNuevo.Enabled = false;
            textBox2.Enabled = false;
            label4.Text = "";
        }
        public void limpiar()
        {
            textBox1.Text = ""; // nombre
            textBox2.Text = ""; //codigo
            textBox3.Text = ""; //cantidad
            textBox4.Text = ""; // descripcion
            label2.Text = ""; //solo numeros
            label4.Text = ""; //al eliminar
          //  label8.Text = ""; //id oculto debajo de DataGridView
            textBox5.Text = ""; // budcar
            btnNuevo.Enabled = true;
            this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // nombre
            textBox2.Text = ""; //codigo
            textBox3.Text = ""; //cantidad
            textBox4.Text = ""; // descripcion
            textBox5.Text = ""; //BUSCAR
            btnNuevo.Enabled = true;
            textBox2.Enabled = true;
            this.insumosTableAdapter.Fill(this.dBInsumosDataSet.insumos);

        }

 

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

     

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                textBox3.Text = "";
                label2.Text = "Solo Numeros";
            }
        }
    }
}
