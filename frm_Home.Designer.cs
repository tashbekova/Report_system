namespace Report_system
{
    partial class frm_Home
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Home));
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.panelRequestSubMenu = new System.Windows.Forms.Panel();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton4 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelRequest = new System.Windows.Forms.Panel();
            this.btnRequest = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelRegularSubMenu = new System.Windows.Forms.Panel();
            this.btnSchedule = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMakeRegularReport = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnClose = new MaterialSkin.Controls.MaterialFlatButton();
            this.panelRegular = new System.Windows.Forms.Panel();
            this.btnRegular = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelHead = new System.Windows.Forms.Panel();
            this.panelAll.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSubMenu.SuspendLayout();
            this.panelRequestSubMenu.SuspendLayout();
            this.panelRequest.SuspendLayout();
            this.panelRegularSubMenu.SuspendLayout();
            this.panelRegular.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelChildForm);
            this.panelAll.Controls.Add(this.panelSubMenu);
            this.panelAll.Controls.Add(this.panelHead);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(996, 650);
            this.panelAll.TabIndex = 0;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.White;
            this.panelChildForm.Controls.Add(this.pictureBox2);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 32);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(746, 618);
            this.panelChildForm.TabIndex = 8;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(746, 618);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.panelSubMenu.Controls.Add(this.panelRequestSubMenu);
            this.panelSubMenu.Controls.Add(this.panelRequest);
            this.panelSubMenu.Controls.Add(this.panelRegularSubMenu);
            this.panelSubMenu.Controls.Add(this.btnClose);
            this.panelSubMenu.Controls.Add(this.panelRegular);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 32);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(250, 618);
            this.panelSubMenu.TabIndex = 7;
            this.panelSubMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSubMenu_Paint);
            // 
            // panelRequestSubMenu
            // 
            this.panelRequestSubMenu.Controls.Add(this.materialRaisedButton3);
            this.panelRequestSubMenu.Controls.Add(this.materialRaisedButton4);
            this.panelRequestSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRequestSubMenu.Location = new System.Drawing.Point(0, 266);
            this.panelRequestSubMenu.Name = "panelRequestSubMenu";
            this.panelRequestSubMenu.Size = new System.Drawing.Size(250, 90);
            this.panelRequestSubMenu.TabIndex = 6;
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialRaisedButton3.FlatAppearance.BorderSize = 0;
            this.materialRaisedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialRaisedButton3.Location = new System.Drawing.Point(0, 40);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(250, 40);
            this.materialRaisedButton3.TabIndex = 1;
            this.materialRaisedButton3.Text = "Расписание";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            // 
            // materialRaisedButton4
            // 
            this.materialRaisedButton4.Depth = 0;
            this.materialRaisedButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialRaisedButton4.FlatAppearance.BorderSize = 0;
            this.materialRaisedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialRaisedButton4.Location = new System.Drawing.Point(0, 0);
            this.materialRaisedButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton4.Name = "materialRaisedButton4";
            this.materialRaisedButton4.Primary = true;
            this.materialRaisedButton4.Size = new System.Drawing.Size(250, 40);
            this.materialRaisedButton4.TabIndex = 0;
            this.materialRaisedButton4.Text = "Отчёт для Нац.Банка";
            this.materialRaisedButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialRaisedButton4.UseVisualStyleBackColor = true;
            // 
            // panelRequest
            // 
            this.panelRequest.Controls.Add(this.btnRequest);
            this.panelRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRequest.Location = new System.Drawing.Point(0, 201);
            this.panelRequest.Name = "panelRequest";
            this.panelRequest.Size = new System.Drawing.Size(250, 65);
            this.panelRequest.TabIndex = 5;
            // 
            // btnRequest
            // 
            this.btnRequest.Depth = 0;
            this.btnRequest.FlatAppearance.BorderSize = 0;
            this.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequest.Location = new System.Drawing.Point(0, 0);
            this.btnRequest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Primary = true;
            this.btnRequest.Size = new System.Drawing.Size(250, 56);
            this.btnRequest.TabIndex = 4;
            this.btnRequest.Text = "Отчёты по запросу";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // panelRegularSubMenu
            // 
            this.panelRegularSubMenu.Controls.Add(this.btnSchedule);
            this.panelRegularSubMenu.Controls.Add(this.btnMakeRegularReport);
            this.panelRegularSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegularSubMenu.Location = new System.Drawing.Point(0, 109);
            this.panelRegularSubMenu.Name = "panelRegularSubMenu";
            this.panelRegularSubMenu.Size = new System.Drawing.Size(250, 92);
            this.panelRegularSubMenu.TabIndex = 4;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Depth = 0;
            this.btnSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Location = new System.Drawing.Point(0, 40);
            this.btnSchedule.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Primary = true;
            this.btnSchedule.Size = new System.Drawing.Size(250, 40);
            this.btnSchedule.TabIndex = 1;
            this.btnSchedule.Text = "Расписание";
            this.btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnMakeRegularReport
            // 
            this.btnMakeRegularReport.Depth = 0;
            this.btnMakeRegularReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMakeRegularReport.FlatAppearance.BorderSize = 0;
            this.btnMakeRegularReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeRegularReport.Location = new System.Drawing.Point(0, 0);
            this.btnMakeRegularReport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMakeRegularReport.Name = "btnMakeRegularReport";
            this.btnMakeRegularReport.Primary = true;
            this.btnMakeRegularReport.Size = new System.Drawing.Size(250, 40);
            this.btnMakeRegularReport.TabIndex = 0;
            this.btnMakeRegularReport.Text = "Формирование";
            this.btnMakeRegularReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMakeRegularReport.UseVisualStyleBackColor = true;
            this.btnMakeRegularReport.Click += new System.EventHandler(this.btnMakeRegularReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Depth = 0;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(0, 582);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = false;
            this.btnClose.Size = new System.Drawing.Size(250, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panelRegular
            // 
            this.panelRegular.Controls.Add(this.btnRegular);
            this.panelRegular.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegular.Location = new System.Drawing.Point(0, 0);
            this.panelRegular.Name = "panelRegular";
            this.panelRegular.Size = new System.Drawing.Size(250, 109);
            this.panelRegular.TabIndex = 1;
            // 
            // btnRegular
            // 
            this.btnRegular.Depth = 0;
            this.btnRegular.FlatAppearance.BorderSize = 0;
            this.btnRegular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegular.Location = new System.Drawing.Point(-1, 39);
            this.btnRegular.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegular.Name = "btnRegular";
            this.btnRegular.Primary = true;
            this.btnRegular.Size = new System.Drawing.Size(251, 56);
            this.btnRegular.TabIndex = 3;
            this.btnRegular.Text = "Регулярные отчёты";
            this.btnRegular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegular.UseVisualStyleBackColor = true;
            this.btnRegular.Click += new System.EventHandler(this.btnRegular_Click_1);
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(996, 32);
            this.panelHead.TabIndex = 9;
            // 
            // frm_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 650);
            this.Controls.Add(this.panelAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "frm_Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система предоставления отчётности по банковским платёжным картам";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAll.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSubMenu.ResumeLayout(false);
            this.panelSubMenu.PerformLayout();
            this.panelRequestSubMenu.ResumeLayout(false);
            this.panelRequest.ResumeLayout(false);
            this.panelRegularSubMenu.ResumeLayout(false);
            this.panelRegular.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelSubMenu;
        private MaterialSkin.Controls.MaterialFlatButton btnClose;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelRegularSubMenu;
        private System.Windows.Forms.Panel panelRegular;
        private System.Windows.Forms.Panel panelRequest;
        private MaterialSkin.Controls.MaterialRaisedButton btnRegular;
        private MaterialSkin.Controls.MaterialRaisedButton btnMakeRegularReport;
        private MaterialSkin.Controls.MaterialRaisedButton btnSchedule;
        private MaterialSkin.Controls.MaterialRaisedButton btnRequest;
        private System.Windows.Forms.Panel panelRequestSubMenu;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton4;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

