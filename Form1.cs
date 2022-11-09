using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRT_Factorization
{
    public partial class Form1 : Form
    {
        int[] primes = new int[] { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73};
        ToolTip t1 = new ToolTip();
        private bool found = false;
        public Form1()
        {
            InitializeComponent();

            t1.OwnerDraw = true;
            t1.Draw += new DrawToolTipEventHandler(t1_Draw);
            
        }

        void t1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("verdana", 10.0f);
            t1.BackColor = Color.FromArgb(40, 58, 30);
            t1.ForeColor = Color.Gold;
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Gold , new PointF(1, 1));
        }

        private void FactorBTN_Click(object sender, EventArgs e)
        {
            
            for (int i = 2; i < primes.Length ; i++)
            {
                int m1 = primes[i - 2];
                int m2 = primes[i - 1];
                int m3 = primes[i];
                int flag = 0;
                otherblabel.Text = "";
                otherb36label.Text = "";

                List<int> bm1 = new List<int>();
                List<int> bm2 = new List<int>();
                List<int> bm3 = new List<int>();

                List<int> am1 = new List<int>();
                List<int> am2 = new List<int>();
                List<int> am3 = new List<int>();

                List<int> am36 = new List<int>();
                List<int> bm36 = new List<int>();

                int nm1, nm2, nm3, nm36;
                
                nm1 = Convert.ToInt32(input.Value % m1);
                int[] m1QR = getQR(m1);
                for(int j = 0; j < m1QR.Length; j++)
                {
                    for (int k = 0; k < m1QR.Length; k++)
                    {
                        if( m1QR[k] - m1QR[j] == nm1 || m1QR[k] - m1QR[j] == nm1 - m1)
                        {
                            am1.Add(m1QR[k]);
                            bm1.Add(m1QR[j]);
                            flag = 1;
                        }
                    }
                }
                if(flag == 0)
                {
                    continue;
                }
                flag = 0;

                nm2 = Convert.ToInt32(input.Value % m2);
                int[] m2QR = getQR(m2);
                for (int j = 0; j < m2QR.Length; j++)
                {
                    for (int k = 0; k < m2QR.Length; k++)
                    {
                        if (m2QR[k] - m2QR[j] == nm2 || m2QR[k] - m2QR[j] == nm2 - m2)
                        {
                            am2.Add(m2QR[k]);
                            bm2.Add(m2QR[j]);
                            flag = 1;
                        }
                    }
                }
                if (flag == 0)
                {
                    continue;
                }
                flag = 0;

                nm3 = Convert.ToInt32(input.Value % m3);
                int[] m3QR = getQR(m3);
                for (int j = 0; j < m3QR.Length; j++)
                {
                    for (int k = 0; k < m3QR.Length; k++)
                    {
                        if (m3QR[k] - m3QR[j] == nm3 || m3QR[k] - m3QR[j] == nm3 - m3)
                        {
                            am3.Add(m3QR[k]);
                            bm3.Add(m3QR[j]);
                            flag = 1;
                        }
                    }
                }
                if (flag == 0)
                {
                    continue;
                }
                
                int b = CRT(bm1.ToArray(), m1, bm2.ToArray(), m2, bm3.ToArray(), m3);
                if (b == -1)
                    continue;
                int a = b + Convert.ToInt32(input.Value);
                
                nm36 = Convert.ToInt32(input.Value % 36);
                int[] m36QR = getQR(36);
                for (int j = 0; j < m36QR.Length; j++)
                {
                    for (int k = 0; k < m36QR.Length; k++)
                    {
                        if (m36QR[k] - m36QR[j] == nm36 || m36QR[k] - m36QR[j] == nm36 - 36)
                        {
                            am36.Add(m36QR[k]);
                            bm36.Add(m36QR[j]);
                        }
                    }
                }

                int b36 = CRT(bm36.ToArray(), 36, bm36.ToArray(), 36, bm36.ToArray(), 36);
                if (b36 == -1)
                    continue;
                int a36 = b36 + Convert.ToInt32(input.Value);
                
                alabel.Text = a.ToString();
                blabel.Text = b.ToString();
                
                n1label.Text = nm1.ToString();
                n2label.Text = nm2.ToString();
                n3label.Text = nm3.ToString();

                a1label.Text = string.Join(",", am1.ToArray());
                a2label.Text = string.Join(",", am2.ToArray());
                a3label.Text = string.Join(",", am3.ToArray());

                b1label.Text = string.Join(",", bm1.ToArray());
                b2label.Text = string.Join(",", bm2.ToArray());
                b3label.Text = string.Join(",", bm3.ToArray());

                a36label.Text = string.Join(",", am36.ToArray());
                b36label.Text = string.Join(",", bm36.ToArray());
                n36label.Text = nm36.ToString();

                m1label.Text = m1.ToString();
                m2label.Text = m2.ToString();
                m3label.Text = m3.ToString();
                
                asqrlabel.Text = asqrlabel2.Text = asqrlabel3.Text = Math.Sqrt(a).ToString();
                bsqrlabel.Text = bsqrlabel2.Text = bsqrlabel3.Text = Math.Sqrt(b).ToString();

                nlabel.Text = input.Value.ToString();

                plabel.Text = (Math.Sqrt(a) + Math.Sqrt(b)).ToString();
                qlabel.Text = (Math.Sqrt(a) - Math.Sqrt(b)).ToString();
                

                found = true;
                break;
            }

            if (found == false)
            {
                MessageBox.Show("Nothing has been found. \n" +
                    "please change your number.");
            }

        }

        private int CRT(int[] b1, int m1, int[] b2, int m2, int[] b3, int m3)
        {
            int lcm = m1 * m2 * m3;
            bool isgood = true;
            for (int i = 0; i < lcm; i++)
            {
                isgood = true;
                for(int ib1 = 0; ib1 < b1.Length; ib1++)
                {
                    if (i % m1 == b1[ib1])
                    {
                        isgood = true;
                        break;
                    }
                    isgood = false;
                }
                if (isgood != true)
                    continue;

                for (int ib2 = 0; ib2 < b2.Length; ib2++)
                {
                    if (i % m2 == b2[ib2])
                    {
                        isgood = true;
                        break;
                    }
                    isgood = false;
                }
                if (isgood != true)
                    continue;

                for (int ib3 = 0; ib3 < b3.Length; ib3++)
                {
                    if (i % m3 == b3[ib3])
                    {
                        isgood = true;
                        break;
                    }
                    isgood = false;
                }
                if (isgood != true)
                    continue;

                if (isquadratic(i))
                {
                    if(isquadratic(i + Convert.ToInt32(input.Value)))
                    {
                        return i;
                    }
                    
                    if(m1 != 36)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(otherblabel.Text);
                        sb.Append(", ");
                        sb.Append(i);
                        otherblabel.Text = sb.ToString();
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(otherb36label.Text);
                        sb.Append(", ");
                        sb.Append(i);
                        otherb36label.Text = sb.ToString();
                    }

                }

            }
            return -1;
        }

        private bool isquadratic(int number)
        {
            return ((Math.Sqrt(number) % 1 == 0));
        }
        private int[] getQR(int p)
        {
            List<int> Result = new List<int>();
            Result.Add(0);
            Result.Add(1);
            try
            {
                for (int i = 2; i < p; i++)
                {
                    if (!Result.Contains(Convert.ToInt32(Math.Pow(i, 2)) % p))
                    {
                        Result.Add(Convert.ToInt32(Math.Pow(i, 2)) % p);
                    }
                }
            }
            catch
            {
                MessageBox.Show("the number is too large");
                found = false;
            }
            
            return Result.ToArray();
        }

        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FactorBTN.PerformClick();
            }
        }

        private void a1label_MouseHover(object sender, EventArgs e)
        {
            Label lb = (sender as Label);
            
            t1.SetToolTip(lb, lb.Text);
        }
    }
}
