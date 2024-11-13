using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial4PlanissigKarol
{
    public partial class Form1 : Form
    {
       
        private Productos producto = new Productos();
        public Form1()
        {
            InitializeComponent();
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto productoNuevo = new AgregarProducto();
            productoNuevo.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            dgvListado.DataSource = producto.listaProductos;
        }

       
    }
}
