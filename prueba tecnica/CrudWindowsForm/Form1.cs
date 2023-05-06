using CrudWindowsForm.Dato;
using CrudWindowsForm.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsForm
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        DatosAdmin admin = new DatosAdmin();
        private void Inicializar ()
        {
            tabla = new DataTable ();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("Fecha de Nacimiento");
            tabla.Columns.Add("Estado Civil");
            tabla.Columns.Add("Grado Acedemico");
            tabla.Columns.Add("Direccion");
            dgdatos.DataSource = tabla;
        }
        public Form1()
        {
            InitializeComponent();
            Consultar();
        }
        private void Consultar()
        {
            Inicializar();
            List<datos> lista = admin.Consultar();
            foreach (var item in lista)
            {
                DataRow row = tabla.NewRow();
                row["Nombre"] = item.Nombre;
                row["Apellido"] = item.Apellido;
                row["Fecha de Nacimiento"] = item.Fecha_Naciemiento;
                row["Estado Civil"] = item.Estado_Civil;
                ///row["Grado Academico"] = item.Grado_Academico;
                row["Direccion"] = item.Direccion;
                tabla.Rows.Add(row);
            }
        }
        private void Guardar ()
        {
            datos datos = new datos()
            {
                Nombre =  txtnombre.Text,
                Apellido = txtapellido.Text,
                Fecha_Naciemiento = Convert.ToDateTime( txtfnacimiento.Text),
                Estado_Civil = txtecivil.Text,
                Grado_Academico = txtgacademico.Text,
                Direccion = txtdireccion.Text
            };
            admin.Guardar(datos);

        }
        private void Limpiar () {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtfnacimiento.Text = "";
            txtecivil.Text = "";
            txtgacademico.Text = "";
            txtdireccion.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Consultar();
            Limpiar();
        }
    }
}
