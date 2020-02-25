namespace Report_system
{
    partial class Form3
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
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count_tranzac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(800, 49);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(154, 39);
            this.materialRaisedButton1.TabIndex = 0;
            this.materialRaisedButton1.Text = "Закрыть";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(468, 49);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(194, 39);
            this.materialRaisedButton2.TabIndex = 1;
            this.materialRaisedButton2.Text = "Считать данные";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Location = new System.Drawing.Point(156, 49);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(193, 39);
            this.materialRaisedButton3.TabIndex = 2;
            this.materialRaisedButton3.Text = "Открыть файл";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            this.materialRaisedButton3.Click += new System.EventHandler(this.materialRaisedButton3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.materialRaisedButton3);
            this.panel1.Controls.Add(this.materialRaisedButton1);
            this.panel1.Controls.Add(this.materialRaisedButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Device,
            this.Device_name,
            this.Currency,
            this.Amount,
            this.Count_tranzac});
            this.dataGridView1.DataSource = this.reportSystemDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(97, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(402, 545);
            this.dataGridView1.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Device
            // 
            this.Device.HeaderText = "Device";
            this.Device.MinimumWidth = 6;
            this.Device.Name = "Device";
            this.Device.Width = 125;
            // 
            // Device_name
            // 
            this.Device_name.HeaderText = "Device_name";
            this.Device_name.MinimumWidth = 6;
            this.Device_name.Name = "Device_name";
            this.Device_name.Width = 125;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.MinimumWidth = 6;
            this.Currency.Name = "Currency";
            this.Currency.Width = 125;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.Width = 125;
            // 
            // Count_tranzac
            // 
            this.Count_tranzac.HeaderText = "Count_tranzac";
            this.Count_tranzac.MinimumWidth = 6;
            this.Count_tranzac.Name = "Count_tranzac";
            this.Count_tranzac.Width = 125;
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count_tranzac;
    }
}