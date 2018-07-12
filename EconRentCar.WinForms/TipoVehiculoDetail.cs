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
    public partial class TipoVehiculoDetail : EntityBaseDetailForm<TipoVehiculo>, IEntityBaseDetailForm<TipoVehiculo>
    {
        public TipoVehiculoDetail() : base(TipoVehiculoRepository.Instance)
        {
            InitializeComponent();
        }

        private TipoVehiculo BindData()
        {
            TipoVehiculo data;
            if (!ForUpdate)
            {
                data = new TipoVehiculo();
            }
            else
            {
                data = Entity;
            }
            data.Nombre = textBox2.Text;
            data.Descripcion = textBox3.Text;
            data.Activo = checkBox1.Checked;
            return data;
        }

        private void TipoVehiculoDetail_Load(object sender, EventArgs e)
        {
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Nombre;
                textBox3.Text = Entity.Descripcion;
                checkBox1.Checked = Entity.Activo;
            }
            SetFormTitle("Agregar nueva Tipo Vehiculo", "Modificar Tipo Vehiculo");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
