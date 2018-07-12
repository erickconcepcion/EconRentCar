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
    public partial class AppUserDetail : EntityBaseDetailForm<AppUser>, IEntityBaseDetailForm<AppUser>
    {
        public AppUserDetail() : base(AppUserRepository.Instance)
        {
            InitializeComponent();
        }

        private AppUser BindData()
        {
            AppUser data;
            if (!ForUpdate)
            {
                data = new AppUser();
            }
            else
            {
                data = Entity;
            }
            data.UserName = textBox2.Text;
            data.Password = textBox3.Text;
            data.IsActive = checkBox1.Checked;
            data.IsAdmin = checkBox2.Checked;
            return data;
        }

        private void AppUserDetail_Load(object sender, EventArgs e)
        {
            if (ForUpdate)
            {
                textBox1.Text = Entity.Id.ToString();
                textBox2.Text = Entity.UserName;
                textBox3.Text = Entity.Password;
                checkBox1.Checked = Entity.IsActive;
                checkBox2.Checked = Entity.IsAdmin;
            }
            SetFormTitle("Agregar nuevo Usuario", "Modificar Usuario");
        }

        private void button1_Click(object sender, EventArgs e) => SaveOrUpdate(BindData);

        private void button2_Click(object sender, EventArgs e) => Close();
    }
}