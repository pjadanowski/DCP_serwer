﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace UDP_serwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int port = System.Convert.ToInt16(numericUpDown1.Value);
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                UdpClient serwer = new UdpClient(port);
                Byte[] odczyt = serwer.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(odczyt);
                listBox1.Items.Add(dane);
                serwer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "błąd");
                throw;
            }
        }
    }
}
