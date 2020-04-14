namespace Report_system
{
    partial class frm_Generation
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
            this.button_Generation = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Name_of_form = new System.Windows.Forms.Label();
            this.label_path_name = new MaterialSkin.Controls.MaterialLabel();
            this.button_Edit_path_directory = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label_path_directory = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox_type_report = new System.Windows.Forms.ComboBox();
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(1083, 3);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(154, 23);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Закрыть";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // button_Generation
            // 
            this.button_Generation.Depth = 0;
            this.button_Generation.Location = new System.Drawing.Point(400, 352);
            this.button_Generation.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Generation.Name = "button_Generation";
            this.button_Generation.Primary = true;
            this.button_Generation.Size = new System.Drawing.Size(477, 39);
            this.button_Generation.TabIndex = 1;
            this.button_Generation.Text = "Формирование отчёта";
            this.button_Generation.UseVisualStyleBackColor = true;
            this.button_Generation.Click += new System.EventHandler(this.button_Generation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label_Name_of_form);
            this.panel1.Controls.Add(this.label_path_name);
            this.panel1.Controls.Add(this.button_Edit_path_directory);
            this.panel1.Controls.Add(this.label_path_directory);
            this.panel1.Controls.Add(this.comboBox_type_report);
            this.panel1.Controls.Add(this.comboBox_year);
            this.panel1.Controls.Add(this.comboBox_month);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.button_Generation);
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
            this.label_Name_of_form.Location = new System.Drawing.Point(444, 12);
            this.label_Name_of_form.Name = "label_Name_of_form";
            this.label_Name_of_form.Size = new System.Drawing.Size(409, 43);
            this.label_Name_of_form.TabIndex = 12;
            this.label_Name_of_form.Text = "Формирование отчета";
            // 
            // label_path_name
            // 
            this.label_path_name.AutoSize = true;
            this.label_path_name.Depth = 0;
            this.label_path_name.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_path_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_path_name.Location = new System.Drawing.Point(26, 121);
            this.label_path_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_name.Name = "label_path_name";
            this.label_path_name.Size = new System.Drawing.Size(287, 24);
            this.label_path_name.TabIndex = 11;
            this.label_path_name.Text = "Папка для сохранения отчётов";
            // 
            // button_Edit_path_directory
            // 
            this.button_Edit_path_directory.Depth = 0;
            this.button_Edit_path_directory.Location = new System.Drawing.Point(992, 151);
            this.button_Edit_path_directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Edit_path_directory.Name = "button_Edit_path_directory";
            this.button_Edit_path_directory.Primary = true;
            this.button_Edit_path_directory.Size = new System.Drawing.Size(233, 30);
            this.button_Edit_path_directory.TabIndex = 10;
            this.button_Edit_path_directory.Text = "Изменить папку ";
            this.button_Edit_path_directory.UseVisualStyleBackColor = true;
            this.button_Edit_path_directory.Click += new System.EventHandler(this.button_Edit_path_directory_Click);
            // 
            // label_path_directory
            // 
            this.label_path_directory.AutoSize = true;
            this.label_path_directory.Depth = 0;
            this.label_path_directory.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_path_directory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_path_directory.Location = new System.Drawing.Point(76, 157);
            this.label_path_directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_path_directory.Name = "label_path_directory";
            this.label_path_directory.Size = new System.Drawing.Size(178, 24);
            this.label_path_directory.TabIndex = 9;
            this.label_path_directory.Text = "Путь к директории";
            // 
            // comboBox_type_report
            // 
            this.comboBox_type_report.DataSource = this.tblTypeofreportBindingSource;
            this.comboBox_type_report.DisplayMember = "Type_of_report";
            this.comboBox_type_report.FormattingEnabled = true;
            this.comboBox_type_report.Location = new System.Drawing.Point(133, 240);
            this.comboBox_type_report.Name = "comboBox_type_report";
            this.comboBox_type_report.Size = new System.Drawing.Size(267, 28);
            this.comboBox_type_report.TabIndex = 8;
            this.comboBox_type_report.ValueMember = "Type_of_report";
            // 
            // tblTypeofreportBindingSource
            // 
            this.tblTypeofreportBindingSource.DataMember = "tbl_Type_of_report";
            this.tblTypeofreportBindingSource.DataSource = this.reportSystemDataSetBindingSource;
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
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.comboBox_year.Location = new System.Drawing.Point(808, 240);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(267, 28);
            this.comboBox_year.TabIndex = 7;
            this.comboBox_year.Text = "Год";
            // 
            // comboBox_month
            // 
            this.comboBox_month.DataSource = this.tblMonthBindingSource;
            this.comboBox_month.DisplayMember = "Month_name";
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(479, 240);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(267, 28);
            this.comboBox_month.TabIndex = 6;
            this.comboBox_month.ValueMember = "ID";
            // 
            // tblMonthBindingSource
            // 
            this.tblMonthBindingSource.DataMember = "tbl_Month";
            this.tblMonthBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // pb_Status
            // 
            this.pb_Status.ForeColor = System.Drawing.Color.Green;
            this.pb_Status.Location = new System.Drawing.Point(268, 71);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(742, 23);
            this.pb_Status.TabIndex = 5;
            this.pb_Status.Visible = false;
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
            // frm_Generation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Generation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формироапние отчёта";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton button_Generation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_type_report;
        private System.Windows.Forms.BindingSource tblTypeofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter tbl_Type_of_reportTableAdapter;
        private MaterialSkin.Controls.MaterialRaisedButton button_Edit_path_directory;
        private MaterialSkin.Controls.MaterialLabel label_path_directory;
        private MaterialSkin.Controls.MaterialLabel label_path_name;
        private System.Windows.Forms.Label label_Name_of_form;
    }
}