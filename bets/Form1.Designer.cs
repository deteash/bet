﻿namespace bets
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelroi = new System.Windows.Forms.Label();
            this.labelroipers = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Team1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coeff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelwins = new System.Windows.Forms.Label();
            this.labelbets = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.numericBets = new System.Windows.Forms.NumericUpDown();
            this.numericHours = new System.Windows.Forms.NumericUpDown();
            this.numericReadLines = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadLines)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "заебашить пинакл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "кол-во ставок";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "часов до события";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelroi
            // 
            this.labelroi.AutoSize = true;
            this.labelroi.Location = new System.Drawing.Point(221, 128);
            this.labelroi.Name = "labelroi";
            this.labelroi.Size = new System.Drawing.Size(18, 13);
            this.labelroi.TabIndex = 5;
            this.labelroi.Text = "roi";
            this.labelroi.Visible = false;
            // 
            // labelroipers
            // 
            this.labelroipers.AutoSize = true;
            this.labelroipers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelroipers.Location = new System.Drawing.Point(245, 121);
            this.labelroipers.Name = "labelroipers";
            this.labelroipers.Size = new System.Drawing.Size(36, 24);
            this.labelroipers.TabIndex = 6;
            this.labelroipers.Text = "n/a";
            this.labelroipers.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "П1,П2,X",
            "Фора",
            "Тотал"});
            this.checkedListBox1.Location = new System.Drawing.Point(337, 85);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(64, 45);
            this.checkedListBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Location = new System.Drawing.Point(48, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "0 событий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "0 линий";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "считать строк:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "готово";
            this.label8.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 14;
            this.button2.Text = "BET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Team1,
            this.Team2,
            this.Result,
            this.t2,
            this.Bet,
            this.Column1,
            this.Coeff,
            this.Win,
            this.add});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(545, 381);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.Tag = "bets";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Team1
            // 
            this.Team1.HeaderText = "Team1";
            this.Team1.Name = "Team1";
            this.Team1.ReadOnly = true;
            this.Team1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Team1.Width = 120;
            // 
            // Team2
            // 
            this.Team2.HeaderText = "Team2";
            this.Team2.Name = "Team2";
            this.Team2.ReadOnly = true;
            this.Team2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Team2.Width = 120;
            // 
            // Result
            // 
            this.Result.HeaderText = "t1";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Result.Width = 20;
            // 
            // t2
            // 
            this.t2.HeaderText = "t2";
            this.t2.Name = "t2";
            this.t2.ReadOnly = true;
            this.t2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.t2.Width = 20;
            // 
            // Bet
            // 
            this.Bet.HeaderText = "Bet";
            this.Bet.Name = "Bet";
            this.Bet.ReadOnly = true;
            this.Bet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bet.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 50;
            // 
            // Coeff
            // 
            this.Coeff.HeaderText = "Coeff";
            this.Coeff.Name = "Coeff";
            this.Coeff.ReadOnly = true;
            this.Coeff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Coeff.Width = 40;
            // 
            // Win
            // 
            this.Win.HeaderText = "Win";
            this.Win.Name = "Win";
            this.Win.ReadOnly = true;
            this.Win.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Win.Width = 30;
            // 
            // add
            // 
            this.add.HeaderText = "+win";
            this.add.Name = "add";
            this.add.ReadOnly = true;
            this.add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.add.Width = 45;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(29, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(101, 23);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // labelwins
            // 
            this.labelwins.AutoSize = true;
            this.labelwins.Location = new System.Drawing.Point(221, 98);
            this.labelwins.Name = "labelwins";
            this.labelwins.Size = new System.Drawing.Size(55, 13);
            this.labelwins.TabIndex = 17;
            this.labelwins.Text = "проебано";
            this.labelwins.Visible = false;
            // 
            // labelbets
            // 
            this.labelbets.AutoSize = true;
            this.labelbets.Location = new System.Drawing.Point(222, 78);
            this.labelbets.Name = "labelbets";
            this.labelbets.Size = new System.Drawing.Size(66, 13);
            this.labelbets.TabIndex = 18;
            this.labelbets.Text = "поставлено";
            this.labelbets.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(337, 170);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(59, 17);
            this.checkBoxAll.TabIndex = 20;
            this.checkBoxAll.Text = "на все";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // numericBets
            // 
            this.numericBets.Location = new System.Drawing.Point(309, 23);
            this.numericBets.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numericBets.Name = "numericBets";
            this.numericBets.Size = new System.Drawing.Size(48, 20);
            this.numericBets.TabIndex = 21;
            this.numericBets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericHours
            // 
            this.numericHours.Location = new System.Drawing.Point(309, 55);
            this.numericHours.Name = "numericHours";
            this.numericHours.Size = new System.Drawing.Size(48, 20);
            this.numericHours.TabIndex = 22;
            this.numericHours.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericReadLines
            // 
            this.numericReadLines.Location = new System.Drawing.Point(29, 31);
            this.numericReadLines.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numericReadLines.Name = "numericReadLines";
            this.numericReadLines.Size = new System.Drawing.Size(101, 20);
            this.numericReadLines.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 644);
            this.Controls.Add(this.numericReadLines);
            this.Controls.Add(this.numericHours);
            this.Controls.Add(this.numericBets);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelbets);
            this.Controls.Add(this.labelwins);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelroipers);
            this.Controls.Add(this.labelroi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelroi;
        private System.Windows.Forms.Label labelroipers;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelwins;
        private System.Windows.Forms.Label labelbets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn t2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coeff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win;
        private System.Windows.Forms.DataGridViewTextBoxColumn add;
        private System.Windows.Forms.NumericUpDown numericBets;
        private System.Windows.Forms.NumericUpDown numericHours;
        private System.Windows.Forms.NumericUpDown numericReadLines;
    }
}
