using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MNISTNeuralNetwork;

namespace NNForms
{
    public partial class output : Form
    {
        public output()
        {
            InitializeComponent();
        }

        Graphics g, h;
        Bitmap m;
        int Zaehler = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.rate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rate.Minimum = 0.01m;
            this.rate.Maximum = 0.99m;
            this.rate.Increment = 0.05m;
            this.rate.Value = 0.20m;

            ResetDrawing();
        }

        //Trainfile auswählen
        private void trainbutton_Click(object sender, EventArgs e)
        {
            if (trainfiled.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                trainfile.Text = trainfiled.FileName;
            }
        }
        
        //Testfile auswählen
        private void testfilebutton_Click(object sender, EventArgs e)
        {
            if (testfiled.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                testfile.Text = testfiled.FileName;
            }
        }

        //Trainieren und Testen mit ausgewählten Dateien
        private void train_Click(object sender, EventArgs e)
        {
            o.Text = run_cmd("C:\\Users\\Solidify\\Desktop\\test.py", 
                new string[] {"train", trainfile.Text, testfile.Text, hidden.Value + "", ep.Value + "",
                    rate.Value.ToString().Replace(",", ".") + "" });
        }


        // Startet Python Programm mit args Argumenten
        // Liefert Ausgabe des Python Programms als string zurück
        public static string run_cmd(string cmd, string[] args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\Solidify\\AppData\\Local\\Programs\\Python\\Python37-32\\python.exe"; //für Surface Benutzer = Solidify und Python37-32 

            string a = "";
            foreach (string s in args)
            {
                a = a + "\"" + s + "\" ";
            }

            start.Arguments = string.Format("\"{0}\" {1}", cmd, a);
            start.UseShellExecute = false;
            start.CreateNoWindow = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd();
                    string result = reader.ReadToEnd();
                    return result + stderr;
                }
            }
        }

        // Python mit gezeichnetem Bild als Argument aufrufen
        private void button1_Click(object sender, EventArgs e) 
        {
            string result = SerializeDrawing(false);
            r.Text = "";
            r.Text = run_cmd("C:\\Users\\Solidify\\Desktop\\test.py", new string[] {"testdrawing", result, hidden.Value + "", rate.Value.ToString().Replace(",", ".") + "" });
            MessageBox.Show(result);
        }

        // Gezeichnete Bitmap an File(out.csv) anhängen
        private void add_Click(object sender, EventArgs e)
        {
            string result = SerializeDrawing(true);
            File.AppendAllText("out.csv", result + "\n");
            Zaehler++;
            label7.Text = Convert.ToString(Zaehler);
        }

        // Zeichnerei
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                g.FillEllipse(Brushes.Black, e.X - 5, e.Y - 5, 8, 8);
                h.FillEllipse(Brushes.Black, e.X - 5, e.Y - 5, 8, 8);
            }
        }

        // Bitmap zu String
        private string SerializeDrawing(bool lb)
        {
           /* int[] i = new int[28 * 28];
            int l = 0;
            for (int x = 1; x < 84; x += 3)
            {
                for (int y = 1; y < 84; y += 3)
                {
                    double d = 0;
                    for (int a = x - 1; a <= x + 1; a++)
                    {
                        for (int b = y - 1; b <= y + 1; b++)
                        {
                            d += m.GetPixel(b, a).R;
                        }
                    }
                    d = 255 - (d / 9.0);
                    i[l] = Convert.ToInt32(Math.Round(d, 0));
                    l++;
                }
            }
            */
            int[] i = Helper.ConvertBitmap(m);
            
            ResetDrawing();

            string result = lb ? lable.Value + "," : "";

            for (int x = 0; x < i.Length; x++)
            {
                if (x == i.Length - 1)
                {
                    result += i[x];
                }
                else
                {
                    result += i[x] + ",";
                }
            }
            return result;
        }

        private void ResetDrawing()
        {
            m = new Bitmap(84, 84);
            g = Graphics.FromImage(m);
            h = panel1.CreateGraphics();
            g.Clear(Color.White);
            h.Clear(Color.White);
        }


    }
}
