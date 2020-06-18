using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EjemploTresKpasBO;




namespace EjemploTresKpas
{    
    public partial class frmIngresarAlumnos : Form
    {
        
        clsAlumnos alumnos = new clsAlumnos();
        clsReglasAlumnos reglasAlumnos = new clsReglasAlumnos();
        public frmIngresarAlumnos()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var mensaje = string.Empty;
            
            try
            {
                alumnos._Documento = Convert.ToInt32(txtDocumento.Text);
                alumnos._Nombre = txtNombre.Text;
                alumnos._Apellidos = txtApellidos.Text;
                alumnos._Sexo = rbSexoFemenino.Checked == true ? "F" : "M";
                alumnos._FechaNacimiento = dtpFechaNacimiento.Value;
                alumnos._Direccion = txtDireccion.Text;

                List<clsAlumnos> Ltalumnos = new List<clsAlumnos>();
                Ltalumnos.Add(alumnos);
                mensaje = reglasAlumnos.IngresarAlumno(Ltalumnos);
                MessageBox.Show(mensaje);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void frmIngresarAlumnos_Load(object sender, EventArgs e)
        {

        }

        private void llListado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmListadoAlumnos frmListado = new frmListadoAlumnos();
            frmListado.Show();
        }
    }
}
