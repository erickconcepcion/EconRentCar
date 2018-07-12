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
    public partial class ModeloDetail : EntityBaseDetailForm<Modelo>, IEntityBaseDetailForm<Modelo>
    {
        public ModeloDetail() : base(ModeloRepository.Instance)
        {
            InitializeComponent();
        }

        private Modelo BindData()
        {
            Modelo data;
            if (!ForUpdate)
            {
                data = new Modelo();
            }
            else
            {
                data = Entity;
            }
            data.Nombre = textBox2.Text;
            data.Descripcion = textBox3.Text;
            data.MarcaId = (int)comboBox1.SelectedValue;
            data.Activo = checkBox1.Checked;
            return data;
        }

        private void ModeloDetail_Load(object sender, EventArgs e)
        {
            ChargeDataSelectList(comboBox1, MarcaRepository.Instance.Get(),"Nombre", "Id", d=> new { d.Id, d.Nombre});
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.Nombre;
                textBox3.Text = Entity.Descripcion;
                comboBox1.SelectedItem = Entity.MarcaId;
                checkBox1.Checked = Entity.Activo;
            }
            SetFormTitle("Agregar nueva Modelo", "Modificar Modelo");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}
