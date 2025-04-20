using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControLSInsumos
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'despachosProceDataSet2.despachosProc' Puede moverla o quitarla según sea necesario.
            this.despachosProcTableAdapter.Fill(this.despachosProceDataSet2.despachosProc);

            // TODO: esta línea de código carga datos en la tabla 'dBInsumosDataSet1.insumos' Puede moverla o quitarla según sea necesario.
            this.insumosTableAdapter.Fill(this.dBInsumosDataSet1.insumos);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
