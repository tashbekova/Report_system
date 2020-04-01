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
            this.comboBox_Year = new System.Windows.Forms.ComboBox();
            this.comboBox_Month = new System.Windows.Forms.ComboBox();
            this.tblMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbl_MonthTableAdapter = new Report_system.Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
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
            // button_Generation
            // 
            this.button_Generation.Depth = 0;
            this.button_Generation.Location = new System.Drawing.Point(284, 272);
            this.button_Generation.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Generation.Name = "button_Generation";
            this.button_Generation.Primary = true;
            this.button_Generation.Size = new System.Drawing.Size(520, 39);
            this.button_Generation.TabIndex = 1;
            this.button_Generation.Text = "Формирование отчёта";
            this.button_Generation.UseVisualStyleBackColor = true;
            this.button_Generation.Click += new System.EventHandler(this.button_Generation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.comboBox_Year);
            this.panel1.Controls.Add(this.comboBox_Month);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.button_Generation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox_Year
            // 
            this.comboBox_Year.FormattingEnabled = true;
            this.comboBox_Year.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.comboBox_Year.Location = new System.Drawing.Point(616, 116);
            this.comboBox_Year.Name = "comboBox_Year";
            this.comboBox_Year.Size = new System.Drawing.Size(267, 28);
            this.comboBox_Year.TabIndex = 7;
            this.comboBox_Year.Text = "Год";
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.DataSource = this.tblMonthBindingSource;
            this.comboBox_Month.DisplayMember = "Month_name";
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.Location = new System.Drawing.Point(209, 116);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.Size = new System.Drawing.Size(267, 28);
            this.comboBox_Month.TabIndex = 6;
            this.comboBox_Month.Text = "Месяц";
            this.comboBox_Month.ValueMember = "ID";
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
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton button_Generation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.ComboBox comboBox_Year;
        private System.Windows.Forms.ComboBox comboBox_Month;
        private System.Windows.Forms.BindingSource tblMonthBindingSource;
        private Report_SystemDataSetTableAdapters.tbl_MonthTableAdapter tbl_MonthTableAdapter;
    }
}