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
            this.button_Close = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Name_of_form = new System.Windows.Forms.Label();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.label_path_name = new MaterialSkin.Controls.MaterialLabel();
            this.button_Edit_path_directory = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label_path_directory = new MaterialSkin.Controls.MaterialLabel();
            this.button_Make_prognoz = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox_Type_of_time = new System.Windows.Forms.GroupBox();
            this.rbutton_ElCard = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_Visa = new MaterialSkin.Controls.MaterialRadioButton();
            this.tblMonthBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.tblYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblNameofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet1 = new Report_system.Report_SystemDataSet();
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.tbl_YearTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_YearTableAdapter();
            this.tbl_Name_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Name_of_reportTableAdapter();
            this.panel1.SuspendLayout();
            this.groupBox_Type_of_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Depth = 0;
            this.button_Close.Location = new System.Drawing.Point(1071, 12);
            this.button_Close.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Close.Name = "button_Close";
            this.button_Close.Primary = true;
            this.button_Close.Size = new System.Drawing.Size(154, 39);
            this.button_Close.TabIndex = 0;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label_Name_of_form);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.label_path_name);
            this.panel1.Controls.Add(this.button_Edit_path_directory);
            this.panel1.Controls.Add(this.label_path_directory);
            this.panel1.Controls.Add(this.button_Make_prognoz);
            this.panel1.Controls.Add(this.groupBox_Type_of_time);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            // 
            // label_Name_of_form
            // 
            this.label_Name_of_form.AutoSize = true;
            this.label_Name_of_form.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name_of_form.Location = new System.Drawing.Point(438, 2);
            this.label_Name_of_form.Name = "label_Name_of_form";
            this.label_Name_of_form.Size = new System.Drawing.Size(456, 43);
            this.label_Name_of_form.TabIndex = 21;
            this.label_Name_of_form.Text = "Формирование прогноза";
            // 
            // pb_Status
            // 
            this.pb_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.pb_Status.Location = new System.Drawing.Point(457, 48);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(360, 23);
            this.pb_Status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_Status.TabIndex = 20;
            this.pb_Status.Visible = false;
            // 
            // label_path_name
            // 
            this.label_path_name.AutoSize = true;
            this.label_path_name.Depth = 0;
            this.label_path_name.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_path_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_path_name.Location = new System.Drawing.Point(35, 125);
            this.label_path_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_name.Name = "label_path_name";
            this.label_path_name.Size = new System.Drawing.Size(299, 24);
            this.label_path_name.TabIndex = 19;
            this.label_path_name.Text = "Папка для сохранения прогноза";
            // 
            // button_Edit_path_directory
            // 
            this.button_Edit_path_directory.Depth = 0;
            this.button_Edit_path_directory.Location = new System.Drawing.Point(1001, 155);
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
            this.label_path_directory.Location = new System.Drawing.Point(85, 161);
            this.label_path_directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_directory.Name = "label_path_directory";
            this.label_path_directory.Size = new System.Drawing.Size(178, 24);
            this.label_path_directory.TabIndex = 17;
            this.label_path_directory.Text = "Путь к директории";
            // 
            // button_Make_prognoz
            // 
            this.button_Make_prognoz.Depth = 0;
            this.button_Make_prognoz.Location = new System.Drawing.Point(457, 383);
            this.button_Make_prognoz.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Make_prognoz.Name = "button_Make_prognoz";
            this.button_Make_prognoz.Primary = true;
            this.button_Make_prognoz.Size = new System.Drawing.Size(327, 37);
            this.button_Make_prognoz.TabIndex = 16;
            this.button_Make_prognoz.Text = "Сформировать прогноз";
            this.button_Make_prognoz.UseVisualStyleBackColor = true;
            this.button_Make_prognoz.Click += new System.EventHandler(this.button_Make_prognoz_ClickAsync);
            // 
            // groupBox_Type_of_time
            // 
            this.groupBox_Type_of_time.Controls.Add(this.rbutton_ElCard);
            this.groupBox_Type_of_time.Controls.Add(this.rbutton_Visa);
            this.groupBox_Type_of_time.Location = new System.Drawing.Point(457, 200);
            this.groupBox_Type_of_time.Name = "groupBox_Type_of_time";
            this.groupBox_Type_of_time.Size = new System.Drawing.Size(334, 75);
            this.groupBox_Type_of_time.TabIndex = 10;
            this.groupBox_Type_of_time.TabStop = false;
            this.groupBox_Type_of_time.Text = "Прогноз";
            // 
            // rbutton_ElCard
            // 
            this.rbutton_ElCard.AutoSize = true;
            this.rbutton_ElCard.Depth = 0;
            this.rbutton_ElCard.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_ElCard.Location = new System.Drawing.Point(174, 23);
            this.rbutton_ElCard.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_ElCard.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_ElCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_ElCard.Name = "rbutton_ElCard";
            this.rbutton_ElCard.Ripple = true;
            this.rbutton_ElCard.Size = new System.Drawing.Size(90, 30);
            this.rbutton_ElCard.TabIndex = 12;
            this.rbutton_ElCard.Text = "ЭлКарт";
            this.rbutton_ElCard.UseVisualStyleBackColor = true;
            // 
            // rbutton_Visa
            // 
            this.rbutton_Visa.AutoSize = true;
            this.rbutton_Visa.Checked = true;
            this.rbutton_Visa.Depth = 0;
            this.rbutton_Visa.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Visa.Location = new System.Drawing.Point(44, 23);
            this.rbutton_Visa.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Visa.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Visa.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Visa.Name = "rbutton_Visa";
            this.rbutton_Visa.Ripple = true;
            this.rbutton_Visa.Size = new System.Drawing.Size(64, 30);
            this.rbutton_Visa.TabIndex = 11;
            this.rbutton_Visa.TabStop = true;
            this.rbutton_Visa.Text = "Visa";
            this.rbutton_Visa.UseVisualStyleBackColor = true;
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
            this.groupBox_Type_of_time.ResumeLayout(false);
            this.groupBox_Type_of_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton button_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
        private System.Windows.Forms.BindingSource tblTypeofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter tbl_Type_of_reportTableAdapter;
        private System.Windows.Forms.GroupBox groupBox_Type_of_time;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_ElCard;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Visa;
        private MaterialSkin.Controls.MaterialRaisedButton button_Make_prognoz;
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
        private System.Windows.Forms.Label label_Name_of_form;
    }
}