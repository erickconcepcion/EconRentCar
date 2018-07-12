using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EconRentCar.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void usuariosDeAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AppUserMaster().ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MarcaMaster().ShowDialog();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModeloMaster().ShowDialog();
        }

        private void tipoDeCombustiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TipoCombustibleMaster().ShowDialog();
        }

        private void tiposDeVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TipoVehiculoMaster().ShowDialog();

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ClienteMaster().ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmpleadoMaster().ShowDialog();
        }

        private void inspeccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InspeccionMaster().ShowDialog();
        }

        private void rentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RentaMaster().ShowDialog();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VehiculoMaster().ShowDialog();
        }

        private void reporteRentasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReporteRentasPorFechas().ShowDialog();
        }
    }
}
