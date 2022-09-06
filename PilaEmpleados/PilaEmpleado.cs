using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PilaEmpleados
{
    public partial class PilaEmpleado : Form
    {
        Stack<Empleado> MyPilaEmpleado = new Stack<Empleado>();
        public PilaEmpleado()
        {
            InitializeComponent();
        }
        //Metodo del botón Salir
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado myEmpleado = new Empleado();            
            myEmpleado.Identificacion = txtIdentificacion.Text;
            myEmpleado.Nombre = txtNombre.Text;
            myEmpleado.SalarioDia = Decimal.Parse(txtSalarioDia.Text);
            myEmpleado.DiasLaborados = Int32.Parse(txtDiasLaborados.Text);
            txtDevengado.Text = myEmpleado.CalcularDevengado(myEmpleado.SalarioDia, myEmpleado.DiasLaborados).ToString();
            myEmpleado.Fecha = dtpFecha.Value;
            MyPilaEmpleado.Push(myEmpleado);
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = MyPilaEmpleado.ToArray();
            LimpiarControles();
            txtIdentificacion.Focus();
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MyPilaEmpleado.Count != 0)
            {
                Empleado myEmpleado = new Empleado();

                if(MessageBox.Show ("Desea eliminar el registro de a pila?","ATENCIÓN", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                {                  
                myEmpleado = MyPilaEmpleado.Pop();txtIdentificacion.Text = myEmpleado.Identificacion;
                txtNombre.Text = myEmpleado.Nombre;
                txtSalarioDia.Text = myEmpleado.SalarioDia.ToString();
                txtDiasLaborados.Text = myEmpleado.DiasLaborados.ToString();
                txtDevengado.Text = myEmpleado.Devengado.ToString();
                dtpFecha.Value = myEmpleado.Fecha;
                dgvDatos.DataSource = MyPilaEmpleado.ToArray();
                MessageBox.Show("Se eliminó el registro que estaba en pila", "ATENCIÓN");
                }
            }
            else
            {
                MessageBox.Show("No hay registros en pila", "ATENCIÓN");
            }
            LimpiarControles();
        }

        //Metodo para limpiar cajas de texto
        private void LimpiarControles()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtSalarioDia.Clear();
            txtDiasLaborados.Clear();
            txtDevengado.Clear();
        }
    }
}
