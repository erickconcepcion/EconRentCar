using EconRentCar.Core;
using EconRentCar.DataModel;
using EconRentCar.Logics.Repositories;
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
    public partial class InspeccionMaster : EntityBaseMasterForm<Inspeccion, InspeccionDetail>
    {
        public InspeccionMaster() : base(InspeccionRepository.Instance, "Renta.Vehiculo")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, e.RentaId, e.Renta.Vehiculo.Placa,e.FechaInspeccion, e.CargosExtra,
                e.GalonesCombustibles, e.CristalRoto, e.TieneRayaduras, e.TieneGato, e.GomasDaniadas,
                e.TieneGomaRepuesta, e.PasaInspeccion };
        }

        private void InspeccionMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda)
            || tc.RentaId.ToString().ToLower().Contains(busqueda)
            || tc.Renta.Vehiculo.Placa.ToLower().Contains(busqueda)
            || tc.FechaInspeccion.ToString().ToLower().Contains(busqueda)
            || tc.CargosExtra.ToString().ToLower().Contains(busqueda)
            || tc.GalonesCombustibles.ToString().ToLower().Contains(busqueda)
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModifyAction((int)dataGridView1.CurrentRow.Cells["Id"].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAction((int)dataGridView1.CurrentRow.Cells["Id"].Value);
        }
    }
}
