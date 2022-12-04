using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Notepad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        Random rand = new Random();
        bool activated = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("-Notepad is not activated. Features like saving, clipboard, etc. are not available.\n\nDo you wish to activate now?","Product Activation",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                wait(2300);
                MessageBox.Show("Failed to activate. Please try again later.", "Product Activation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            activated = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void richTextBox1_KeyPress(object sender, KeyEventArgs e)
        {
            if (!activated) { e.SuppressKeyPress = true; return; }
            System.Threading.Thread.Sleep(rand.Next(1000,5000));
            if (rand.Next(1,11) == 1)
            {
                System.Environment.FailFast("Exception processing input event", new ApplicationException());
            } else {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 16)
            {
                System.Environment.FailFast("Stack overflow", new StackOverflowException());
            }
        }
    }
}
