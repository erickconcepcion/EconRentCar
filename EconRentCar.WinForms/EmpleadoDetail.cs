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
    public partial class EmpleadoDetail : EntityBaseDetailForm<Empleado>, IEntityBaseDetailForm<Empleado>
    {
        public EmpleadoDetail() : base(EmpleadoRepository.Instance)
        {
            InitializeComponent();
        }

        private Empleado BindData()
        {
            Empleado data;
            if (!ForUpdate)
            {
                data = new Empleado();
            }
            else
            {
                data = Entity;
            }
            data.Nombres = textBox2.Text;
            data.Apellidos = textBox3.Text;
            data.CedulaEmpleado = maskedTextBox1.Text;
            try
            {
                data.PorcentajeComision = decimal.Parse(textBox6.Text);
            }
            catch (Exception)
            {
                Error("Solo numeros decimales o enteros");
            }
            data.FechaIngreso = dateTimePicker1.Value;
            data.TandaLaboral = (TandaLaboral)comboBox1.SelectedValue;
            data.AppUserId = (int)comboBox2.SelectedValue;
            data.Activo = checkBox1.Checked;
            return data;
        }

        private void EmpleadoDetail_Load(object sender, EventArgs e)
        {
            ChargeEnumSelectList<TandaLaboral>(comboBox1);
            ChargeDataSelectList(comboBox2, AppUserRepository.Instance.Get(), "UserName", "Id", u => new { u.Id, u.UserName });
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Nombres;
                textBox3.Text = Entity.Apellidos;
                maskedTextBox1.Text = Entity.CedulaEmpleado;
                textBox6.Text = Entity.PorcentajeComision.ToString();
                comboBox1.SelectedValue = Entity.TandaLaboral;
                comboBox2.SelectedValue = Entity.AppUserId;
                checkBox1.Checked = Entity.Activo;
            }
            SetFormTitle("Agregar nueva Empleado", "Modificar Empleado");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
