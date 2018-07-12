using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EconRentCar.Core;
using EconRentCar.DataModel;
using EconRentCar.Logics.Repositories;

namespace EconRentCar.WinForms
{
    public partial class VehiculoMaster : EntityBaseMasterForm<Vehiculo, VehiculoDetail>
    {
        public VehiculoMaster() : base(VehiculoRepository.Instance, "Modelo,TipoCombustible,TipoVehiculo")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, e.Placa, e.Descripcion, e.EstadoVehiculo, e.NoChasis, e.NoMotor,
            Combustible = e.TipoCombustible.Nombre, Tipo = e.TipoVehiculo.Nombre, Modelo =e.Modelo.Nombre};
        }

        private void VehiculoMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda)
            || tc.Placa.ToLower().Contains(busqueda)
            || tc.Descripcion.ToLower().Contains(busqueda)
            || tc.EstadoVehiculo.ToString().ToLower().Contains(busqueda)
            || tc.NoChasis.ToLower().Contains(busqueda)
            || tc.NoMotor.ToLower().Contains(busqueda)
            || tc.TipoCombustible.Nombre.ToLower().Contains(busqueda)
            || tc.TipoVehiculo.Nombre.ToLower().Contains(busqueda)
            || tc.Modelo.Nombre.ToLower().Contains(busqueda)
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
