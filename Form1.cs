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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            Insumos FormInsumos = new Insumos();
            FormInsumos.ShowDialog();
        }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            Despachar FormDespachar = new Despachar();
            FormDespachar.ShowDialog();
        }
    }
}
