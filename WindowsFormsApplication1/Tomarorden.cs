using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Practica4;
using WindowsFormsApplication1.Datos;
using WindowsFormsApplication1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
// se agrego la libreria que antes habiamos creado
//En esta clase agregamos el codigo de nuestra aplicación. 

namespace WindowsFormsApplication1
{
    public partial class Tomarorden : Form
    {
        DataTable Tabla;
        Usuario dato = new Usuario();
        public Tomarorden()
        {
            InitializeComponent();// inicualiza los componentes de la IU
        }
        String Desayuno, resultado,Pasta,Pollo,Carne,Mar,Caldo,Postre,Bebida;
        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
            Orddesayuno.Text = "";
            ordplatillos.Text = "";
            ordpostres.Text = "";
            ordbebidas.Text = "";
            Orddesayuno.Focus(); 
          
        }
        private void Iniciar()
        {
            Tabla = new DataTable();
            Tabla.Columns.Add("Ordenar");
            Tabla.Columns.Add("Total");
            grilla.DataSource = Tabla;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Guardar();
            Iniciar();
            Limpiar();
            Consultar();
            MessageBox.Show("¿Esta seguro de realizar esta orden? ", "", MessageBoxButtons.YesNoCancel);
            if (DialogResult == DialogResult.Yes)
            {
            }
            else
                Orddesayuno.Focus();// metodo para controles personalizados 

            resultado = Ordenar.Orden1(Desayuno);
            resultado = Ordenar.Orden2(Pasta);
            resultado = Ordenar.Orden3(Pollo);
            resultado = Ordenar.Orden4(Carne);
            resultado = Ordenar.Orden5(Mar);
            resultado = Ordenar.Orden6(Caldo);
            resultado = Ordenar.Orden7(Postre);
            resultado = Ordenar.Orden8(Bebida);

        }
        private void Guardar()
        {
            usuarioModel modelo = new usuarioModel()
            {
                Desayunos = Orddesayuno.Text,
                Platillos = ordplatillos.Text,
                Postres = ordpostres.Text,
                Bebidas = ordbebidas.Text,
                Total = int.Parse(textTOTAL.Text)
            };
            dato.Iniciar(modelo);
        }
        private void Consultar()
        {
            foreach (var item in dato.Consultar())
            {
                DataRow fila = Tabla.NewRow();
                fila["DESAYUNOS"] = item.Desayunos;
                fila["PLATILLOS"] = item.Platillos;
                fila["POSTRES"] = item.Postres;
                fila["BEBIDAS"] = item.Bebidas;
                fila["TOTAL"] = item.Total;
                Tabla.Rows.Add(fila);
            }
        }
        private void textTOTAL_TextChanged(object sender, EventArgs e)
        {

        }

        private void Orddesayuno_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Desayunos_Click(object sender, EventArgs e)
        {

        }

        private void ordplatillos_TextChanged(object sender, EventArgs e)
        {

        }

        private void menucasa_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            this.Hide();
            f.Show(); 
        }

        private void regresar_Click(object sender, EventArgs e)
        {
            siguiente f = new siguiente();
            this.Hide();
            f.Show(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Limpiar()
        {
            Orddesayuno.Text = "";
            ordplatillos.Text = "";
            ordpostres.Text = "";
            ordbebidas.Text = "";
            textTOTAL.Text = "";
        }
        private void Tomarorden_Load(object sender, EventArgs e)
        {

        }
    }
}
