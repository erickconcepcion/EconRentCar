using EconRentCar.DataModel;
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
using EconRentCar.Logics.Repositories;
using System.Data.Entity;

namespace EconRentCar.WinForms
{
    public partial class TipoCombustibleMaster : EntityBaseMasterForm<TipoCombustible, TipoCombustibleDetail>
    {
        public TipoCombustibleMaster(): base (TipoCombustibleRepository.Instance, "")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, e.Nombre, e.Activo };
        }

        private void TipoCombustibleMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda) 
            || tc.Nombre.ToLower().Contains(busqueda));
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
