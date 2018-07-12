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
    public partial class RentaMaster : EntityBaseMasterForm<Renta, RentaDetail>
    {
        public RentaMaster() : base(RentaRepository.Instance, "Cliente, Empleado, Vehiculo")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, Cliente = $"{e.Cliente.Nombres} {e.Cliente.Apellidos}",
                Empleado = e.Empleado.Apellidos, e.Comentario, e.EstadoRenta, e.FechaRenta, e.FechaDevolucion,
                Vehiculo = e.Vehiculo.Placa};
        }

        private void RentaMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda)
            || $"{tc.Cliente.Nombres} {tc.Cliente.Apellidos}".ToLower().Contains(busqueda)
            || tc.Empleado.Apellidos.ToLower().Contains(busqueda)
            || tc.Comentario.ToLower().Contains(busqueda)
            || tc.EstadoRenta.ToString().ToLower().Contains(busqueda)
            || tc.FechaRenta.ToShortDateString().ToLower().Contains(busqueda)
            || tc.FechaDevolucion.ToShortDateString().ToLower().Contains(busqueda)
            || tc.Vehiculo.Placa.ToLower().Contains(busqueda));
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
