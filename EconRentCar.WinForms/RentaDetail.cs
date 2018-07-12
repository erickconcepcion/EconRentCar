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
    public partial class RentaDetail : EntityBaseDetailForm<Renta>, IEntityBaseDetailForm<Renta>
    {
        public RentaDetail() : base(RentaRepository.Instance)
        {
            InitializeComponent();
        }

        private Renta BindData()
        {
            Renta data;
            if (!ForUpdate)
            {
                data = new Renta();
            }
            else
            {
                data = Entity;
            }
            data.FechaRenta = dateTimePicker1.Value;
            data.FechaDevolucion = dateTimePicker2.Value;
            data.Comentario = textBox2.Text;
            data.VehiculoId = (int)comboBox1.SelectedValue;
            data.ClienteId = (int)comboBox2.SelectedValue;
            data.EmpleadoId = EmpleadoRepository.Instance.Get().FirstOrDefault().Id;
            data.EstadoRenta = (EstadoRenta)comboBox3.SelectedValue;
            return data;
        }

        private void RentaDetail_Load(object sender, EventArgs e)
        {
            ChargeEnumSelectList<EstadoRenta>(comboBox3);
            ChargeDataSelectList(comboBox2, ClienteRepository.Instance.Get(), "Nombres", "Id",  c => new { c.Id, c.Nombres });
            ChargeDataSelectList(comboBox1, VehiculoRepository.Instance.Get(), "Placa", "Id", v => new { v.Id, v.Placa });
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                dateTimePicker1.Value = Entity.FechaRenta ;
                dateTimePicker2.Value = Entity.FechaDevolucion ;
                textBox2.Text = Entity.Comentario;
                comboBox1.SelectedValue = Entity.VehiculoId;
                comboBox2.SelectedValue = Entity.ClienteId;
                comboBox3.SelectedValue = Entity.EstadoRenta;
            }
            SetFormTitle("Agregar nueva Renta", "Modificar Renta");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
