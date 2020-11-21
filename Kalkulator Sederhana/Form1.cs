using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_Sederhana
{
    public partial class Form1 : Form
    {
        private int jumlah_kurungBuka = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private Boolean cekNol(String angka)
        {
            if (txtAngka.Text.Equals("0"))
            {
                txtAngka.Text = angka;
                return false;
            }
            return true;
        }

        private void tambahOperasi(String operasi)
        {
            txtOperasi.Text += txtAngka.Text + operasi;
            txtAngka.Text = "0";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!txtAngka.Text.Equals("0"))
            {
                txtAngka.Text += "0";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (cekNol("1"))
            {
                txtAngka.Text += "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (cekNol("2"))
            {
                txtAngka.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (cekNol("3"))
            {
                txtAngka.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (cekNol("4"))
            {
                txtAngka.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (cekNol("5"))
            {
                txtAngka.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (cekNol("6"))
            {
                txtAngka.Text += "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (cekNol("7"))
            {
                txtAngka.Text += "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (cekNol("8"))
            {
                txtAngka.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (cekNol("9"))
            {
                txtAngka.Text += "9";
            }
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            if (txtAngka.Text.Equals("0"))
            {
                return;
            }

            if (txtAngka.Text[0].Equals('-'))
            {
                txtAngka.Text = txtAngka.Text.Substring(1);
            }
            else
            {
                txtAngka.Text = "-" + txtAngka.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOperasi.Text = "";
            txtAngka.Text = "0";
        }

        private void btnKoma_Click(object sender, EventArgs e)
        {
            txtAngka.Text += ",";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            tambahOperasi("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            tambahOperasi("-");
        }

        private void btnKali_Click(object sender, EventArgs e)
        {
            tambahOperasi("X");
        }

        private void btnBagi_Click(object sender, EventArgs e)
        {
            tambahOperasi("/");
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtAngka.TextLength == 1)
            {
                txtAngka.Text = "0";
            }
            else
            {
                txtAngka.Text = txtAngka.Text.Substring(0, txtAngka.TextLength - 1);
            }
        }

        private void btnClearAngka_Click(object sender, EventArgs e)
        {
            txtAngka.Text = "0";
        }

        private void btnKurungBuka_Click(object sender, EventArgs e)
        {
            txtOperasi.Text += "(";
            jumlah_kurungBuka++;
        }

        private void btnKurungTutup_Click(object sender, EventArgs e)
        {
            foreach (var item in txtOperasi.Text)
            {
                if (item.Equals('(') && jumlah_kurungBuka > 0)
                {
                    tambahOperasi(")");
                    jumlah_kurungBuka--;
                    return;
                }
            }
        }
    }
}
