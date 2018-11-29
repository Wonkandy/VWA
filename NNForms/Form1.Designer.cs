namespace NNForms
{
    partial class output
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.trainfiled = new System.Windows.Forms.OpenFileDialog();
            this.testfiled = new System.Windows.Forms.OpenFileDialog();
            this.trainfile = new System.Windows.Forms.TextBox();
            this.trainfilebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.testfilebutton = new System.Windows.Forms.Button();
            this.testfile = new System.Windows.Forms.TextBox();
            this.hidden = new System.Windows.Forms.NumericUpDown();
            this.ep = new System.Windows.Forms.NumericUpDown();
            this.rate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.o = new System.Windows.Forms.RichTextBox();
            this.traintest = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.test = new System.Windows.Forms.Button();
            this.r = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.lable = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lable)).BeginInit();
            this.SuspendLayout();
            // 
            // trainfiled
            // 
            this.trainfiled.FileName = "openFileDialog1";
            // 
            // testfiled
            // 
            this.testfiled.FileName = "openFileDialog1";
            // 
            // trainfile
            // 
            this.trainfile.Location = new System.Drawing.Point(12, 77);
            this.trainfile.Margin = new System.Windows.Forms.Padding(4);
            this.trainfile.Name = "trainfile";
            this.trainfile.ReadOnly = true;
            this.trainfile.Size = new System.Drawing.Size(694, 31);
            this.trainfile.TabIndex = 0;
            // 
            // trainfilebutton
            // 
            this.trainfilebutton.Location = new System.Drawing.Point(712, 77);
            this.trainfilebutton.Margin = new System.Windows.Forms.Padding(4);
            this.trainfilebutton.Name = "trainfilebutton";
            this.trainfilebutton.Size = new System.Drawing.Size(76, 42);
            this.trainfilebutton.TabIndex = 1;
            this.trainfilebutton.Text = "...";
            this.trainfilebutton.UseVisualStyleBackColor = true;
            this.trainfilebutton.Click += new System.EventHandler(this.trainbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Train File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test File";
            // 
            // testfilebutton
            // 
            this.testfilebutton.Location = new System.Drawing.Point(712, 146);
            this.testfilebutton.Margin = new System.Windows.Forms.Padding(4);
            this.testfilebutton.Name = "testfilebutton";
            this.testfilebutton.Size = new System.Drawing.Size(76, 44);
            this.testfilebutton.TabIndex = 4;
            this.testfilebutton.Text = "...";
            this.testfilebutton.UseVisualStyleBackColor = true;
            this.testfilebutton.Click += new System.EventHandler(this.testfilebutton_Click);
            // 
            // testfile
            // 
            this.testfile.Location = new System.Drawing.Point(12, 154);
            this.testfile.Margin = new System.Windows.Forms.Padding(4);
            this.testfile.Name = "testfile";
            this.testfile.ReadOnly = true;
            this.testfile.Size = new System.Drawing.Size(694, 31);
            this.testfile.TabIndex = 3;
            // 
            // hidden
            // 
            this.hidden.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hidden.Location = new System.Drawing.Point(236, 235);
            this.hidden.Margin = new System.Windows.Forms.Padding(4);
            this.hidden.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hidden.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hidden.Name = "hidden";
            this.hidden.Size = new System.Drawing.Size(120, 31);
            this.hidden.TabIndex = 6;
            this.hidden.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ep
            // 
            this.ep.Location = new System.Drawing.Point(236, 285);
            this.ep.Margin = new System.Windows.Forms.Padding(4);
            this.ep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ep.Name = "ep";
            this.ep.Size = new System.Drawing.Size(120, 31);
            this.ep.TabIndex = 7;
            this.ep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rate
            // 
            this.rate.DecimalPlaces = 2;
            this.rate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rate.Location = new System.Drawing.Point(236, 337);
            this.rate.Margin = new System.Windows.Forms.Padding(4);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(120, 31);
            this.rate.TabIndex = 8;
            this.rate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hidden Nodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 290);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Epochen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 342);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lernrate (0.01-0.99)";
            // 
            // o
            // 
            this.o.Location = new System.Drawing.Point(18, 394);
            this.o.Margin = new System.Windows.Forms.Padding(4);
            this.o.Name = "o";
            this.o.Size = new System.Drawing.Size(770, 292);
            this.o.TabIndex = 12;
            this.o.Text = "";
            // 
            // traintest
            // 
            this.traintest.Location = new System.Drawing.Point(532, 275);
            this.traintest.Margin = new System.Windows.Forms.Padding(4);
            this.traintest.Name = "traintest";
            this.traintest.Size = new System.Drawing.Size(150, 40);
            this.traintest.TabIndex = 13;
            this.traintest.Text = "Train-Test";
            this.traintest.UseVisualStyleBackColor = true;
            this.traintest.Click += new System.EventHandler(this.train_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(18, 700);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 160);
            this.panel1.TabIndex = 14;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(532, 329);
            this.test.Margin = new System.Windows.Forms.Padding(6);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(150, 44);
            this.test.TabIndex = 15;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.button1_Click);
            // 
            // r
            // 
            this.r.AutoSize = true;
            this.r.Location = new System.Drawing.Point(62, 867);
            this.r.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(0, 25);
            this.r.TabIndex = 16;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(308, 867);
            this.add.Margin = new System.Windows.Forms.Padding(4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(152, 44);
            this.add.TabIndex = 17;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // lable
            // 
            this.lable.Location = new System.Drawing.Point(196, 804);
            this.lable.Margin = new System.Windows.Forms.Padding(4);
            this.lable.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(150, 31);
            this.lable.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 738);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Geaddet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 738);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 25);
            this.label7.TabIndex = 20;
            // 
            // output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 988);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.add);
            this.Controls.Add(this.r);
            this.Controls.Add(this.test);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.traintest);
            this.Controls.Add(this.o);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.ep);
            this.Controls.Add(this.hidden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.testfilebutton);
            this.Controls.Add(this.testfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trainfilebutton);
            this.Controls.Add(this.trainfile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "output";
            this.Text = "NNForms";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog trainfiled;
        private System.Windows.Forms.OpenFileDialog testfiled;
        private System.Windows.Forms.TextBox trainfile;
        private System.Windows.Forms.Button trainfilebutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button testfilebutton;
        private System.Windows.Forms.TextBox testfile;
        private System.Windows.Forms.NumericUpDown hidden;
        private System.Windows.Forms.NumericUpDown ep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown rate;
        private System.Windows.Forms.RichTextBox o;
        private System.Windows.Forms.Button traintest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Label r;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.NumericUpDown lable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

