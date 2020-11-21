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

        private Boolean cekAngka(char angka)
        {
            if (
                angka.Equals('0')
                ||
                angka.Equals('1')
                ||
                angka.Equals('2')
                ||
                angka.Equals('3')
                ||
                angka.Equals('4')
                ||
                angka.Equals('5')
                ||
                angka.Equals('6')
                ||
                angka.Equals('7')
                ||
                angka.Equals('8')
                ||
                angka.Equals('9')
                )
            {
                return true;
            }
            return false;
        }

        private void tambahOperasi(String operasi)
        {
            if (txtOperasi.TextLength < 1 || !txtOperasi.Text[txtOperasi.TextLength-1].Equals(')'))
            {
                txtOperasi.Text += txtAngka.Text + operasi;
                txtAngka.Text = "0";
                return;
            }
            txtOperasi.Text += operasi;
        }

        private void cekTier2()
        {
            for (int i = 0; i < txtOperasi.TextLength;)
            {
                Int64 temp = 0;
                if (cekAngka(txtOperasi.Text[i]))
                {
                    i++;
                }

                if (i < txtOperasi.TextLength)
                {
                    if (txtOperasi.Text[i].Equals('/'))
                    {
                        temp = Convert.ToInt64(txtOperasi.Text[i - 1].ToString());
                        temp /= Convert.ToInt64(txtOperasi.Text[i + 1].ToString());

                        String tempStr = txtOperasi.Text.Substring(0, i - 1);
                        tempStr += temp.ToString();
                        txtOperasi.Text = tempStr + txtOperasi.Text.Substring(i + 2);
                    }
                    else if (txtOperasi.Text[i].Equals('x'))
                    {
                        temp = Convert.ToInt64(txtOperasi.Text[i - 1].ToString());
                        temp *= Convert.ToInt64(txtOperasi.Text[i + 1].ToString());

                        String tempStr = txtOperasi.Text.Substring(0, i - 1);
                        tempStr += temp.ToString();
                        txtOperasi.Text = tempStr + txtOperasi.Text.Substring(i + 2);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void cekTier3()
        {
            
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
            tambahOperasi("x");
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
                    if (!cekAngka(txtOperasi.Text[txtOperasi.TextLength-1]))
                    {
                        if (txtOperasi.Text[txtOperasi.TextLength - 1].Equals(')'))
                        {
                            txtOperasi.Text += ")";
                        }
                        else
                        {
                            tambahOperasi(")");
                        }
                    }
                    jumlah_kurungBuka--;
                    return;
                }
            }
        }

        private void btnSamaDengan_Click(object sender, EventArgs e)
        {
            try
            {
                String tempStr = txtOperasi.Text + "=";

                if (txtOperasi.TextLength > 0)
                {
                    if (!cekAngka(txtOperasi.Text[txtOperasi.TextLength - 1]))
                    {
                        txtOperasi.Text += txtAngka.Text;
                    }
                    if (jumlah_kurungBuka > 0)
                    {
                        for (int i = 0; i < jumlah_kurungBuka; i++)
                        {
                            txtOperasi.Text += ")";
                        }
                    }

                    cekTier2();

                    Int64 hasil = 0;
                    String tempHasil = "";
                    Boolean angkaPertama = false;

                    for (int i = 0; i < txtOperasi.TextLength; i++)
                    {
                        if (!cekAngka(txtOperasi.Text[i]))
                        {
                            angkaPertama = true;
                            i++;
                            if (txtOperasi.Text[i - 1].Equals('+'))
                            {
                                hasil += Convert.ToInt64(txtOperasi.Text[i] + "");
                            }
                            else
                            {
                                hasil -= Convert.ToInt64(txtOperasi.Text[i] + "");
                            }
                        }
                        if (!angkaPertama)
                        {
                            tempHasil += txtOperasi.Text[i];
                            hasil = Convert.ToInt64(tempHasil + "");
                        }
                    }

                    MessageBox.Show(hasil + "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
