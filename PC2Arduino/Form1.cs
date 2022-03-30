using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC2Arduino {
    public partial class SerialMonitor : Form {
        public string str;

        public SerialMonitor() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //serialPort1.Open();

            string[] PortList = SerialPort.GetPortNames();
            cmbPortName.Items.Clear();
            foreach (string PortName in PortList) {
                cmbPortName.Items.Add(PortName);
            }
            if (cmbPortName.Items.Count > 0) {
                cmbPortName.SelectedIndex = 0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
            str = serialPort1.ReadLine();
            this.Invoke(new EventHandler(Check_input));
        }


        private void Check_input(object sender, EventArgs e) {
            textBox1.Text += str+"\n";

        }

        private void button1_Click(object sender, EventArgs e) {
            serialPort1.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (serialPort1.IsOpen == true) {
                return;
            }
            serialPort1.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            textBox1.SelectionStart = textBox1.MaxLength;
            textBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e) {
            textBox1.ResetText();
        }


        private void label3_Click(object sender, EventArgs e) {

        }
    }
}
