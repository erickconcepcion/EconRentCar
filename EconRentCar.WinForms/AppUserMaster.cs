﻿using EconRentCar.Core;
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
    public partial class AppUserMaster : EntityBaseMasterForm<AppUser, AppUserDetail>
    {
        public AppUserMaster() : base(AppUserRepository.Instance, "")
        {
            InitializeComponent();
            Dtgv = dataGridView1;
            FieldDelimiter = e => new { e.Id, e.UserName, e.IsAdmin,e.IsActive };
        }

        private void AppUserMaster_Load(object sender, EventArgs e)
        {
            FillDtgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var busqueda = textBox1.Text.ToLower();
            FillDtgv(tc => tc.Id.ToString().Contains(busqueda) || tc.UserName.ToLower().Contains(busqueda));
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
