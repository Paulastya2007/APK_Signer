using APK_Signer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APK_Signer
{
    public partial class Form1 : Form
    {
        static string command1 = "keytool -genkeypair -alias key0 -keyalg RSA -keysize 2048 -keystore B:\\ss.jks -storepass amdry34 -validity 18250 -keypass amdry34 -dname \"C=91\"";
        StringBuilder sb = new StringBuilder(command1);
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = Settings.Default.JDK;
            ++k;
            panv(k);
        }
        int k = 0;
        void panv(int a)
        {
            if (k % 2 == 0)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Open the folder where the JDK is Located and select the bin folder";
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.JDK = folderBrowserDialog1.SelectedPath;
                Settings.Default.Save();
                label2.Text = Settings.Default.JDK;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Equals(""))) {
                if (!(location.Equals(""))) {
                    sb.Replace("B:\\ss.jks",location);
                    sb.Replace("amdry34",textBox1.Text);
                    string ass=sb.ToString();
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.WorkingDirectory = Settings.Default.JDK.ToString();
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.RedirectStandardError = true;

                    cmd.StartInfo.CreateNoWindow = false;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine(ass);
                    cmd.StandardInput.Flush();

                    cmd.StandardInput.WriteLine("exit");
            cmd.StandardInput.Flush();
                }
            }
        }
        static string location;
        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save JKS File";
            saveFileDialog1.Filter = "Keystore file (*.jks)|*.jks";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) { 
            location = saveFileDialog1.FileName;
            }
        }
    }
}

