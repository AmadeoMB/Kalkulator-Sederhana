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

        private void cekTier1(String operasi = "")
        {
            int idx1 = -1;
            int idx2 = -1;

            if (operasi == "")
            {
                operasi = txtOperasi.Text;
            }

            for (int i = 0; i < operasi.Length; i++)
            {
                Int64 angkaPertama = 0;
                String tempAngkaPertama = "";
                Int64 angkaKedua = 0;
                String tempAngkaKedua = "";
                if (!cekAngka(operasi[i]))
                {
                    String tempOperasi = operasi[i].ToString();
                    Int64 hasil = 0;
                    if (tempOperasi.Equals("+"))
                    {
                        for (int j = i - 1; j > -1; j--)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx1 = j;
                            tempAngkaPertama += operasi[j];
                        }
                        String temp = "";
                        for (int j = tempAngkaPertama.Length - 1; j > -1; j--)
                        {
                            temp += tempAngkaPertama[j];
                        }
                        tempAngkaPertama = temp;

                        for (int j = i + 1; j < operasi.Length; j++)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx2 = j + 1;
                            tempAngkaKedua += operasi[j];
                        }
                        angkaPertama = Convert.ToInt64(tempAngkaPertama);
                        angkaKedua = Convert.ToInt64(tempAngkaKedua);
                        hasil = angkaPertama + angkaKedua;

                        operasi = operasi.Substring(0, idx1) + hasil + operasi.Substring(idx2);
                        txtAngka.Text = hasil + "";
                        txtOperasi.Text = operasi;
                        i = 0;
                    }
                    else if (tempOperasi.Equals("-"))
                    {
                        for (int j = i - 1; j > -1; j--)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx1 = j;
                            tempAngkaPertama += operasi[j];
                        }
                        String temp = "";
                        for (int j = tempAngkaPertama.Length - 1; j > -1; j--)
                        {
                            temp += tempAngkaPertama[j];
                        }
                        tempAngkaPertama = temp;

                        for (int j = i + 1; j < operasi.Length; j++)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx2 = j + 1;
                            tempAngkaKedua += operasi[j];
                        }

                        angkaPertama = Convert.ToInt64(tempAngkaPertama);
                        angkaKedua = Convert.ToInt64(tempAngkaKedua);
                        hasil = angkaPertama - angkaKedua;

                        operasi = operasi.Substring(0, idx1) + hasil + operasi.Substring(idx2);
                        txtAngka.Text = hasil + "";
                        txtOperasi.Text = operasi;
                        i = 0;
                    }
                }
            }
        }

        private void cekTier2(String operasi = "")
        {
            int idx1 = -1;
            int idx2 = -1;

            if (operasi == "")
            {
                operasi = txtOperasi.Text;
            }

            for (int i = 0; i < operasi.Length; i++)
            {
                Int64 angkaPertama = 0;
                String tempAngkaPertama = "";
                Int64 angkaKedua = 0;
                String tempAngkaKedua = "";
                if (!cekAngka(operasi[i]))
                {
                    String tempOperasi = operasi[i].ToString();
                    Int64 hasil = 0;
                    if (tempOperasi.Equals("x"))
                    {
                        for (int j = i - 1; j > -1; j--)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx1 = j;
                            tempAngkaPertama += operasi[j];
                        }
                        String temp = "";
                        for (int j = tempAngkaPertama.Length - 1; j > -1; j--)
                        {
                            temp += tempAngkaPertama[j];
                        }
                        tempAngkaPertama = temp;

                        for (int j = i + 1; j < operasi.Length; j++)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx2 = j + 1;
                            tempAngkaKedua += operasi[j];
                        }

                        angkaPertama = Convert.ToInt64(tempAngkaPertama);
                        angkaKedua = Convert.ToInt64(tempAngkaKedua);
                        hasil = angkaPertama * angkaKedua;

                        operasi = operasi.Substring(0, idx1) + hasil + operasi.Substring(idx2);
                        txtAngka.Text = hasil + "";
                        txtOperasi.Text = operasi;
                        i = 0;
                    }
                    else if (tempOperasi.Equals("/"))
                    {
                        for (int j = i - 1; j > -1; j--)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx1 = j;
                            tempAngkaPertama += operasi[j];
                        }
                        String temp = "";
                        for (int j = tempAngkaPertama.Length - 1; j > -1; j--)
                        {
                            temp += tempAngkaPertama[j];
                        }
                        tempAngkaPertama = temp;

                        for (int j = i + 1; j < operasi.Length; j++)
                        {
                            if (!cekAngka(operasi[j]))
                            {
                                break;
                            }
                            idx2 = j + 1;
                            tempAngkaKedua += operasi[j];
                        }

                        angkaPertama = Convert.ToInt64(tempAngkaPertama);
                        angkaKedua = Convert.ToInt64(tempAngkaKedua);
                        hasil = angkaPertama / angkaKedua;

                        operasi = operasi.Substring(0, idx1) + hasil + operasi.Substring(idx2);
                        txtAngka.Text = hasil + "";
                        txtOperasi.Text = operasi;
                        i = 0;
                    }
                }
            }
        }

        private void cekTier3()
        {

        }

        private void btnSamaDengan_Click(object sender, EventArgs e)
        {
            try
            {
                String tempStr = txtOperasi.Text + txtAngka.Text + "=";

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
                    cekTier1();


                    txtOperasi.Text = tempStr;
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
