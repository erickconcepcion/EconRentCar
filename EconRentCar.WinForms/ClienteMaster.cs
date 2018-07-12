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
    public partial class ClienteMaster : EntityBaseMasterForm<Cliente, ClienteDetail>
    {
        public ClienteMaster() : base(ClienteRepository.Instance, "")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, e.Nombres, e.Apellidos, e.CedulaCliente, e.LimiteCredito, e.NoTArjetaCredito, e.TipoPersona, e.Activo };
        }

        private void ClienteMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda)
                || tc.Nombres.ToLower().Contains(busqueda)
                || tc.Apellidos.ToLower().Contains(busqueda)
                || tc.CedulaCliente.ToLower().Contains(busqueda)
                || tc.NoTArjetaCredito.ToLower().Contains(busqueda)
                || tc.TipoPersona.ToString().ToLower().Contains(busqueda)
                || tc.Activo.ToString().ToLower().Contains(busqueda)

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
