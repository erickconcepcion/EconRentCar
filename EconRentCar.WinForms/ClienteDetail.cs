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
    public partial class ClienteDetail : EntityBaseDetailForm<Cliente>, IEntityBaseDetailForm<Cliente>
    {
        public ClienteDetail() : base(ClienteRepository.Instance)
        {
            InitializeComponent();
        }

        private Cliente BindData()
        {
            Cliente data;
            if (!ForUpdate)
            {
                data = new Cliente();
            }
            else
            {
                data = Entity;
            }
            data.Nombres = textBox2.Text;
            data.Apellidos = textBox3.Text;
            data.CedulaCliente = maskedTextBox1.Text;
            data.NoTArjetaCredito = maskedTextBox2.Text;
            try
            {
                data.LimiteCredito = double.Parse(textBox6.Text);
            }
            catch (Exception)
            {
                Error("Solo numeros decimales o enteros");
            }
            data.TipoPersona = (TipoPersona)comboBox1.SelectedValue;
            data.Activo = checkBox1.Checked;
            return data;
        }

        private void ClienteDetail_Load(object sender, EventArgs e)
        {
            ChargeEnumSelectList<TipoPersona>(comboBox1);
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Nombres;
                textBox3.Text = Entity.Apellidos;
                maskedTextBox1.Text = Entity.CedulaCliente;
                maskedTextBox2.Text = Entity.NoTArjetaCredito;
                textBox6.Text = Entity.LimiteCredito.ToString();
                comboBox1.SelectedItem = Entity.TipoPersona;
                checkBox1.Checked = Entity.Activo;
            }
            SetFormTitle("Agregar nueva Cliente", "Modificar Cliente");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
