namespace Report_system
{
    partial class frm_Settings
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
            this.button_Edit_Settings = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Update = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbutton_Name_of_report = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_Type_of_report = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_Year = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbutton_User = new MaterialSkin.Controls.MaterialRadioButton();
            this.dataGridView_List_Settings = new System.Windows.Forms.DataGridView();
            this.tblYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblNameofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblTypeofreportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.tbl_Type_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter();
            this.tbl_YearTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_YearTableAdapter();
            this.tbl_Name_of_reportTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_Name_of_reportTableAdapter();
            this.label_Name_of_form = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List_Settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).BeginInit();
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
            // button_Edit_Settings
            // 
            this.button_Edit_Settings.Depth = 0;
            this.button_Edit_Settings.Location = new System.Drawing.Point(389, 190);
            this.button_Edit_Settings.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Edit_Settings.Name = "button_Edit_Settings";
            this.button_Edit_Settings.Primary = true;
            this.button_Edit_Settings.Size = new System.Drawing.Size(362, 39);
            this.button_Edit_Settings.TabIndex = 1;
            this.button_Edit_Settings.Text = "Выбрать";
            this.button_Edit_Settings.UseVisualStyleBackColor = true;
            this.button_Edit_Settings.Click += new System.EventHandler(this.button_Edit_Settings_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label_Name_of_form);
            this.panel1.Controls.Add(this.button_Update);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dataGridView_List_Settings);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.button_Edit_Settings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            // 
            // button_Update
            // 
            this.button_Update.Depth = 0;
            this.button_Update.Location = new System.Drawing.Point(625, 294);
            this.button_Update.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Update.Name = "button_Update";
            this.button_Update.Primary = true;
            this.button_Update.Size = new System.Drawing.Size(214, 35);
            this.button_Update.TabIndex = 12;
            this.button_Update.Text = "Обновить данные";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Visible = false;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbutton_Name_of_report);
            this.groupBox1.Controls.Add(this.rbutton_Type_of_report);
            this.groupBox1.Controls.Add(this.rbutton_Year);
            this.groupBox1.Controls.Add(this.rbutton_User);
            this.groupBox1.Location = new System.Drawing.Point(106, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // rbutton_Name_of_report
            // 
            this.rbutton_Name_of_report.AutoSize = true;
            this.rbutton_Name_of_report.Depth = 0;
            this.rbutton_Name_of_report.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Name_of_report.Location = new System.Drawing.Point(519, 34);
            this.rbutton_Name_of_report.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Name_of_report.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Name_of_report.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Name_of_report.Name = "rbutton_Name_of_report";
            this.rbutton_Name_of_report.Ripple = true;
            this.rbutton_Name_of_report.Size = new System.Drawing.Size(291, 30);
            this.rbutton_Name_of_report.TabIndex = 3;
            this.rbutton_Name_of_report.Text = "Название поступающего отчета";
            this.rbutton_Name_of_report.UseVisualStyleBackColor = true;
            // 
            // rbutton_Type_of_report
            // 
            this.rbutton_Type_of_report.AutoSize = true;
            this.rbutton_Type_of_report.Depth = 0;
            this.rbutton_Type_of_report.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Type_of_report.Location = new System.Drawing.Point(349, 34);
            this.rbutton_Type_of_report.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Type_of_report.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Type_of_report.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Type_of_report.Name = "rbutton_Type_of_report";
            this.rbutton_Type_of_report.Ripple = true;
            this.rbutton_Type_of_report.Size = new System.Drawing.Size(119, 30);
            this.rbutton_Type_of_report.TabIndex = 2;
            this.rbutton_Type_of_report.Text = "Тип отчета";
            this.rbutton_Type_of_report.UseVisualStyleBackColor = true;
            // 
            // rbutton_Year
            // 
            this.rbutton_Year.AutoSize = true;
            this.rbutton_Year.Depth = 0;
            this.rbutton_Year.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_Year.Location = new System.Drawing.Point(231, 34);
            this.rbutton_Year.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_Year.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_Year.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_Year.Name = "rbutton_Year";
            this.rbutton_Year.Ripple = true;
            this.rbutton_Year.Size = new System.Drawing.Size(60, 30);
            this.rbutton_Year.TabIndex = 1;
            this.rbutton_Year.Text = "Год";
            this.rbutton_Year.UseVisualStyleBackColor = true;
            // 
            // rbutton_User
            // 
            this.rbutton_User.AutoSize = true;
            this.rbutton_User.Checked = true;
            this.rbutton_User.Depth = 0;
            this.rbutton_User.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbutton_User.Location = new System.Drawing.Point(20, 34);
            this.rbutton_User.Margin = new System.Windows.Forms.Padding(0);
            this.rbutton_User.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbutton_User.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbutton_User.Name = "rbutton_User";
            this.rbutton_User.Ripple = true;
            this.rbutton_User.Size = new System.Drawing.Size(146, 30);
            this.rbutton_User.TabIndex = 0;
            this.rbutton_User.TabStop = true;
            this.rbutton_User.Text = "Пользователь";
            this.rbutton_User.UseVisualStyleBackColor = true;
            // 
            // dataGridView_List_Settings
            // 
            this.dataGridView_List_Settings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_List_Settings.Location = new System.Drawing.Point(106, 294);
            this.dataGridView_List_Settings.Name = "dataGridView_List_Settings";
            this.dataGridView_List_Settings.RowHeadersWidth = 70;
            this.dataGridView_List_Settings.RowTemplate.Height = 24;
            this.dataGridView_List_Settings.Size = new System.Drawing.Size(468, 369);
            this.dataGridView_List_Settings.TabIndex = 9;
            this.dataGridView_List_Settings.Visible = false;
            this.dataGridView_List_Settings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_List_Settings_CellContentClick);
            this.dataGridView_List_Settings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_List_Settings_CellValueChanged);
            this.dataGridView_List_Settings.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_List_Settings_UserAddedRow);
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
            // report_SystemDataSet
            // 
            this.report_SystemDataSet.DataSetName = "Report_SystemDataSet";
            this.report_SystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblMonthBindingSource
            // 
            this.tblMonthBindingSource.DataMember = "tbl_Month";
            this.tblMonthBindingSource.DataSource = this.reportSystemDataSetBindingSource;
            // 
            // tblNameofreportBindingSource
            // 
            this.tblNameofreportBindingSource.DataMember = "tbl_Name_of_report";
            this.tblNameofreportBindingSource.DataSource = this.reportSystemDataSetBindingSource;
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
            // label_Name_of_form
            // 
            this.label_Name_of_form.AutoSize = true;
            this.label_Name_of_form.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name_of_form.Location = new System.Drawing.Point(547, 2);
            this.label_Name_of_form.Name = "label_Name_of_form";
            this.label_Name_of_form.Size = new System.Drawing.Size(213, 43);
            this.label_Name_of_form.TabIndex = 13;
            this.label_Name_of_form.Text = "Настройки";
            // 
            // frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List_Settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNameofreportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTypeofreportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton button_Edit_Settings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
        private System.Windows.Forms.BindingSource tblTypeofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Type_of_reportTableAdapter tbl_Type_of_reportTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView_List_Settings;
        private System.Windows.Forms.BindingSource tblYearBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_YearTableAdapter tbl_YearTableAdapter;
        private System.Windows.Forms.BindingSource tblNameofreportBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_Name_of_reportTableAdapter tbl_Name_of_reportTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Name_of_report;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Type_of_report;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_Year;
        private MaterialSkin.Controls.MaterialRadioButton rbutton_User;
        private MaterialSkin.Controls.MaterialRaisedButton button_Update;
        private System.Windows.Forms.Label label_Name_of_form;
    }
}