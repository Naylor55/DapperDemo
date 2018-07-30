
using DapperDemo;
using DapperDemo.Models;
using DapperDemo.service;
using DapperDemo.service.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            IInventoryItemServices iiservice = new InventoryItemServiceslmpl();
            IEnumerable<WaitPickingOrderDto> data = iiservice.GetWaitPickingOrder(1);
            this.dataGridView1.DataSource = data;
        }
    }
}
