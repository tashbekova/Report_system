namespace Report_system
{
    partial class frm_Prognoz
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
            this.label_path_name = new MaterialSkin.Controls.MaterialLabel();
            this.button_Edit_path_directory = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label_path_directory = new MaterialSkin.Controls.MaterialLabel();
            this.button_Make_statistic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tblMonthBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.groupBox_Type_of_time = new System.Windows.Forms.GroupBox();
            this.rbutton_Time = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_Year = new MaterialSkin.Controls.MaterialRadioButton();
            this.tblYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblNameofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet1 = new Report_system.Report_SystemDataSet();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.tbl_YearTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_YearTableAdapter();
            this.tbl_Name_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Name_of_reportTableAdapter();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            this.groupBox_Type_of_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet1)).BeginInit();
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
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.label_path_name);
            this.panel1.Controls.Add(this.button_Edit_path_directory);
            this.panel1.Controls.Add(this.label_path_directory);
            this.panel1.Controls.Add(this.button_Make_statistic);
            this.panel1.Controls.Add(this.groupBox_Type_of_time);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            // 
            // label_path_name
            // 
            this.label_path_name.AutoSize = true;
            this.label_path_name.Depth = 0;
            this.label_path_name.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_path_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_path_name.Location = new System.Drawing.Point(28, 78);
            this.label_path_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_name.Name = "label_path_name";
            this.label_path_name.Size = new System.Drawing.Size(321, 24);
            this.label_path_name.TabIndex = 19;
            this.label_path_name.Text = "Папка для сохранения  статистики";
            // 
            // button_Edit_path_directory
            // 
            this.button_Edit_path_directory.Depth = 0;
            this.button_Edit_path_directory.Location = new System.Drawing.Point(994, 108);
            this.button_Edit_path_directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Edit_path_directory.Name = "button_Edit_path_directory";
            this.button_Edit_path_directory.Primary = true;
            this.button_Edit_path_directory.Size = new System.Drawing.Size(233, 30);
            this.button_Edit_path_directory.TabIndex = 18;
            this.button_Edit_path_directory.Text = "Изменить папку ";
            this.button_Edit_path_directory.UseVisualStyleBackColor = true;
            // 
            // label_path_directory
            // 
            this.label_path_directory.AutoSize = true;
            this.label_path_directory.Depth = 0;
            this.label_path_directory.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_path_directory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_path_directory.Location = new System.Drawing.Point(78, 114);
            this.label_path_directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_directory.Name = "label_path_directory";
            this.label_path_directory.Size = new System.Drawing.Size(178, 24);
            this.label_path_directory.TabIndex = 17;
            this.label_path_directory.Text = "Путь к директории";
            // 
            // button_Make_statistic
            // 
            this.button_Make_statistic.Depth = 0;
            this.button_Make_statistic.Location = new System.Drawing.Point(450, 336);
            this.button_Make_statistic.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Make_statistic.Name = "button_Make_statistic";
            this.button_Make_statistic.Primary = true;
            this.button_Make_statistic.Size = new System.Drawing.Size(327, 37);
            this.button_Make_statistic.TabIndex = 16;
            this.button_Make_statistic.Text = "Сформировать прогноз";
            this.button_Make_statistic.UseVisualStyleBackColor = true;
            this.button_Make_statistic.Click += new System.EventHandler(this.button_Make_statistic_ClickAsync);
            // 
            // tblMonthBindingSource1
            // 
            this.tblMonthBindingSource1.DataMember = "tbl_Month";
            this.tblMonthBindingSource1.DataSource = this.report_SystemDataSet;
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
            this.groupBox_Type_of_time.Location = new System.Drawing.Point(443, 162);
            this.groupBox_Type_of_time.Name = "groupBox_Type_of_time";
            this.groupBox_Type_of_time.Size = new System.Drawing.Size(334, 75);
            this.groupBox_Type_of_time.TabIndex = 10;
            this.groupBox_Type_of_time.TabStop = false;
            this.groupBox_Type_of_time.Text = "Статистика";
            // 
            // rbutton_Time
            // 
            this.rbutton_Time.AutoSize = true;
            this.rbutton_Time.Depth = 0;
            this.rbutton_Time.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Time.Location = new System.Drawing.Point(172, 23);
            this.rbutton_Time.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Time.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Time.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Time.Name = "rbutton_Time";
            this.rbutton_Time.Ripple = true;
            this.rbutton_Time.Size = new System.Drawing.Size(129, 30);
            this.rbutton_Time.TabIndex = 12;
            this.rbutton_Time.Text = "По месяцам";
            this.rbutton_Time.UseVisualStyleBackColor = true;
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
            // 
            // tblYearBindingSource
            // 
            this.tblYearBindingSource.DataMember = "tbl_Year";
            this.tblYearBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // reportSystemDataSetBindingSource
            // 
            this.reportSystemDataSetBindingSource.DataSource = this.report_SystemDataSet;
            this.reportSystemDataSetBindingSource.Position = 0;
            // 
            // tblMonthBindingSource
            // 
            this.tblMonthBindingSource.DataMember = "tbl_Month";
            this.tblMonthBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // tblNameofreportBindingSource
            // 
            this.tblNameofreportBindingSource.DataMember = "tbl_Name_of_report";
            this.tblNameofreportBindingSource.DataSource = this.report_SystemDataSet1;
            // 
            // report_SystemDataSet1
            // 
            this.report_SystemDataSet1.DataSetName = "Report_SystemDataSet";
            this.report_SystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.lblName.Visible = false;
            // 
            // tblTypeofreportBindingSource
            // 
            this.tblTypeofreportBindingSource.DataMember = "tbl_Type_of_report";
            this.tblTypeofreportBindingSource.DataSource = this.reportSystemDataSetBindingSource;
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
            // tbl_YearTableAdapter
            // 
            this.tbl_YearTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_Name_of_reportTableAdapter
            // 
            this.tbl_Name_of_reportTableAdapter.ClearBeforeFill = true;
            // 
            // pb_Status
            // 
            this.pb_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.pb_Status.Location = new System.Drawing.Point(428, 12);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(360, 23);
            this.pb_Status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_Status.TabIndex = 20;
            this.pb_Status.Visible = false;
            // 
            // frm_Prognoz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Prognoz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.frm_Statistic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            this.groupBox_Type_of_time.ResumeLayout(false);
            this.groupBox_Type_of_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet1)).EndInit();
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
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
        private System.Windows.Forms.BindingSource tblTypeofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter tbl_Type_of_reportTableAdapter;
        private System.Windows.Forms.GroupBox groupBox_Type_of_time;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Time;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Year;
        private MaterialSkin.Controls.MaterialRaisedButton button_Make_statistic;
        private MaterialSkin.Controls.MaterialLabel label_path_name;
        private MaterialSkin.Controls.MaterialRaisedButton button_Edit_path_directory;
        private MaterialSkin.Controls.MaterialLabel label_path_directory;
        private System.Windows.Forms.BindingSource tblYearBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_YearTableAdapter tbl_YearTableAdapter;
        private Report_SystemDataSet report_SystemDataSet1;
        private System.Windows.Forms.BindingSource tblNameofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Name_of_reportTableAdapter tbl_Name_of_reportTableAdapter;
        private System.Windows.Forms.BindingSource tblMonthBindingSource1;
        public System.Windows.Forms.ProgressBar pb_Status;
    }
}