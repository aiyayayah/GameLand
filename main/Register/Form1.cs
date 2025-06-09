using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string icNumber = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(icNumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both IC Number and Password.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = @"D:\Cky's Uni Folder\Enterprise Application Integration\GameLand\users.txt";


            string userData = icNumber + "," + password;

            try
            {
                File.AppendAllText(filePath, userData + Environment.NewLine);
                MessageBox.Show("Registered as " + icNumber, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }
    }
}