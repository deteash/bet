namespace bets
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
            this.buttonBet = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.numericBets = new System.Windows.Forms.NumericUpDown();
            this.numericHoursTo = new System.Windows.Forms.NumericUpDown();
            this.numericReadLines = new System.Windows.Forms.NumericUpDown();
            this.numericBetTimes = new System.Windows.Forms.NumericUpDown();
            this.labelrakeavg = new System.Windows.Forms.Label();
            this.labelrake = new System.Windows.Forms.Label();
            this.radioButtonDanilich = new System.Windows.Forms.RadioButton();
            this.radioButtonNaverochku = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonOrdinary = new System.Windows.Forms.RadioButton();
            this.checkBoxNoDraw = new System.Windows.Forms.CheckBox();
            this.checkBoxFreshLine = new System.Windows.Forms.CheckBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.numericHoursFrom = new System.Windows.Forms.NumericUpDown();
            this.infoWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelWorstRoi = new System.Windows.Forms.Label();
            this.labelPlusovie = new System.Windows.Forms.Label();
            this.labelBestRoi = new System.Windows.Forms.Label();
            this.labelwins = new System.Windows.Forms.Label();
            this.labelBets = new System.Windows.Forms.Label();
            this.tend = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxCoeffMore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCoefDiff = new System.Windows.Forms.Label();
            this.tabControlDanilo = new System.Windows.Forms.TabControl();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonGO = new System.Windows.Forms.Button();
            this.buttonAutotest = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBetTimes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursFrom)).BeginInit();
            this.infoWindow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControlDanilo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 35);
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
            this.label1.Location = new System.Drawing.Point(429, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "кол-во ставок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "часов до события";
            // 
            // labelroi
            // 
            this.labelroi.AutoSize = true;
            this.labelroi.Location = new System.Drawing.Point(198, 142);
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
            this.labelroipers.Location = new System.Drawing.Point(222, 134);
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
            this.checkedListBox1.Location = new System.Drawing.Point(375, 58);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(64, 45);
            this.checkedListBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Location = new System.Drawing.Point(48, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "0 событий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "0 линий";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "считать строк:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "готово";
            this.label8.Visible = false;
            // 
            // buttonBet
            // 
            this.buttonBet.Location = new System.Drawing.Point(187, 52);
            this.buttonBet.Name = "buttonBet";
            this.buttonBet.Size = new System.Drawing.Size(105, 55);
            this.buttonBet.TabIndex = 14;
            this.buttonBet.Text = "BET";
            this.buttonBet.UseVisualStyleBackColor = true;
            this.buttonBet.Click += new System.EventHandler(this.button2_Click);
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
            this.progressBar1.Location = new System.Drawing.Point(122, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(245, 23);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(440, 58);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAll.TabIndex = 20;
            this.checkBoxAll.Text = "больше ставок";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // numericBets
            // 
            this.numericBets.Location = new System.Drawing.Point(373, 6);
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
            // numericHoursTo
            // 
            this.numericHoursTo.Location = new System.Drawing.Point(412, 32);
            this.numericHoursTo.Name = "numericHoursTo";
            this.numericHoursTo.Size = new System.Drawing.Size(31, 20);
            this.numericHoursTo.TabIndex = 22;
            this.numericHoursTo.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // numericReadLines
            // 
            this.numericReadLines.Location = new System.Drawing.Point(38, 64);
            this.numericReadLines.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericReadLines.Name = "numericReadLines";
            this.numericReadLines.Size = new System.Drawing.Size(78, 20);
            this.numericReadLines.TabIndex = 23;
            // 
            // numericBetTimes
            // 
            this.numericBetTimes.Location = new System.Drawing.Point(217, 113);
            this.numericBetTimes.Name = "numericBetTimes";
            this.numericBetTimes.Size = new System.Drawing.Size(40, 20);
            this.numericBetTimes.TabIndex = 24;
            this.numericBetTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelrakeavg
            // 
            this.labelrakeavg.AutoSize = true;
            this.labelrakeavg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelrakeavg.Location = new System.Drawing.Point(245, 158);
            this.labelrakeavg.Name = "labelrakeavg";
            this.labelrakeavg.Size = new System.Drawing.Size(36, 24);
            this.labelrakeavg.TabIndex = 27;
            this.labelrakeavg.Text = "n/a";
            this.labelrakeavg.Visible = false;
            // 
            // labelrake
            // 
            this.labelrake.AutoSize = true;
            this.labelrake.Location = new System.Drawing.Point(180, 166);
            this.labelrake.Name = "labelrake";
            this.labelrake.Size = new System.Drawing.Size(59, 13);
            this.labelrake.TabIndex = 26;
            this.labelrake.Text = "margin avg";
            this.labelrake.Visible = false;
            // 
            // radioButtonDanilich
            // 
            this.radioButtonDanilich.AutoSize = true;
            this.radioButtonDanilich.Location = new System.Drawing.Point(6, 20);
            this.radioButtonDanilich.Name = "radioButtonDanilich";
            this.radioButtonDanilich.Size = new System.Drawing.Size(98, 17);
            this.radioButtonDanilich.TabIndex = 31;
            this.radioButtonDanilich.TabStop = true;
            this.radioButtonDanilich.Text = "Даныло стайл";
            this.radioButtonDanilich.UseVisualStyleBackColor = true;
            this.radioButtonDanilich.CheckedChanged += new System.EventHandler(this.radioButtonDanilich_CheckedChanged);
            // 
            // radioButtonNaverochku
            // 
            this.radioButtonNaverochku.AutoSize = true;
            this.radioButtonNaverochku.Location = new System.Drawing.Point(6, 41);
            this.radioButtonNaverochku.Name = "radioButtonNaverochku";
            this.radioButtonNaverochku.Size = new System.Drawing.Size(79, 17);
            this.radioButtonNaverochku.TabIndex = 32;
            this.radioButtonNaverochku.TabStop = true;
            this.radioButtonNaverochku.Text = "Наверочку";
            this.radioButtonNaverochku.UseVisualStyleBackColor = true;
            this.radioButtonNaverochku.CheckedChanged += new System.EventHandler(this.radioButtonNaverochku_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonOrdinary);
            this.groupBox1.Controls.Add(this.radioButtonDanilich);
            this.groupBox1.Controls.Add(this.radioButtonNaverochku);
            this.groupBox1.Location = new System.Drawing.Point(375, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 87);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ракомод";
            // 
            // radioButtonOrdinary
            // 
            this.radioButtonOrdinary.AutoSize = true;
            this.radioButtonOrdinary.Location = new System.Drawing.Point(6, 62);
            this.radioButtonOrdinary.Name = "radioButtonOrdinary";
            this.radioButtonOrdinary.Size = new System.Drawing.Size(62, 17);
            this.radioButtonOrdinary.TabIndex = 33;
            this.radioButtonOrdinary.TabStop = true;
            this.radioButtonOrdinary.Text = "обычно";
            this.radioButtonOrdinary.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoDraw
            // 
            this.checkBoxNoDraw.AutoSize = true;
            this.checkBoxNoDraw.Location = new System.Drawing.Point(440, 74);
            this.checkBoxNoDraw.Name = "checkBoxNoDraw";
            this.checkBoxNoDraw.Size = new System.Drawing.Size(81, 17);
            this.checkBoxNoDraw.TabIndex = 34;
            this.checkBoxNoDraw.Text = "без ничьих";
            this.checkBoxNoDraw.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreshLine
            // 
            this.checkBoxFreshLine.AutoSize = true;
            this.checkBoxFreshLine.Location = new System.Drawing.Point(440, 90);
            this.checkBoxFreshLine.Name = "checkBoxFreshLine";
            this.checkBoxFreshLine.Size = new System.Drawing.Size(97, 17);
            this.checkBoxFreshLine.TabIndex = 35;
            this.checkBoxFreshLine.Text = "свежие линии";
            this.checkBoxFreshLine.UseVisualStyleBackColor = true;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(484, 177);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(58, 22);
            this.buttonInfo.TabIndex = 36;
            this.buttonInfo.Text = "info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // numericHoursFrom
            // 
            this.numericHoursFrom.Location = new System.Drawing.Point(373, 32);
            this.numericHoursFrom.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numericHoursFrom.Name = "numericHoursFrom";
            this.numericHoursFrom.Size = new System.Drawing.Size(33, 20);
            this.numericHoursFrom.TabIndex = 37;
            // 
            // infoWindow
            // 
            this.infoWindow.Controls.Add(this.tabPage1);
            this.infoWindow.Controls.Add(this.tend);
            this.infoWindow.Location = new System.Drawing.Point(-3, 227);
            this.infoWindow.Name = "infoWindow";
            this.infoWindow.SelectedIndex = 0;
            this.infoWindow.Size = new System.Drawing.Size(184, 158);
            this.infoWindow.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelWorstRoi);
            this.tabPage1.Controls.Add(this.labelPlusovie);
            this.tabPage1.Controls.Add(this.labelBestRoi);
            this.tabPage1.Controls.Add(this.labelwins);
            this.tabPage1.Controls.Add(this.labelBets);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(176, 132);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelWorstRoi
            // 
            this.labelWorstRoi.AutoSize = true;
            this.labelWorstRoi.Location = new System.Drawing.Point(15, 80);
            this.labelWorstRoi.Name = "labelWorstRoi";
            this.labelWorstRoi.Size = new System.Drawing.Size(53, 13);
            this.labelWorstRoi.TabIndex = 23;
            this.labelWorstRoi.Text = "получено";
            // 
            // labelPlusovie
            // 
            this.labelPlusovie.AutoSize = true;
            this.labelPlusovie.Location = new System.Drawing.Point(15, 49);
            this.labelPlusovie.Name = "labelPlusovie";
            this.labelPlusovie.Size = new System.Drawing.Size(53, 13);
            this.labelPlusovie.TabIndex = 22;
            this.labelPlusovie.Text = "получено";
            // 
            // labelBestRoi
            // 
            this.labelBestRoi.AutoSize = true;
            this.labelBestRoi.Location = new System.Drawing.Point(15, 65);
            this.labelBestRoi.Name = "labelBestRoi";
            this.labelBestRoi.Size = new System.Drawing.Size(53, 13);
            this.labelBestRoi.TabIndex = 21;
            this.labelBestRoi.Text = "получено";
            // 
            // labelwins
            // 
            this.labelwins.AutoSize = true;
            this.labelwins.Location = new System.Drawing.Point(15, 31);
            this.labelwins.Name = "labelwins";
            this.labelwins.Size = new System.Drawing.Size(53, 13);
            this.labelwins.TabIndex = 20;
            this.labelwins.Text = "получено";
            // 
            // labelBets
            // 
            this.labelBets.AutoSize = true;
            this.labelBets.Location = new System.Drawing.Point(15, 14);
            this.labelBets.Name = "labelBets";
            this.labelBets.Size = new System.Drawing.Size(66, 13);
            this.labelBets.TabIndex = 19;
            this.labelBets.Text = "поставлено";
            // 
            // tend
            // 
            this.tend.Location = new System.Drawing.Point(4, 22);
            this.tend.Name = "tend";
            this.tend.Padding = new System.Windows.Forms.Padding(3);
            this.tend.Size = new System.Drawing.Size(176, 132);
            this.tend.TabIndex = 1;
            this.tend.Text = "Trend";
            this.tend.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 48);
            this.button2.TabIndex = 39;
            this.button2.Text = "Супа Данило";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBoxCoeffMore);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelCoefDiff);
            this.tabPage2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(156, 132);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Настрой Ебашителя";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 20);
            this.textBox3.TabIndex = 47;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 46;
            // 
            // textBoxCoeffMore
            // 
            this.textBoxCoeffMore.Location = new System.Drawing.Point(112, 22);
            this.textBoxCoeffMore.Name = "textBoxCoeffMore";
            this.textBoxCoeffMore.Size = new System.Drawing.Size(40, 20);
            this.textBoxCoeffMore.TabIndex = 45;
            this.textBoxCoeffMore.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "< маржа < ";
            // 
            // labelCoefDiff
            // 
            this.labelCoefDiff.AutoSize = true;
            this.labelCoefDiff.Location = new System.Drawing.Point(11, 24);
            this.labelCoefDiff.Name = "labelCoefDiff";
            this.labelCoefDiff.Size = new System.Drawing.Size(100, 13);
            this.labelCoefDiff.TabIndex = 41;
            this.labelCoefDiff.Text = "ставим если кф > ";
            // 
            // tabControlDanilo
            // 
            this.tabControlDanilo.Controls.Add(this.tabPage2);
            this.tabControlDanilo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tabControlDanilo.Location = new System.Drawing.Point(373, 227);
            this.tabControlDanilo.Name = "tabControlDanilo";
            this.tabControlDanilo.SelectedIndex = 0;
            this.tabControlDanilo.Size = new System.Drawing.Size(164, 158);
            this.tabControlDanilo.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(198, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "x";
            // 
            // buttonGO
            // 
            this.buttonGO.Location = new System.Drawing.Point(38, 90);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(78, 25);
            this.buttonGO.TabIndex = 42;
            this.buttonGO.Text = "GO";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAutotest
            // 
            this.buttonAutotest.Location = new System.Drawing.Point(38, 121);
            this.buttonAutotest.Name = "buttonAutotest";
            this.buttonAutotest.Size = new System.Drawing.Size(77, 24);
            this.buttonAutotest.TabIndex = 43;
            this.buttonAutotest.Text = "autotest";
            this.buttonAutotest.UseVisualStyleBackColor = true;
            this.buttonAutotest.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(287, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 44;
            this.button5.Text = "add marks";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(355, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 48;
            this.textBox1.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 644);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonAutotest);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tabControlDanilo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.infoWindow);
            this.Controls.Add(this.numericHoursFrom);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.checkBoxFreshLine);
            this.Controls.Add(this.checkBoxNoDraw);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelrakeavg);
            this.Controls.Add(this.labelrake);
            this.Controls.Add(this.numericBetTimes);
            this.Controls.Add(this.numericReadLines);
            this.Controls.Add(this.numericHoursTo);
            this.Controls.Add(this.numericBets);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonBet);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReadLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBetTimes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursFrom)).EndInit();
            this.infoWindow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControlDanilo.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonBet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
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
        private System.Windows.Forms.NumericUpDown numericHoursTo;
        private System.Windows.Forms.NumericUpDown numericReadLines;
        private System.Windows.Forms.NumericUpDown numericBetTimes;
        private System.Windows.Forms.Label labelrakeavg;
        private System.Windows.Forms.Label labelrake;
        private System.Windows.Forms.RadioButton radioButtonDanilich;
        private System.Windows.Forms.RadioButton radioButtonNaverochku;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonOrdinary;
        private System.Windows.Forms.CheckBox checkBoxNoDraw;
        private System.Windows.Forms.CheckBox checkBoxFreshLine;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.NumericUpDown numericHoursFrom;
        private System.Windows.Forms.TabControl infoWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelBets;
        private System.Windows.Forms.TabPage tend;
        private System.Windows.Forms.Label labelwins;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControlDanilo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCoefDiff;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelWorstRoi;
        private System.Windows.Forms.Label labelPlusovie;
        private System.Windows.Forms.Label labelBestRoi;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxCoeffMore;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.Button buttonAutotest;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
    }
}

