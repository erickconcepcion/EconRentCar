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
    public partial class TipoCombustibleDetail : EntityBaseDetailForm<TipoCombustible>, IEntityBaseDetailForm<TipoCombustible>
    {
        public TipoCombustibleDetail(): base(TipoCombustibleRepository.Instance)
        {
            InitializeComponent();
        }

        private TipoCombustible BindData()
        {
            TipoCombustible data;
            if (!ForUpdate)
            {
                data = new TipoCombustible();
            }
            else
            {
                data = Entity;
            }
            data.Nombre = textBox2.Text;
            data.Activo = checkBox1.Checked;
            return data;
        }

        private void TipoCombustibleDetail_Load(object sender, EventArgs e)
        {
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Nombre;
                checkBox1.Checked = Entity.Activo;
            }
            SetFormTitle("Agregar nuevo Tipo de combustible", "Modificar nuevo Tipo de combustible");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
