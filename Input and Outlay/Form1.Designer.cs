using System.Windows.Forms;

namespace BelarusianDoor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_dayBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_moneyYesterdayEvening = new System.Windows.Forms.TextBox();
            this.btn_SaveInExcelFile = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Visitors = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_Summ = new System.Windows.Forms.Label();
            this.label_WhomGive = new System.Windows.Forms.Label();
            this.label_WhoReceive = new System.Windows.Forms.Label();
            this.btn_EditData = new System.Windows.Forms.Button();
            this.btn_deleteData = new System.Windows.Forms.Button();
            this.textBox_SummaOutlay = new System.Windows.Forms.TextBox();
            this.textBox_idOutlay = new System.Windows.Forms.TextBox();
            this.textBox_WhereMoneyGoes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_WhomeReceiveMoney = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_EditDataToOutlay = new System.Windows.Forms.Button();
            this.btn_deleteDataFromOutlay = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_summInputToday = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_summaOutlayToday = new System.Windows.Forms.TextBox();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.textBox_WhoGive1 = new System.Windows.Forms.TextBox();
            this.textBox_id1 = new System.Windows.Forms.TextBox();
            this.textBox_Summ1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_whoReceive1 = new System.Windows.Forms.ComboBox();
            this.btn_SaveDataToOutlayTable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_EditVisitors = new System.Windows.Forms.Button();
            this.btn_AddVisitors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(225, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "ВИТРАТИ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "dd mm yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(456, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 523);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Останок";
            // 
            // textBox_dayBalance
            // 
            this.textBox_dayBalance.Location = new System.Drawing.Point(156, 520);
            this.textBox_dayBalance.Name = "textBox_dayBalance";
            this.textBox_dayBalance.ReadOnly = true;
            this.textBox_dayBalance.Size = new System.Drawing.Size(100, 20);
            this.textBox_dayBalance.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "На ранок";
            // 
            // textBox_moneyYesterdayEvening
            // 
            this.textBox_moneyYesterdayEvening.Location = new System.Drawing.Point(156, 494);
            this.textBox_moneyYesterdayEvening.Name = "textBox_moneyYesterdayEvening";
            this.textBox_moneyYesterdayEvening.ReadOnly = true;
            this.textBox_moneyYesterdayEvening.Size = new System.Drawing.Size(100, 20);
            this.textBox_moneyYesterdayEvening.TabIndex = 16;
            // 
            // btn_SaveInExcelFile
            // 
            this.btn_SaveInExcelFile.Location = new System.Drawing.Point(947, 591);
            this.btn_SaveInExcelFile.Name = "btn_SaveInExcelFile";
            this.btn_SaveInExcelFile.Size = new System.Drawing.Size(137, 23);
            this.btn_SaveInExcelFile.TabIndex = 21;
            this.btn_SaveInExcelFile.Text = "Зберегти в Excel";
            this.btn_SaveInExcelFile.UseVisualStyleBackColor = true;
            this.btn_SaveInExcelFile.Click += new System.EventHandler(this.btn_SaveInExcelFile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 578);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Відвідувачі";
            // 
            // textBox_Visitors
            // 
            this.textBox_Visitors.Location = new System.Drawing.Point(156, 571);
            this.textBox_Visitors.Name = "textBox_Visitors";
            this.textBox_Visitors.Size = new System.Drawing.Size(100, 20);
            this.textBox_Visitors.TabIndex = 18;
            this.textBox_Visitors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Summ1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(90)))), ((int)(((byte)(66)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 152);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 266);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(90)))), ((int)(((byte)(66)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(3, 152);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(544, 266);
            this.dataGridView2.TabIndex = 23;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label_Summ
            // 
            this.label_Summ.AutoSize = true;
            this.label_Summ.Location = new System.Drawing.Point(6, 41);
            this.label_Summ.Name = "label_Summ";
            this.label_Summ.Size = new System.Drawing.Size(36, 13);
            this.label_Summ.TabIndex = 13;
            this.label_Summ.Text = "Сума:";
            // 
            // label_WhomGive
            // 
            this.label_WhomGive.AutoSize = true;
            this.label_WhomGive.Location = new System.Drawing.Point(110, 41);
            this.label_WhomGive.Name = "label_WhomGive";
            this.label_WhomGive.Size = new System.Drawing.Size(106, 13);
            this.label_WhomGive.TabIndex = 13;
            this.label_WhomGive.Text = "Від кого поступили:";
            // 
            // label_WhoReceive
            // 
            this.label_WhoReceive.AutoSize = true;
            this.label_WhoReceive.Location = new System.Drawing.Point(357, 44);
            this.label_WhoReceive.Name = "label_WhoReceive";
            this.label_WhoReceive.Size = new System.Drawing.Size(74, 13);
            this.label_WhoReceive.TabIndex = 13;
            this.label_WhoReceive.Text = "Хто отримав:";
            // 
            // btn_EditData
            // 
            this.btn_EditData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_EditData.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditData.ForeColor = System.Drawing.Color.Goldenrod;
            this.btn_EditData.Location = new System.Drawing.Point(113, 124);
            this.btn_EditData.Name = "btn_EditData";
            this.btn_EditData.Size = new System.Drawing.Size(100, 23);
            this.btn_EditData.TabIndex = 6;
            this.btn_EditData.Text = "Редагувати";
            this.btn_EditData.UseVisualStyleBackColor = false;
            this.btn_EditData.Click += new System.EventHandler(this.btn_EditData_Click);
            // 
            // btn_deleteData
            // 
            this.btn_deleteData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_deleteData.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deleteData.ForeColor = System.Drawing.Color.Crimson;
            this.btn_deleteData.Location = new System.Drawing.Point(219, 123);
            this.btn_deleteData.Name = "btn_deleteData";
            this.btn_deleteData.Size = new System.Drawing.Size(100, 23);
            this.btn_deleteData.TabIndex = 7;
            this.btn_deleteData.Text = "Видалити";
            this.btn_deleteData.UseVisualStyleBackColor = false;
            this.btn_deleteData.Click += new System.EventHandler(this.btn_deleteData_Click);
            // 
            // textBox_SummaOutlay
            // 
            this.textBox_SummaOutlay.Location = new System.Drawing.Point(6, 60);
            this.textBox_SummaOutlay.Name = "textBox_SummaOutlay";
            this.textBox_SummaOutlay.Size = new System.Drawing.Size(95, 20);
            this.textBox_SummaOutlay.TabIndex = 8;
            this.textBox_SummaOutlay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Summ1_KeyPress);
            // 
            // textBox_idOutlay
            // 
            this.textBox_idOutlay.Location = new System.Drawing.Point(513, 60);
            this.textBox_idOutlay.Name = "textBox_idOutlay";
            this.textBox_idOutlay.ReadOnly = true;
            this.textBox_idOutlay.Size = new System.Drawing.Size(24, 20);
            this.textBox_idOutlay.TabIndex = 23;
            // 
            // textBox_WhereMoneyGoes
            // 
            this.textBox_WhereMoneyGoes.Location = new System.Drawing.Point(107, 60);
            this.textBox_WhereMoneyGoes.Multiline = true;
            this.textBox_WhereMoneyGoes.Name = "textBox_WhereMoneyGoes";
            this.textBox_WhereMoneyGoes.Size = new System.Drawing.Size(200, 49);
            this.textBox_WhereMoneyGoes.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Сума:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(510, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Куди витрачено:";
            // 
            // textBox_WhomeReceiveMoney
            // 
            this.textBox_WhomeReceiveMoney.Location = new System.Drawing.Point(313, 60);
            this.textBox_WhomeReceiveMoney.Multiline = true;
            this.textBox_WhomeReceiveMoney.Name = "textBox_WhomeReceiveMoney";
            this.textBox_WhomeReceiveMoney.Size = new System.Drawing.Size(194, 49);
            this.textBox_WhomeReceiveMoney.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(310, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Кому видано:";
            // 
            // btn_EditDataToOutlay
            // 
            this.btn_EditDataToOutlay.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_EditDataToOutlay.ForeColor = System.Drawing.Color.Goldenrod;
            this.btn_EditDataToOutlay.Location = new System.Drawing.Point(123, 124);
            this.btn_EditDataToOutlay.Name = "btn_EditDataToOutlay";
            this.btn_EditDataToOutlay.Size = new System.Drawing.Size(100, 23);
            this.btn_EditDataToOutlay.TabIndex = 12;
            this.btn_EditDataToOutlay.Text = "Редагувати";
            this.btn_EditDataToOutlay.UseVisualStyleBackColor = true;
            this.btn_EditDataToOutlay.Click += new System.EventHandler(this.btn_EditDataToOutlay_Click);
            // 
            // btn_deleteDataFromOutlay
            // 
            this.btn_deleteDataFromOutlay.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_deleteDataFromOutlay.ForeColor = System.Drawing.Color.Crimson;
            this.btn_deleteDataFromOutlay.Location = new System.Drawing.Point(229, 123);
            this.btn_deleteDataFromOutlay.Name = "btn_deleteDataFromOutlay";
            this.btn_deleteDataFromOutlay.Size = new System.Drawing.Size(100, 23);
            this.btn_deleteDataFromOutlay.TabIndex = 13;
            this.btn_deleteDataFromOutlay.Text = "Видалити";
            this.btn_deleteDataFromOutlay.UseVisualStyleBackColor = true;
            this.btn_deleteDataFromOutlay.Click += new System.EventHandler(this.btn_deleteDataFromOutlay_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 470);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Денна сума надходжень:";
            // 
            // textBox_summInputToday
            // 
            this.textBox_summInputToday.Location = new System.Drawing.Point(156, 467);
            this.textBox_summInputToday.Name = "textBox_summInputToday";
            this.textBox_summInputToday.ReadOnly = true;
            this.textBox_summInputToday.Size = new System.Drawing.Size(100, 20);
            this.textBox_summInputToday.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(510, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Денна сума витрат:";
            // 
            // textBox_summaOutlayToday
            // 
            this.textBox_summaOutlayToday.Location = new System.Drawing.Point(654, 467);
            this.textBox_summaOutlayToday.Name = "textBox_summaOutlayToday";
            this.textBox_summaOutlayToday.ReadOnly = true;
            this.textBox_summaOutlayToday.Size = new System.Drawing.Size(112, 20);
            this.textBox_summaOutlayToday.TabIndex = 15;
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveData.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.btn_SaveData.ForeColor = System.Drawing.Color.Green;
            this.btn_SaveData.Location = new System.Drawing.Point(7, 124);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(100, 23);
            this.btn_SaveData.TabIndex = 5;
            this.btn_SaveData.Text = "Додати";
            this.btn_SaveData.UseVisualStyleBackColor = false;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // textBox_WhoGive1
            // 
            this.textBox_WhoGive1.Location = new System.Drawing.Point(113, 59);
            this.textBox_WhoGive1.Multiline = true;
            this.textBox_WhoGive1.Name = "textBox_WhoGive1";
            this.textBox_WhoGive1.Size = new System.Drawing.Size(238, 50);
            this.textBox_WhoGive1.TabIndex = 3;
            // 
            // textBox_id1
            // 
            this.textBox_id1.Location = new System.Drawing.Point(517, 60);
            this.textBox_id1.Name = "textBox_id1";
            this.textBox_id1.ReadOnly = true;
            this.textBox_id1.Size = new System.Drawing.Size(24, 20);
            this.textBox_id1.TabIndex = 22;
            // 
            // textBox_Summ1
            // 
            this.textBox_Summ1.Location = new System.Drawing.Point(9, 59);
            this.textBox_Summ1.Name = "textBox_Summ1";
            this.textBox_Summ1.Size = new System.Drawing.Size(98, 20);
            this.textBox_Summ1.TabIndex = 2;
            this.textBox_Summ1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Summ1_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(517, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(225, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "НАДХОДЖЕННЯ";
            // 
            // comboBox_whoReceive1
            // 
            this.comboBox_whoReceive1.FormattingEnabled = true;
            this.comboBox_whoReceive1.Location = new System.Drawing.Point(357, 59);
            this.comboBox_whoReceive1.Name = "comboBox_whoReceive1";
            this.comboBox_whoReceive1.Size = new System.Drawing.Size(157, 21);
            this.comboBox_whoReceive1.TabIndex = 4;
            // 
            // btn_SaveDataToOutlayTable
            // 
            this.btn_SaveDataToOutlayTable.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SaveDataToOutlayTable.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.btn_SaveDataToOutlayTable.ForeColor = System.Drawing.Color.Green;
            this.btn_SaveDataToOutlayTable.Location = new System.Drawing.Point(17, 123);
            this.btn_SaveDataToOutlayTable.Name = "btn_SaveDataToOutlayTable";
            this.btn_SaveDataToOutlayTable.Size = new System.Drawing.Size(100, 23);
            this.btn_SaveDataToOutlayTable.TabIndex = 11;
            this.btn_SaveDataToOutlayTable.Text = "Додати";
            this.btn_SaveDataToOutlayTable.UseVisualStyleBackColor = false;
            this.btn_SaveDataToOutlayTable.Click += new System.EventHandler(this.btn_SaveDataToOutlayTable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(206)))), ((int)(((byte)(150)))));
            this.groupBox1.Controls.Add(this.label_WhoReceive);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_EditData);
            this.groupBox1.Controls.Add(this.comboBox_whoReceive1);
            this.groupBox1.Controls.Add(this.btn_deleteData);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label_Summ);
            this.groupBox1.Controls.Add(this.btn_SaveData);
            this.groupBox1.Controls.Add(this.label_WhomGive);
            this.groupBox1.Controls.Add(this.textBox_Summ1);
            this.groupBox1.Controls.Add(this.textBox_WhoGive1);
            this.groupBox1.Controls.Add(this.textBox_id1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 421);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(175)))), ((int)(((byte)(168)))));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_SummaOutlay);
            this.groupBox2.Controls.Add(this.textBox_idOutlay);
            this.groupBox2.Controls.Add(this.btn_SaveDataToOutlayTable);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox_WhereMoneyGoes);
            this.groupBox2.Controls.Add(this.textBox_WhomeReceiveMoney);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btn_EditDataToOutlay);
            this.groupBox2.Controls.Add(this.btn_deleteDataFromOutlay);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(549, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 421);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // btn_EditVisitors
            // 
            this.btn_EditVisitors.BackColor = System.Drawing.SystemColors.Control;
            this.btn_EditVisitors.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.btn_EditVisitors.ForeColor = System.Drawing.Color.Green;
            this.btn_EditVisitors.Image = global::BelarusianDoor.Properties.Resources.edit_16x16;
            this.btn_EditVisitors.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_EditVisitors.Location = new System.Drawing.Point(295, 568);
            this.btn_EditVisitors.Name = "btn_EditVisitors";
            this.btn_EditVisitors.Size = new System.Drawing.Size(26, 26);
            this.btn_EditVisitors.TabIndex = 20;
            this.btn_EditVisitors.UseVisualStyleBackColor = false;
            this.btn_EditVisitors.Click += new System.EventHandler(this.btn_EditVisitors_Click);
            // 
            // btn_AddVisitors
            // 
            this.btn_AddVisitors.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AddVisitors.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.btn_AddVisitors.ForeColor = System.Drawing.Color.Green;
            this.btn_AddVisitors.Image = global::BelarusianDoor.Properties.Resources.Add;
            this.btn_AddVisitors.Location = new System.Drawing.Point(262, 568);
            this.btn_AddVisitors.Name = "btn_AddVisitors";
            this.btn_AddVisitors.Size = new System.Drawing.Size(26, 26);
            this.btn_AddVisitors.TabIndex = 19;
            this.btn_AddVisitors.UseVisualStyleBackColor = false;
            this.btn_AddVisitors.Click += new System.EventHandler(this.btn_AddVisitors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 626);
            this.Controls.Add(this.textBox_Visitors);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_SaveInExcelFile);
            this.Controls.Add(this.textBox_summaOutlayToday);
            this.Controls.Add(this.textBox_summInputToday);
            this.Controls.Add(this.textBox_moneyYesterdayEvening);
            this.Controls.Add(this.textBox_dayBalance);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_EditVisitors);
            this.Controls.Add(this.btn_AddVisitors);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1114, 665);
            this.Name = "Form1";
            this.Text = "Баланс надходжень і витрат";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_dayBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_moneyYesterdayEvening;
        private System.Windows.Forms.Button btn_SaveInExcelFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Visitors;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label_Summ;
        private System.Windows.Forms.Label label_WhomGive;
        private System.Windows.Forms.Label label_WhoReceive;
        private Button btn_EditData;
        private Button btn_deleteData;
        private TextBox textBox_SummaOutlay;
        private TextBox textBox_idOutlay;
        private TextBox textBox_WhereMoneyGoes;
        private Label label4;
        private Label label10;
        private Label label11;
        private TextBox textBox_WhomeReceiveMoney;
        private Label label12;
        private Button btn_EditDataToOutlay;
        private Button btn_deleteDataFromOutlay;
        private Label label13;
        private TextBox textBox_summInputToday;
        private Label label14;
        private TextBox textBox_summaOutlayToday;
        private Button btn_SaveData;
        private TextBox textBox_WhoGive1;
        private TextBox textBox_id1;
        private TextBox textBox_Summ1;
        private Label label8;
        private Label label1;
        private ComboBox comboBox_whoReceive1;
        private Button btn_SaveDataToOutlayTable;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_AddVisitors;
        private Button btn_EditVisitors;
    }
}

