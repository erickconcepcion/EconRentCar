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
    public partial class VehiculoDetail : EntityBaseDetailForm<Vehiculo>, IEntityBaseDetailForm<Vehiculo>
    {
        public VehiculoDetail() : base(VehiculoRepository.Instance)
        {
            InitializeComponent();
        }

        private Vehiculo BindData()
        {
            Vehiculo data;
            if (!ForUpdate)
            {
                data = new Vehiculo();
            }
            else
            {
                data = Entity;
            }
            data.Placa = textBox2.Text;
            data.Descripcion = textBox3.Text;
            data.NoChasis = textBox4.Text;
            data.NoMotor = textBox5.Text;
            data.EstadoVehiculo = (EstadoVehiculo)comboBox1.SelectedValue;
            data.TipoVehiculoId =(int)comboBox4.SelectedValue;
            data.ModeloId = (int)comboBox3.SelectedValue;
            data.TipoCombustibleId= (int)comboBox2.SelectedValue;
            return data;
        }

        private void VehiculoDetail_Load(object sender, EventArgs e)
        {
            ChargeEnumSelectList<EstadoVehiculo>(comboBox1);
            ChargeDataSelectList(comboBox4, TipoVehiculoRepository.Instance.Get(), "Nombre", "Id", tv => new { tv.Id, tv.Nombre });
            ChargeDataSelectList(comboBox3, ModeloRepository.Instance.Get(), "Nombre", "Id", m => new { m.Id, m.Nombre });
            ChargeDataSelectList(comboBox2, TipoCombustibleRepository.Instance.Get(), "Nombre", "Id", tc => new { tc.Id, tc.Nombre });
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Placa;
                textBox3.Text = Entity.Descripcion;
                textBox4.Text = Entity.NoChasis;
                textBox5.Text = Entity.NoMotor;
                comboBox1.SelectedValue = Entity.EstadoVehiculo;
                comboBox2.SelectedValue = Entity.TipoVehiculoId;
                comboBox3.SelectedValue = Entity.ModeloId;
                comboBox4.SelectedValue = Entity.TipoCombustibleId;
            }
            SetFormTitle("Agregar nueva Vehiculo", "Modificar Vehiculo");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
