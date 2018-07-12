using Microsoft.Reporting.WinForms;
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
    public partial class ReporteRentasPorFechas : Form
    {
        public ReporteRentasPorFechas()
        {
            InitializeComponent();
        }

        private void ReporteRentasPorFechas_Load(object sender, EventArgs e)
        {
            
            reportViewer2.RefreshReport();

        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
