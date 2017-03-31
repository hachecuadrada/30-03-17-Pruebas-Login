using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30_03_17_Pruebas_Login
{
    public partial class Form1 : Form
    {
        Conexion c = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(c.PersonaRegistrada(Convert.ToInt32(txtId.Text)) == 0) {
                MessageBox.Show(c.Insertar(Convert.ToInt32(txtId.Text), txtContra.Text, txtUsu.Text));
            }
            else
            {
                MessageBox.Show("Duplicado");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
