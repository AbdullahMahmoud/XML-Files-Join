namespace Files_join
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
            this.Upload_Btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Inner_Join_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Number_of_file = new System.Windows.Forms.TextBox();
            this.PrimaryLabel = new System.Windows.Forms.Label();
            this.ForeignLable = new System.Windows.Forms.Label();
            this.Primarytxt = new System.Windows.Forms.TextBox();
            this.Foreigntxt = new System.Windows.Forms.TextBox();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.DeleteTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Valuetxt = new System.Windows.Forms.TextBox();
            this.ColumnNametxt = new System.Windows.Forms.TextBox();
            this.SetConbtn = new System.Windows.Forms.Button();
            this.LeftJoin = new System.Windows.Forms.Button();
            this.RighJoin = new System.Windows.Forms.Button();
            this.FullJoinbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload_Btn
            // 
            this.Upload_Btn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Upload_Btn.Location = new System.Drawing.Point(417, 652);
            this.Upload_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Upload_Btn.Name = "Upload_Btn";
            this.Upload_Btn.Size = new System.Drawing.Size(136, 37);
            this.Upload_Btn.TabIndex = 0;
            this.Upload_Btn.Text = "Upload";
            this.Upload_Btn.UseVisualStyleBackColor = false;
            this.Upload_Btn.Click += new System.EventHandler(this.Upload_Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Xml Files only| *.xml";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(557, 317);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1353, 369);
            this.dataGridView1.TabIndex = 1;
            // 
            // Inner_Join_Btn
            // 
            this.Inner_Join_Btn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Inner_Join_Btn.Location = new System.Drawing.Point(415, 320);
            this.Inner_Join_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Inner_Join_Btn.Name = "Inner_Join_Btn";
            this.Inner_Join_Btn.Size = new System.Drawing.Size(136, 43);
            this.Inner_Join_Btn.TabIndex = 2;
            this.Inner_Join_Btn.Text = "Inner Join";
            this.Inner_Join_Btn.UseVisualStyleBackColor = false;
            this.Inner_Join_Btn.Click += new System.EventHandler(this.Inner_Join_Btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(1807, 695);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = ">>>||";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(1520, 695);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = ">>>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Location = new System.Drawing.Point(864, 692);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "<<<";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Location = new System.Drawing.Point(557, 692);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "<<<||";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Number_of_file
            // 
            this.Number_of_file.Location = new System.Drawing.Point(1917, 317);
            this.Number_of_file.Margin = new System.Windows.Forms.Padding(4);
            this.Number_of_file.Name = "Number_of_file";
            this.Number_of_file.Size = new System.Drawing.Size(40, 22);
            this.Number_of_file.TabIndex = 7;
            // 
            // PrimaryLabel
            // 
            this.PrimaryLabel.AutoSize = true;
            this.PrimaryLabel.Location = new System.Drawing.Point(151, 638);
            this.PrimaryLabel.Name = "PrimaryLabel";
            this.PrimaryLabel.Size = new System.Drawing.Size(84, 17);
            this.PrimaryLabel.TabIndex = 8;
            this.PrimaryLabel.Text = "Primary Key";
            this.PrimaryLabel.Visible = false;
            // 
            // ForeignLable
            // 
            this.ForeignLable.AutoSize = true;
            this.ForeignLable.Location = new System.Drawing.Point(151, 672);
            this.ForeignLable.Name = "ForeignLable";
            this.ForeignLable.Size = new System.Drawing.Size(84, 17);
            this.ForeignLable.TabIndex = 9;
            this.ForeignLable.Text = "Foreign Key";
            this.ForeignLable.Visible = false;
            // 
            // Primarytxt
            // 
            this.Primarytxt.Location = new System.Drawing.Point(241, 635);
            this.Primarytxt.Name = "Primarytxt";
            this.Primarytxt.Size = new System.Drawing.Size(171, 22);
            this.Primarytxt.TabIndex = 10;
            this.Primarytxt.Visible = false;
            // 
            // Foreigntxt
            // 
            this.Foreigntxt.Location = new System.Drawing.Point(241, 669);
            this.Foreigntxt.Name = "Foreigntxt";
            this.Foreigntxt.Size = new System.Drawing.Size(171, 22);
            this.Foreigntxt.TabIndex = 11;
            this.Foreigntxt.Visible = false;
            // 
            // Savebtn
            // 
            this.Savebtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Savebtn.Location = new System.Drawing.Point(415, 652);
            this.Savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(136, 37);
            this.Savebtn.TabIndex = 12;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = false;
            this.Savebtn.Visible = false;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Deletebtn.Location = new System.Drawing.Point(261, 652);
            this.Deletebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(136, 37);
            this.Deletebtn.TabIndex = 13;
            this.Deletebtn.Text = "Delete All";
            this.Deletebtn.UseVisualStyleBackColor = false;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // DeleteTable
            // 
            this.DeleteTable.BackColor = System.Drawing.SystemColors.HotTrack;
            this.DeleteTable.Location = new System.Drawing.Point(1199, 695);
            this.DeleteTable.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteTable.Name = "DeleteTable";
            this.DeleteTable.Size = new System.Drawing.Size(103, 28);
            this.DeleteTable.TabIndex = 14;
            this.DeleteTable.Text = "Delete ";
            this.DeleteTable.UseVisualStyleBackColor = false;
            this.DeleteTable.Click += new System.EventHandler(this.DeleteTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 593);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Where";
            // 
            // Valuetxt
            // 
            this.Valuetxt.Location = new System.Drawing.Point(342, 591);
            this.Valuetxt.Name = "Valuetxt";
            this.Valuetxt.Size = new System.Drawing.Size(103, 22);
            this.Valuetxt.TabIndex = 17;
            // 
            // ColumnNametxt
            // 
            this.ColumnNametxt.Location = new System.Drawing.Point(132, 593);
            this.ColumnNametxt.Name = "ColumnNametxt";
            this.ColumnNametxt.Size = new System.Drawing.Size(185, 22);
            this.ColumnNametxt.TabIndex = 18;
            // 
            // SetConbtn
            // 
            this.SetConbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SetConbtn.Location = new System.Drawing.Point(448, 583);
            this.SetConbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetConbtn.Name = "SetConbtn";
            this.SetConbtn.Size = new System.Drawing.Size(105, 37);
            this.SetConbtn.TabIndex = 19;
            this.SetConbtn.Text = "Set condition";
            this.SetConbtn.UseVisualStyleBackColor = false;
            this.SetConbtn.Click += new System.EventHandler(this.SetConbtn_Click);
            // 
            // LeftJoin
            // 
            this.LeftJoin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LeftJoin.Location = new System.Drawing.Point(415, 389);
            this.LeftJoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftJoin.Name = "LeftJoin";
            this.LeftJoin.Size = new System.Drawing.Size(136, 43);
            this.LeftJoin.TabIndex = 20;
            this.LeftJoin.Text = "Left Join";
            this.LeftJoin.UseVisualStyleBackColor = false;
            this.LeftJoin.Click += new System.EventHandler(this.LeftJoin_Click);
            // 
            // RighJoin
            // 
            this.RighJoin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RighJoin.Location = new System.Drawing.Point(415, 459);
            this.RighJoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RighJoin.Name = "RighJoin";
            this.RighJoin.Size = new System.Drawing.Size(136, 43);
            this.RighJoin.TabIndex = 21;
            this.RighJoin.Text = "Right Join";
            this.RighJoin.UseVisualStyleBackColor = false;
            this.RighJoin.Click += new System.EventHandler(this.RightJoin_Click);
            // 
            // FullJoinbtn
            // 
            this.FullJoinbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.FullJoinbtn.Location = new System.Drawing.Point(415, 518);
            this.FullJoinbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FullJoinbtn.Name = "FullJoinbtn";
            this.FullJoinbtn.Size = new System.Drawing.Size(136, 43);
            this.FullJoinbtn.TabIndex = 22;
            this.FullJoinbtn.Text = "Full Join";
            this.FullJoinbtn.UseVisualStyleBackColor = false;
            this.FullJoinbtn.Click += new System.EventHandler(this.FullJoinbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::Files_join.Properties.Resources._433100;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.FullJoinbtn);
            this.Controls.Add(this.RighJoin);
            this.Controls.Add(this.LeftJoin);
            this.Controls.Add(this.SetConbtn);
            this.Controls.Add(this.ColumnNametxt);
            this.Controls.Add(this.Valuetxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteTable);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Foreigntxt);
            this.Controls.Add(this.Primarytxt);
            this.Controls.Add(this.ForeignLable);
            this.Controls.Add(this.PrimaryLabel);
            this.Controls.Add(this.Number_of_file);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Inner_Join_Btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Upload_Btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button Upload_Btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Inner_Join_Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Number_of_file;
        private System.Windows.Forms.Label PrimaryLabel;
        private System.Windows.Forms.Label ForeignLable;
        private System.Windows.Forms.TextBox Primarytxt;
        private System.Windows.Forms.TextBox Foreigntxt;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button DeleteTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Valuetxt;
        private System.Windows.Forms.TextBox ColumnNametxt;
        private System.Windows.Forms.Button SetConbtn;
        private System.Windows.Forms.Button LeftJoin;
        private System.Windows.Forms.Button RighJoin;
        private System.Windows.Forms.Button FullJoinbtn;
    }
}

