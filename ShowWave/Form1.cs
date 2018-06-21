using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ShowWave
{
    public partial class Form1 : Form
    {
        private string fileName;
        private Wav wavFile;

        private int begin;
        private int finish;
        private int hPro = 1;
        private int offset = 0;
        private bool offlag = false;
        private bool loadflag = false;
        private int heiPro = 0;
        private int widPro = 0;
        private Bitmap mapScreen;
        private Bitmap mapLocate;
        private int sampleMax;
        public Form1()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "WAV|*.wav";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fDialog.FileName;
                wavFile = new Wav(fileName);

                if (wavFile.LoadFlag == true)
                {
                    sampleMax = wavFile.WavSamples.Max();
                    hPro = 1;
                    heiPro = sampleMax / pbScreen.Height;
                    widPro = wavFile.BlockNum / pbScreen.Width;
                    offlag = false;
                    loadflag = true;
                    offset = 0;
                    ShowWave();
                }
                else
                {
                    MessageBox.Show("打开文件失败，请检查 ");
                }
            }
        }

        private void ShowWave()
        {
            Pen penBlack = new Pen(Color.Black, 1);
            Pen penGold = new Pen(Color.Gold, 2);
            mapScreen = new Bitmap(pbScreen.Width, pbScreen.Height);
            mapLocate = new Bitmap(pbLocate.Width, pbLocate.Height);
            Graphics gScreenBm = Graphics.FromImage(mapScreen);
            Graphics gLocateBm = Graphics.FromImage(mapLocate);
            gScreenBm.FillRectangle(new SolidBrush(pbScreen.BackColor), 0, 0, pbScreen.Width, pbScreen.Height);
            gLocateBm.FillRectangle(new SolidBrush(pbLocate.BackColor), 0, 0, pbLocate.Width, pbLocate.Height);

            heiPro = (sampleMax / pbScreen.Height) * hPro;
            
            if (offlag)
                offlag = false;
            else if (offset < 0)
                offset = 0;
            else if (offset > (wavFile.BlockNum / widPro - pbScreen.Width))
                if (wavFile.BlockNum / widPro - pbScreen.Width > 0)
                    offset = wavFile.BlockNum / widPro - pbScreen.Width;
                else
                    offset = 0;

            float timenow = offset * (float)widPro / wavFile.Sample;
            rtbInfo.Text = string.Empty;
            rtbInfo.AppendText("offset:" + offset.ToString() + "\n");
            rtbInfo.AppendText("widPro:" + widPro.ToString() + "\n");
            rtbInfo.AppendText("heiPro:" + heiPro.ToString() + "\n");
            rtbInfo.AppendText("SampleNum:" + wavFile.SampleNum + "\n");
            rtbInfo.AppendText("NotDefinition:"+wavFile.NotDefinition.ToString() + "\n");

            gLocateBm.FillRectangle(Brushes.Gold, (pbScreen.Width * offset * widPro) / wavFile.BlockNum, 0,
                pbScreen.Width * pbScreen.Width / (wavFile.BlockNum / widPro), pbLocate.Height);
            gLocateBm.DrawString("0", DefaultFont, Brushes.Black, 0, 0);
            gLocateBm.DrawString(wavFile.SoundLength.ToString("0.000"), DefaultFont, Brushes.Black, pbLocate.Width - 35, 0);
            gLocateBm.DrawString(timenow.ToString("0.000"), DefaultFont, Brushes.Black,
                (pbScreen.Width * offset * widPro) / wavFile.BlockNum, 0);
            gScreenBm.DrawLine(penGold, 0, pbScreen.Height, pbScreen.Right, pbScreen.Height);
            gScreenBm.DrawLine(penGold, 0, 0, 0, pbScreen.Height);

            Point last = new Point(0, pbScreen.Height / 2);
            Point now = new Point(0, pbScreen.Height / 2);
            int[] tempSamples = new int[widPro];
            int scrSamNum = (offset + pbScreen.Width) * widPro;

            for (int i = offset * widPro; (i < scrSamNum) && (i < wavFile.BlockNum);)
            {
                if ((i + widPro) > wavFile.BlockNum)
                    tempSamples = new int[wavFile.BlockNum - i];
                int tempLen = tempSamples.Length;
                for (int x = 0; x < tempLen; x++)
                {
                    tempSamples[x] = wavFile.WavSamples[i + x];
                    if ((i + x) % (wavFile.Sample / 10) == 0)
                        gScreenBm.DrawLine(penGold, (i + x) / widPro - offset, pbScreen.Height - 4,
                            (i + x) / widPro - offset, pbScreen.Height);//画刻度
                    if ((i + x) % (wavFile.Sample) == 0)
                        gScreenBm.DrawString(((i + x) / (wavFile.Sample)).ToString(), DefaultFont, 
                            Brushes.Gold, new Point((i + x) / widPro + 2 - offset, pbScreen.Height - 15));//秒数
                }//取出当前需要操作的采样点
                int sum = tempSamples.Sum();
                int min = tempSamples.Min();
                int max = tempSamples.Max();
                if (cbWave.Checked)
                {
                    Point start = new Point(i / widPro - offset, (pbScreen.Height / 2 - max / heiPro));
                    Point end = new Point(i / widPro - offset, (pbScreen.Height / 2 - min / heiPro));
                    gScreenBm.DrawLine(penBlack, start, end);
                }
                else
                {
                    now.X = i / widPro - offset;
                    now.Y = pbScreen.Height / 2 - sum / widPro / heiPro;
                    gScreenBm.DrawLine(penBlack, last, now);
                    last = now;
                }
                i += tempLen;
            }

            Graphics gScreen = pbScreen.CreateGraphics();
            Graphics gLocate = pbLocate.CreateGraphics();
            gScreen.DrawImage(mapScreen, 0, 0);
            gLocate.DrawImage(mapLocate, 0, 0);
            mapScreen.Dispose();
            mapScreen = null;
            mapLocate.Dispose();
            mapLocate = null;

        }


        //调整高度
        private void button1_Click(object sender, EventArgs e)
        {
            if (loadflag)
            {
                if (hPro > 1)
                {
                    hPro -= 1;
                    ShowWave();
                }
                else
                    MessageBox.Show("已到最大");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (loadflag)
            {
                hPro += 1;
                ShowWave();
            }
        }
        //调整宽度
        private void button3_Click(object sender, EventArgs e)
        {
            if (loadflag)
            {
                if (widPro > 10)
                {
                    widPro -= 10;
                    ShowWave();
                }
                else if(widPro>1)
                {
                    widPro -= 1;
                    ShowWave();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (loadflag)
            {
                widPro += 1;
                ShowWave();
            }
        }
        //鼠标拖动
        private void pbScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (loadflag)
            {
                begin = e.X;
            }
        }
        private void pbScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (loadflag)
            {
                finish = e.X;
                offset += begin - finish;
                ShowWave();
            }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            if (loadflag)
            {
                hPro = 1;
                widPro = wavFile.BlockNum / pbScreen.Width;
                offlag = true;

                ShowWave();
            }
        }

        private void cbWave_CheckedChanged(object sender, EventArgs e)
        {
            if (loadflag)
            {
                ShowWave();
            }
        }
        //调整大小
        private void Form1_Resize(object sender, EventArgs e)
        {
            pbLocate.Width = this.Width - 40;
            pbScreen.Width = this.Width - 40;
            pbScreen.Height = this.Height - 184;
            if (loadflag)
                ShowWave();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(fileName);
            player.Play();
        }
        // 拖动信息条
        private bool moveflag = false;
        private void pbLocate_MouseDown(object sender, MouseEventArgs e)
        {
            // e.X 在框里
            if (loadflag && (e.X >= (pbScreen.Width * offset * widPro) / wavFile.BlockNum) && e.X <= ((pbScreen.Width * offset * widPro)) / wavFile.BlockNum + pbScreen.Width * pbScreen.Width / (wavFile.BlockNum / widPro))
            {

                begin = e.X;
            }
        }
        private void pbLocate_MouseUp(object sender, MouseEventArgs e)
        {
            if (loadflag)
            {
                finish = e.X;
                float bili = (wavFile.BlockNum / widPro) / pbScreen.Width;
                offset += Convert.ToInt32((finish - begin) * bili);
                ShowWave();
            }
        }

        private void pbLocate_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}