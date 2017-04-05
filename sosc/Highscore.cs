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
    class Highscore
    {
        int score;
        public void SetupScore(Level score)
        {
            this.score = score.HighScore;
            
            using (StreamWriter File = new StreamWriter("Text_File.txt"))
            {
                File.Write(this.score);
                File.Close();
            }   
            
            
        }

    }
}
