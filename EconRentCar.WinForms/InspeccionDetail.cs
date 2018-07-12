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
    
    public partial class InspeccionDetail : EntityBaseDetailForm<Inspeccion>, IEntityBaseDetailForm<Inspeccion>
    {
        public InspeccionDetail() : base(InspeccionRepository.Instance, "Cliente,Vehiculo")
        {
            InitializeComponent();
        }

        private Inspeccion BindData()
        {
            Inspeccion data;
            if (!ForUpdate)
            {
                data = new Inspeccion();
            }
            else
            {
                data = Entity;
            }
            data.RentaId = (int)comboBox1.SelectedValue;
            data.FechaInspeccion = dateTimePicker1.Value;
            try
            {
                data.GalonesCombustibles = decimal.Parse(textBox2.Text);
                data.CargosExtra = decimal.Parse(textBox3.Text);
            }
            catch (Exception)
            {
                Error("Solo numeros decimales o enteros");
            }
            /*renta galones cargos extra fecha raya repuesta gato ins gomas cristal*/
            data.TieneRayaduras = checkBox1.Checked;
            data.TieneGomaRepuesta = checkBox2.Checked;
            data.TieneGato = checkBox3.Checked;
            data.PasaInspeccion = checkBox4.Checked;
            data.GomasDaniadas = checkBox5.Checked;
            data.CristalRoto = checkBox6.Checked;
            return data;
        }

        private void InspeccionDetail_Load(object sender, EventArgs e)
        {
            ChargeEnumSelectList<TandaLaboral>(comboBox1);
            ChargeDataSelectList(comboBox1, RentaRepository.Instance.Get(), "ClientePlaca", "Id",  u => new { u.Id, ClientePlaca =$"{u.Cliente.Nombres}{u.Vehiculo.Placa}" });
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                comboBox1.SelectedValue= Entity.RentaId;
                dateTimePicker1.Value = Entity.FechaInspeccion;
            }
            SetFormTitle("Agregar nueva Inspeccion", "Modificar Inspeccion");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
