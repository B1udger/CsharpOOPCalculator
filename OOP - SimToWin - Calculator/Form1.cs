using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP___SimToWin___Calculator
{
    public partial class Form1 : Form
    {
        double x;
        double Result = 0;
        double Memory = 0;
        string Operation = " ";
        string preOperation =" ";
        bool Value = false;
        

        public Form1()
        {
        InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            lblmain.Text = " ";
            lblmem.Text = " ";

            for (int i = 0; i < this.Controls.Count; i++)
            {
                var control = this.Controls[i];
                if (control is Button && control.Text.Contains("button"))
                {
                    control.Text = control.Text[control.Text.Length - 1].ToString();
                }

            }
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            buttonRes.PerformClick();
            Memory = 0;
            lblmem.Text = " ";
        }

        private void buttonMM_Click(object sender, EventArgs e)
        {
            buttonRes.PerformClick();
            Memory -= Result; 
            lblmem.Text = Memory + " " + Operation + " " + Result + " = ";
           
        }


        private void buttonMP_Click(object sender, EventArgs e)
        {
            buttonRes.PerformClick();
            Memory += Result;
            lblmem.Text = Memory + " " + Operation + " " + Result + " = ";
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            buttonRes.PerformClick();
            lblmain.Text = Memory.ToString();
            Memory = 0;
            lblmem.Text = " ";
            lblmem.Text = Memory + " " + Operation + " " + Result + " = ";
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case "+":
                    buttonPLS.PerformClick();
                    break;
                case "-":
                    buttonMIN.PerformClick();
                    break;
                case "*":
                    buttonMUL.PerformClick();
                    break;
                case "/":
                    buttonDIV.PerformClick();
                    break;
                case "ENTER":
                    buttonRes.PerformClick();
                    break;
                default:
                    return;

            }
            e.Handled = true;
        }

        private void buttonmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonmaxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MessageBox.Show("isn't the best option! :D");
            this.WindowState = FormWindowState.Normal;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblmem_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (lblmain.Text.Length > 0)
            {

                lblmain.Text = lblmain.Text.Remove(lblmain.Text.Length - 1, 1);
            
            }

            if(lblmain.Text == "")
            {
                lblmain.Text = "0";
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            lblmain.Text = " ";
            Result = 0;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            lblmain.Text = " ";
            lblmem.Text = " ";
            Result = 0;
        }

        private void buttonnumbers_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((lblmain.Text == "0") || (Value))
            {
                lblmain.Text = "";
                Value = false;
            }
            if (b.Text == ".")
            {
                if (!lblmain.Text.Contains("."))
                {
                    lblmain.Text = lblmain.Text + b.Text;
                }

            }
            else
            {
                lblmain.Text = lblmain.Text + b.Text;
            }



            
        }

        private void operators_Click(object sender, EventArgs e)
        {
                Button b = (Button)sender;
             if (Result != 0)
            {
                buttonRes.PerformClick();
                Operation = b.Text;
                Value = true;
                preOperation = Operation;
                lblmem.Text = Result + " " + Operation;

            }
            else
            {
                buttonRes.PerformClick();
                Operation = b.Text;
                Result = Double.Parse(lblmain.Text);
                lblmain.Text = " ";
                lblmem.Text = System.Convert.ToString(Result) + " " + Operation;

            }
           
           


        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            lblmem.Text = " ";
            x = double.Parse(lblmain.Text);
            switch (Operation)
            {
                case "+":
                    lblmain.Text = (Result + x).ToString();
                    break;
                case "-":
                    lblmain.Text = (Result - x).ToString();
                    break;
                case "*":
                    lblmain.Text = (Result * x).ToString();
                    break;
                case "/":
                    if(x == 0)
                    {
                        MessageBox.Show("Can't Divivde 0");
                    }
                    lblmain.Text = Math.Round(Result / x).ToString();
                    break;
                default:
                    break;

                    
            }
            Result = x;
            Operation = "";
            Value = true;

        }

        private void pulmin_Click(object sender, EventArgs e)
        {
            lblmain.Text = (double.Parse(lblmain.Text) * -1).ToString();
        }

        private void buttonROT_Click(object sender, EventArgs e)
        {
            Result += Math.Round(Math.Sqrt(double.Parse(lblmain.Text)));
            lblmain.Text = Result.ToString();
        }

        private void sqr_Click(object sender, EventArgs e)
        {
           double x2;

            x2 = Convert.ToDouble(lblmain.Text) * Convert.ToDouble(lblmain.Text);
            lblmain.Text = System.Convert.ToString(x2);
            
        }

        private void buttonproc_Click(object sender, EventArgs e)
        {
            double proc;

            proc = Convert.ToDouble(lblmain.Text) / Convert.ToDouble(100);
            lblmain.Text = System.Convert.ToString(proc);
        }

        private void button1x_Click(object sender, EventArgs e)
        {
            double x1;
            x1 = Convert.ToDouble(1.0 / Convert.ToDouble(lblmain.Text));
            lblmain.Text = System.Convert.ToString(x1);
            

        }
    }
}
