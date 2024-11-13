using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Parcial4PlanissigKarol
{
    public class Productos
    {
        //Metodos: agregar, modificar, borrar
        private List<Producto> productos;
        public DataTable listaProductos { get; set; }

        public void AgregarProducto(Producto producto)
        {
            if (producto != null)
            {
                productos.Add(producto);
            }
        }

        public Productos()
        {
            listaProductos = new DataTable();

            listaProductos.TableName = "Productos";
            listaProductos.Columns.Add("CantidadStock", typeof(int));
            listaProductos.Columns.Add("Nombre");
            listaProductos.Columns.Add("CodigoProducto");
            listaProductos.Columns.Add("Descripcion");
            listaProductos.Columns.Add("Precio");
            if (!System.IO.File.Exists("Productos.xml"))
            {
                crearArchivoXML();
            }
            leerArchivo();
        }
        private void leerArchivo()
        {
            if (System.IO.File.Exists("Productos.xml"))
            {
                listaProductos.ReadXml("Productos.xml");
            }
        }
        
        private void crearArchivoXML()
        {
            using (XmlWriter writer = XmlWriter.Create("Productos.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("DocumentElement");
                writer.WriteStartElement("Productos");
                writer.WriteStartElement("Producto");
                writer.WriteElementString("CantidadStock", "0"); 
                writer.WriteElementString("Nombre", ""); 
                writer.WriteElementString("CodigoProducto", ""); 
                writer.WriteElementString("Descripcion", ""); 
                writer.WriteElementString("Precio", "0");
                writer.WriteEndElement(); // Producto
                writer.WriteEndElement(); // Productos
                writer.WriteEndElement(); // DocumentElement
            }
        }
       


        public void Insertar(Producto producto)
        {
            if (producto != null)
            {
                try
                {
                    listaProductos.Rows.Add(); //Se agrega un renglón vacio
                    int nuevoRenglon = listaProductos.Rows.Count - 1;

                    listaProductos.Rows[nuevoRenglon]["CantidadStock"] = producto.cantidadStock;
                    listaProductos.Rows[nuevoRenglon]["Nombre"] = producto.NombreProducto;
                    listaProductos.Rows[nuevoRenglon]["CodigoProducto"] = producto.codigoProducto;
                    listaProductos.Rows[nuevoRenglon]["Descripcion"] = producto.Descripcion;
                    listaProductos.Rows[nuevoRenglon]["Precio"] = producto.Precio;

                    listaProductos.WriteXml("Productos.xml");
                    

                }
                catch (Exception ex)
                {

                    throw ex; 
                }
                
            }
           
            
                
            
        }
    }
}
