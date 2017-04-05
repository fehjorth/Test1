namespace SOSC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Play = new System.Windows.Forms.Button();
            this.Highscore = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.DarkRed;
            this.Play.Location = new System.Drawing.Point(331, 37);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(260, 62);
            this.Play.TabIndex = 0;
            this.Play.Text = "Start Game";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.button1_Click);
            // 
            // Highscore
            // 
            this.Highscore.BackColor = System.Drawing.Color.DarkRed;
            this.Highscore.Location = new System.Drawing.Point(331, 207);
            this.Highscore.Name = "Highscore";
            this.Highscore.Size = new System.Drawing.Size(260, 69);
            this.Highscore.TabIndex = 1;
            this.Highscore.Text = "HighScore";
            this.Highscore.UseVisualStyleBackColor = false;
            this.Highscore.Click += new System.EventHandler(this.button2_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Location = new System.Drawing.Point(331, 405);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(260, 52);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(645, 232);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Highscore);
            this.Controls.Add(this.Play);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Highscore;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox textBox1;
    }
}

