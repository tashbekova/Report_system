namespace Report_system
{
    partial class frm_Statistic
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
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_type_of_statistic = new System.Windows.Forms.GroupBox();
            this.rbutton_currency = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_type_of_card = new MaterialSkin.Controls.MaterialRadioButton();
            this.label_description_for_time = new MaterialSkin.Controls.MaterialLabel();
            this.label_description_for_year = new MaterialSkin.Controls.MaterialLabel();
            this.combobox_month2 = new System.Windows.Forms.ComboBox();
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.groupBox_Type_of_time = new System.Windows.Forms.GroupBox();
            this.rbutton_Time = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_Year = new MaterialSkin.Controls.MaterialRadioButton();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.comboBox_type_report = new System.Windows.Forms.ComboBox();
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.button_Make_statistic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1.SuspendLayout();
            this.groupBox_type_of_statistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            this.groupBox_Type_of_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(1071, 12);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(154, 39);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Закрыть";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button_Make_statistic);
            this.panel1.Controls.Add(this.groupBox_type_of_statistic);
            this.panel1.Controls.Add(this.label_description_for_time);
            this.panel1.Controls.Add(this.label_description_for_year);
            this.panel1.Controls.Add(this.combobox_month2);
            this.panel1.Controls.Add(this.groupBox_Type_of_time);
            this.panel1.Controls.Add(this.comboBox_year);
            this.panel1.Controls.Add(this.comboBox_month);
            this.panel1.Controls.Add(this.comboBox_type_report);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox_type_of_statistic
            // 
            this.groupBox_type_of_statistic.Controls.Add(this.rbutton_currency);
            this.groupBox_type_of_statistic.Controls.Add(this.rbutton_type_of_card);
            this.groupBox_type_of_statistic.Location = new System.Drawing.Point(104, 311);
            this.groupBox_type_of_statistic.Name = "groupBox_type_of_statistic";
            this.groupBox_type_of_statistic.Size = new System.Drawing.Size(267, 112);
            this.groupBox_type_of_statistic.TabIndex = 15;
            this.groupBox_type_of_statistic.TabStop = false;
            this.groupBox_type_of_statistic.Text = "Тип статистики";
            // 
            // rbutton_currency
            // 
            this.rbutton_currency.AutoSize = true;
            this.rbutton_currency.Depth = 0;
            this.rbutton_currency.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_currency.Location = new System.Drawing.Point(3, 66);
            this.rbutton_currency.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_currency.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_currency.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_currency.Name = "rbutton_currency";
            this.rbutton_currency.Ripple = true;
            this.rbutton_currency.Size = new System.Drawing.Size(92, 30);
            this.rbutton_currency.TabIndex = 12;
            this.rbutton_currency.Text = "Валюта";
            this.rbutton_currency.UseVisualStyleBackColor = true;
            // 
            // rbutton_type_of_card
            // 
            this.rbutton_type_of_card.AutoSize = true;
            this.rbutton_type_of_card.Checked = true;
            this.rbutton_type_of_card.Depth = 0;
            this.rbutton_type_of_card.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_type_of_card.Location = new System.Drawing.Point(3, 23);
            this.rbutton_type_of_card.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_type_of_card.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_type_of_card.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_type_of_card.Name = "rbutton_type_of_card";
            this.rbutton_type_of_card.Ripple = true;
            this.rbutton_type_of_card.Size = new System.Drawing.Size(115, 30);
            this.rbutton_type_of_card.TabIndex = 11;
            this.rbutton_type_of_card.TabStop = true;
            this.rbutton_type_of_card.Text = "Тип карты";
            this.rbutton_type_of_card.UseVisualStyleBackColor = true;
            // 
            // label_description_for_time
            // 
            this.label_description_for_time.AutoSize = true;
            this.label_description_for_time.Depth = 0;
            this.label_description_for_time.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_description_for_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_description_for_time.Location = new System.Drawing.Point(500, 306);
            this.label_description_for_time.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_description_for_time.Name = "label_description_for_time";
            this.label_description_for_time.Size = new System.Drawing.Size(398, 24);
            this.label_description_for_time.TabIndex = 14;
            this.label_description_for_time.Text = "Выберите с какого месяца по какой месяц ";
            this.label_description_for_time.Visible = false;
            // 
            // label_description_for_year
            // 
            this.label_description_for_year.AutoSize = true;
            this.label_description_for_year.Depth = 0;
            this.label_description_for_year.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_description_for_year.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_description_for_year.Location = new System.Drawing.Point(500, 202);
            this.label_description_for_year.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_description_for_year.Name = "label_description_for_year";
            this.label_description_for_year.Size = new System.Drawing.Size(533, 24);
            this.label_description_for_year.TabIndex = 13;
            this.label_description_for_year.Text = "Выберите тип отчета и год для формирования статистики";
            // 
            // combobox_month2
            // 
            this.combobox_month2.DataSource = this.tblMonthBindingSource;
            this.combobox_month2.DisplayMember = "Month_name";
            this.combobox_month2.FormattingEnabled = true;
            this.combobox_month2.Location = new System.Drawing.Point(824, 340);
            this.combobox_month2.Name = "combobox_month2";
            this.combobox_month2.Size = new System.Drawing.Size(238, 28);
            this.combobox_month2.TabIndex = 12;
            this.combobox_month2.ValueMember = "ID";
            this.combobox_month2.Visible = false;
            // 
            // tblMonthBindingSource
            // 
            this.tblMonthBindingSource.DataMember = "tbl_Month";
            this.tblMonthBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // reportSystemDataSetBindingSource
            // 
            this.reportSystemDataSetBindingSource.DataSource = this.report_SystemDataSet;
            this.reportSystemDataSetBindingSource.Position = 0;
            // 
            // report_SystemDataSet
            // 
            this.report_SystemDataSet.DataSetName = "Report_SystemDataSet";
            this.report_SystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox_Type_of_time
            // 
            this.groupBox_Type_of_time.Controls.Add(this.rbutton_Time);
            this.groupBox_Type_of_time.Controls.Add(this.rbutton_Year);
            this.groupBox_Type_of_time.Location = new System.Drawing.Point(104, 170);
            this.groupBox_Type_of_time.Name = "groupBox_Type_of_time";
            this.groupBox_Type_of_time.Size = new System.Drawing.Size(267, 112);
            this.groupBox_Type_of_time.TabIndex = 10;
            this.groupBox_Type_of_time.TabStop = false;
            this.groupBox_Type_of_time.Text = "Статистика";
            // 
            // rbutton_Time
            // 
            this.rbutton_Time.AutoSize = true;
            this.rbutton_Time.Depth = 0;
            this.rbutton_Time.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Time.Location = new System.Drawing.Point(3, 66);
            this.rbutton_Time.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Time.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Time.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Time.Name = "rbutton_Time";
            this.rbutton_Time.Ripple = true;
            this.rbutton_Time.Size = new System.Drawing.Size(188, 30);
            this.rbutton_Time.TabIndex = 12;
            this.rbutton_Time.Text = "За период времени";
            this.rbutton_Time.UseVisualStyleBackColor = true;
            this.rbutton_Time.CheckedChanged += new System.EventHandler(this.rbutton_Time_CheckedChanged);
            // 
            // rbutton_Year
            // 
            this.rbutton_Year.AutoSize = true;
            this.rbutton_Year.Checked = true;
            this.rbutton_Year.Depth = 0;
            this.rbutton_Year.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Year.Location = new System.Drawing.Point(3, 23);
            this.rbutton_Year.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Year.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Year.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Year.Name = "rbutton_Year";
            this.rbutton_Year.Ripple = true;
            this.rbutton_Year.Size = new System.Drawing.Size(98, 30);
            this.rbutton_Year.TabIndex = 11;
            this.rbutton_Year.TabStop = true;
            this.rbutton_Year.Text = "Годовая";
            this.rbutton_Year.UseVisualStyleBackColor = true;
            this.rbutton_Year.CheckedChanged += new System.EventHandler(this.rbutton_Year_CheckedChanged);
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.comboBox_year.Location = new System.Drawing.Point(824, 238);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(238, 28);
            this.comboBox_year.TabIndex = 8;
            this.comboBox_year.Text = "Год";
            // 
            // comboBox_month
            // 
            this.comboBox_month.DataSource = this.tblMonthBindingSource;
            this.comboBox_month.DisplayMember = "Month_name";
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(472, 340);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(238, 28);
            this.comboBox_month.TabIndex = 7;
            this.comboBox_month.ValueMember = "ID";
            this.comboBox_month.Visible = false;
            // 
            // comboBox_type_report
            // 
            this.comboBox_type_report.DataSource = this.tblTypeofreportBindingSource;
            this.comboBox_type_report.DisplayMember = "Type_of_report";
            this.comboBox_type_report.FormattingEnabled = true;
            this.comboBox_type_report.Location = new System.Drawing.Point(472, 238);
            this.comboBox_type_report.Name = "comboBox_type_report";
            this.comboBox_type_report.Size = new System.Drawing.Size(238, 28);
            this.comboBox_type_report.TabIndex = 6;
            this.comboBox_type_report.ValueMember = "Type_of_report";
            // 
            // tblTypeofreportBindingSource
            // 
            this.tblTypeofreportBindingSource.DataMember = "tbl_Type_of_report";
            this.tblTypeofreportBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // pb_Status
            // 
            this.pb_Status.ForeColor = System.Drawing.Color.Green;
            this.pb_Status.Location = new System.Drawing.Point(245, 12);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(742, 23);
            this.pb_Status.TabIndex = 5;
            this.pb_Status.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(28, 9);
            this.lblName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(158, 24);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Название файла";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbl_MonthTableAdapter
            // 
            this.tbl_MonthTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_Type_of_reportTableAdapter
            // 
            this.tbl_Type_of_reportTableAdapter.ClearBeforeFill = true;
            // 
            // button_Make_statistic
            // 
            this.button_Make_statistic.Depth = 0;
            this.button_Make_statistic.Location = new System.Drawing.Point(504, 468);
            this.button_Make_statistic.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Make_statistic.Name = "button_Make_statistic";
            this.button_Make_statistic.Primary = true;
            this.button_Make_statistic.Size = new System.Drawing.Size(327, 37);
            this.button_Make_statistic.TabIndex = 16;
            this.button_Make_statistic.Text = "Сформировать статистику";
            this.button_Make_statistic.UseVisualStyleBackColor = true;
            // 
            // frm_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.frm_Statistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_type_of_statistic.ResumeLayout(false);
            this.groupBox_type_of_statistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            this.groupBox_Type_of_time.ResumeLayout(false);
            this.groupBox_Type_of_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_type_report;
        private System.Windows.Forms.BindingSource tblTypeofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter tbl_Type_of_reportTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.GroupBox groupBox_Type_of_time;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Time;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Year;
        private MaterialSkin.Controls.MaterialLabel label_description_for_time;
        private MaterialSkin.Controls.MaterialLabel label_description_for_year;
        private System.Windows.Forms.ComboBox combobox_month2;
        private System.Windows.Forms.GroupBox groupBox_type_of_statistic;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_currency;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_type_of_card;
        private MaterialSkin.Controls.MaterialRaisedButton button_Make_statistic;
    }
}