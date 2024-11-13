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
    public partial class AgregarProducto : Form
    {
        
        public AgregarProducto()
        {
            InitializeComponent();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p1 = new Producto();
            Productos datos = new Productos();

            p1.NombreProducto = txtNombre.Text;
            p1.Descripcion = txtDescripcion.Text;
            p1.codigoProducto = txtCodigoProducto.Text;
            p1.Precio = double.Parse(txtPrecio.Text);
            p1.cantidadStock = int.Parse(txtCantidadStock.Text);

            datos.Insertar(p1);

            this.Close();
            
            
            



            
        }


    }
}
