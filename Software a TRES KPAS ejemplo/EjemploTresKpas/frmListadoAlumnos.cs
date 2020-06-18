using System;
using System.Windows.Forms;
using System.Data;

namespace EjemploTresKpas
{
    public partial class frmListadoAlumnos : Form
    {

        clsReglasAlumnos Alumnos = new clsReglasAlumnos();
        public frmListadoAlumnos()
        {
            InitializeComponent();
        }

        private void frmListadoAlumnos_Load(object sender, EventArgs e)
        {
            DataTable dt = Alumnos.AlumnosListar();
            dataGridView1.DataSource = dt;
        }
    }
}
