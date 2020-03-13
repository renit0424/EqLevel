using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EqLevel
{
    public partial class Form1 : Form
    {
        SoundPlayer Player = null;
        private void shindo(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound();
        }

        private void setSound()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/1.wav");
        }
        private void shindo1(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound1();
        }

        private void setSound1()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/2.wav");
        }
        private void shindo2(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound2();
        }

        private void setSound2()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/3.wav");
        }
        private void shindo3(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound3();
        }

        private void setSound3()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/4.wav");
        }
        private void shindo4(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound4();
        }

        private void setSound4()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/5.wav");
        }
        private void shindo5(object sender, EventArgs e)
        {
            //labelの文字が変わったら再生開始
            setSound5();
        }

        private void setSound5()
        {
            //ファイルの中のwavファイルを再生させる 
            PlaySound("Sound/6.wav");
        }
        private void PlaySound(string waveFile)
        {

            //読み込む
            Player = new SoundPlayer(waveFile);
            //非同期再生する
            Player.Play();
        }
        public Form1()
        {
            InitializeComponent();
            timer1.Start();


            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string json;
                using (var wc = new System.Net.WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    json = wc.DownloadString("http://kwatch-24h.net/EQLevel.json");
                }
                var jsonData = JsonConvert.DeserializeObject<Kyoshinjson>(json);
                string level = "Lv." + jsonData.l.ToString();
                int sll = jsonData.l;
                label2.Text = level;
                if (sll < 100)
                {
                    BackColor = Color.Black;
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                }
                if (sll > 100)
                {
                    BackColor = Color.DodgerBlue;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    setSound();
                }
                if (sll > 500)
                {
                    BackColor = Color.Gold;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    setSound1();
                }
                if (sll > 1000)
                {
                    BackColor = Color.DarkOrange;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    setSound2();
                }
                if (sll > 1500)
                {
                    BackColor = Color.DarkOrange;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Yellow;
                    setSound3();
                }
                if (sll > 2000)
                {
                    BackColor = Color.Red;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Yellow;
                    setSound4();
                }
                if (sll > 2500)
                {
                    BackColor = Color.DarkOrchid;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Yellow;
                    setSound5();
                }
        }
            catch { }
        }
        public class Kyoshinjson
        {
            public int l { get; set; }
            public int g { get; set; }
            public int y { get; set; }
            public int r { get; set; }
            public string t { get; set; }
            public int e { get; set; }
        }

    }
}

