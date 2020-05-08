namespace Report_system
{
    partial class frm_Read
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Read));
            this.button_Close = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Name_of_form = new System.Windows.Forms.Label();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.button_Read = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.reportSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_SystemDataSet = new Report_system.Report_SystemDataSet();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Read_Directory = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Depth = 0;
            this.button_Close.Location = new System.Drawing.Point(1080, 6);
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
            this.panel1.Controls.Add(this.button_Read_Directory);
            this.panel1.Controls.Add(this.label_Name_of_form);
            this.panel1.Controls.Add(this.pb_Status);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.button_Read);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 667);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_Name_of_form
            // 
            this.label_Name_of_form.AutoSize = true;
            this.label_Name_of_form.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name_of_form.Location = new System.Drawing.Point(457, 6);
            this.label_Name_of_form.Name = "label_Name_of_form";
            this.label_Name_of_form.Size = new System.Drawing.Size(531, 43);
            this.label_Name_of_form.TabIndex = 13;
            this.label_Name_of_form.Text = "Добавление отчета в систему";
            // 
            // pb_Status
            // 
            this.pb_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.pb_Status.Location = new System.Drawing.Point(465, 64);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(360, 23);
            this.pb_Status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_Status.TabIndex = 8;
            this.pb_Status.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(12, 13);
            this.lblName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(158, 24);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Название файла";
            // 
            // button_Read
            // 
            this.button_Read.Depth = 0;
            this.button_Read.Location = new System.Drawing.Point(118, 202);
            this.button_Read.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Read.Name = "button_Read";
            this.button_Read.Primary = true;
            this.button_Read.Size = new System.Drawing.Size(351, 39);
            this.button_Read.TabIndex = 2;
            this.button_Read.Text = "Считать файл";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1237, 667);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
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
            // button_Read_Directory
            // 
            this.button_Read_Directory.Depth = 0;
            this.button_Read_Directory.Location = new System.Drawing.Point(768, 202);
            this.button_Read_Directory.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Read_Directory.Name = "button_Read_Directory";
            this.button_Read_Directory.Primary = true;
            this.button_Read_Directory.Size = new System.Drawing.Size(351, 39);
            this.button_Read_Directory.TabIndex = 14;
            this.button_Read_Directory.Text = "Считать папку";
            this.button_Read_Directory.UseVisualStyleBackColor = true;
            this.button_Read_Directory.Click += new System.EventHandler(this.button_Read_Directory_Click);
            // 
            // frm_Read
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1237, 667);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Read";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSystemDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_SystemDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton button_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private System.Windows.Forms.BindingSource reportSystemDataSetBindingSource;
        private Report_SystemDataSet report_SystemDataSet;
        private MaterialSkin.Controls.MaterialRaisedButton button_Read;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.Label label_Name_of_form;
        private MaterialSkin.Controls.MaterialRaisedButton button_Read_Directory;
    }
}