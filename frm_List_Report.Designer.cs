namespace Report_system
{
    partial class frm_List_Report
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
            this.button_Show_List_Report = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_List_Reports = new System.Windows.Forms.DataGridView();
            this.Report_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.comboBox_type_report = new System.Windows.Forms.ComboBox();
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
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
            // button_Show_List_Report
            // 
            this.button_Show_List_Report.Depth = 0;
            this.button_Show_List_Report.Location = new System.Drawing.Point(470, 192);
            this.button_Show_List_Report.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Show_List_Report.Name = "button_Show_List_Report";
            this.button_Show_List_Report.Primary = true;
            this.button_Show_List_Report.Size = new System.Drawing.Size(324, 39);
            this.button_Show_List_Report.TabIndex = 1;
            this.button_Show_List_Report.Text = "Показать отчеты";
            this.button_Show_List_Report.UseVisualStyleBackColor = true;
            this.button_Show_List_Report.Click += new System.EventHandler(this.button_Show_List_Report_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView_List_Reports);
            this.panel1.Controls.Add(this.comboBox_year);
            this.panel1.Controls.Add(this.comboBox_month);
            this.panel1.Controls.Add(this.comboBox_type_report);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.button_Show_List_Report);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView_List_Reports
            // 
            this.dataGridView_List_Reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_List_Reports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Report_name,
            this.Date,
            this.Result});
            this.dataGridView_List_Reports.Location = new System.Drawing.Point(159, 276);
            this.dataGridView_List_Reports.Name = "dataGridView_List_Reports";
            this.dataGridView_List_Reports.RowHeadersWidth = 70;
            this.dataGridView_List_Reports.RowTemplate.Height = 24;
            this.dataGridView_List_Reports.Size = new System.Drawing.Size(687, 362);
            this.dataGridView_List_Reports.TabIndex = 9;
            this.dataGridView_List_Reports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_List_Reports_CellContentClick);
            // 
            // Report_name
            // 
            this.Report_name.HeaderText = "Название отчета";
            this.Report_name.MinimumWidth = 6;
            this.Report_name.Name = "Report_name";
            this.Report_name.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата добавления";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.Width = 125;
            // 
            // Result
            // 
            this.Result.HeaderText = "Результат";
            this.Result.MinimumWidth = 6;
            this.Result.Name = "Result";
            this.Result.Width = 125;
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
            this.comboBox_year.Location = new System.Drawing.Point(823, 104);
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
            this.comboBox_month.Location = new System.Drawing.Point(489, 104);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(238, 28);
            this.comboBox_month.TabIndex = 7;
            this.comboBox_month.ValueMember = "ID";
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
            // comboBox_type_report
            // 
            this.comboBox_type_report.DataSource = this.tblTypeofreportBindingSource;
            this.comboBox_type_report.DisplayMember = "Type_of_report";
            this.comboBox_type_report.FormattingEnabled = true;
            this.comboBox_type_report.Location = new System.Drawing.Point(161, 104);
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
            // frm_List_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_List_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton button_Show_List_Report;
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
        private System.Windows.Forms.DataGridView dataGridView_List_Reports;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
    }
}