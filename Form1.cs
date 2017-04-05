using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SOSC
{
    public partial class Form1 : Form
    {
        Level level;
        Graphics dc;
        Highscore hs;

        public Form1()
        {
            InitializeComponent();
            SetClientSizeCore(1000, 700);
            textBox1.Enabled = false;
            textBox1.Visible = false;

        }



        public void Form1_Load(object sender, EventArgs e)
        {
            dc = CreateGraphics();
            level = new Level(dc, this.DisplayRectangle);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            level.SetupLevel();

            Play.Enabled = false;
            Play.Visible = false;
            Exit.Enabled = false;
            Exit.Visible = false;
            Highscore.Enabled = false;
            Highscore.Visible = false;
            textBox1.Enabled = false;
            textBox1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            level.GameLoop(); 
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            hs = new Highscore();
            hs.SetupScore(level);
            Highscore.Enabled = false;
            Highscore.Visible = false;
            textBox1.Enabled = true;
            textBox1.Visible = true;

            StreamReader objstream = new StreamReader(@"Text_file.txt");

            textBox1.Text = objstream.ReadLine();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
