﻿namespace Report_system
{
    partial class Frm_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Home));
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Settings = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel_Prognoz = new System.Windows.Forms.Panel();
            this.button_Prognoz = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelStatistika = new System.Windows.Forms.Panel();
            this.button_Statistika = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelRegularSubMenu = new System.Windows.Forms.Panel();
            this.button_Show_List_Reports = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_Generation = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMakeRegularReport = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnClose = new MaterialSkin.Controls.MaterialFlatButton();
            this.panelRegular = new System.Windows.Forms.Panel();
            this.btnRegular = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelHead = new System.Windows.Forms.Panel();
            this.panelAll.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSubMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Prognoz.SuspendLayout();
            this.panelStatistika.SuspendLayout();
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
            this.panelAll.Size = new System.Drawing.Size(1005, 760);
            this.panelAll.TabIndex = 0;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.White;
            this.panelChildForm.Controls.Add(this.pictureBox2);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 32);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(755, 728);
            this.panelChildForm.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(755, 728);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.panelSubMenu.Controls.Add(this.panel1);
            this.panelSubMenu.Controls.Add(this.panel_Prognoz);
            this.panelSubMenu.Controls.Add(this.panelStatistika);
            this.panelSubMenu.Controls.Add(this.panelRegularSubMenu);
            this.panelSubMenu.Controls.Add(this.btnClose);
            this.panelSubMenu.Controls.Add(this.panelRegular);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 32);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(250, 728);
            this.panelSubMenu.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Settings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 378);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 68);
            this.panel1.TabIndex = 10;
            // 
            // button_Settings
            // 
            this.button_Settings.Depth = 0;
            this.button_Settings.FlatAppearance.BorderSize = 0;
            this.button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Settings.Location = new System.Drawing.Point(0, 6);
            this.button_Settings.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Primary = true;
            this.button_Settings.Size = new System.Drawing.Size(250, 56);
            this.button_Settings.TabIndex = 6;
            this.button_Settings.Text = "Настройки";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // panel_Prognoz
            // 
            this.panel_Prognoz.Controls.Add(this.button_Prognoz);
            this.panel_Prognoz.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Prognoz.Location = new System.Drawing.Point(0, 310);
            this.panel_Prognoz.Name = "panel_Prognoz";
            this.panel_Prognoz.Size = new System.Drawing.Size(250, 68);
            this.panel_Prognoz.TabIndex = 9;
            // 
            // button_Prognoz
            // 
            this.button_Prognoz.Depth = 0;
            this.button_Prognoz.FlatAppearance.BorderSize = 0;
            this.button_Prognoz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Prognoz.Location = new System.Drawing.Point(0, 6);
            this.button_Prognoz.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Prognoz.Name = "button_Prognoz";
            this.button_Prognoz.Primary = true;
            this.button_Prognoz.Size = new System.Drawing.Size(250, 56);
            this.button_Prognoz.TabIndex = 6;
            this.button_Prognoz.Text = "Прогнозирование";
            this.button_Prognoz.UseVisualStyleBackColor = true;
            this.button_Prognoz.Click += new System.EventHandler(this.button_Prognoz_Click);
            // 
            // panelStatistika
            // 
            this.panelStatistika.Controls.Add(this.button_Statistika);
            this.panelStatistika.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatistika.Location = new System.Drawing.Point(0, 245);
            this.panelStatistika.Name = "panelStatistika";
            this.panelStatistika.Size = new System.Drawing.Size(250, 65);
            this.panelStatistika.TabIndex = 7;
            // 
            // button_Statistika
            // 
            this.button_Statistika.Depth = 0;
            this.button_Statistika.FlatAppearance.BorderSize = 0;
            this.button_Statistika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Statistika.Location = new System.Drawing.Point(0, 3);
            this.button_Statistika.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Statistika.Name = "button_Statistika";
            this.button_Statistika.Primary = true;
            this.button_Statistika.Size = new System.Drawing.Size(250, 56);
            this.button_Statistika.TabIndex = 5;
            this.button_Statistika.Text = "Статистика";
            this.button_Statistika.UseVisualStyleBackColor = true;
            this.button_Statistika.Click += new System.EventHandler(this.button_Statistika_Click);
            // 
            // panelRegularSubMenu
            // 
            this.panelRegularSubMenu.Controls.Add(this.button_Show_List_Reports);
            this.panelRegularSubMenu.Controls.Add(this.btn_Generation);
            this.panelRegularSubMenu.Controls.Add(this.btnMakeRegularReport);
            this.panelRegularSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegularSubMenu.Location = new System.Drawing.Point(0, 103);
            this.panelRegularSubMenu.Name = "panelRegularSubMenu";
            this.panelRegularSubMenu.Size = new System.Drawing.Size(250, 142);
            this.panelRegularSubMenu.TabIndex = 4;
            // 
            // button_Show_List_Reports
            // 
            this.button_Show_List_Reports.Depth = 0;
            this.button_Show_List_Reports.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Show_List_Reports.FlatAppearance.BorderSize = 0;
            this.button_Show_List_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Show_List_Reports.Location = new System.Drawing.Point(0, 80);
            this.button_Show_List_Reports.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_Show_List_Reports.Name = "button_Show_List_Reports";
            this.button_Show_List_Reports.Primary = true;
            this.button_Show_List_Reports.Size = new System.Drawing.Size(250, 39);
            this.button_Show_List_Reports.TabIndex = 2;
            this.button_Show_List_Reports.Text = "Просмотр списка отчетов";
            this.button_Show_List_Reports.UseVisualStyleBackColor = true;
            this.button_Show_List_Reports.Click += new System.EventHandler(this.button_Show_List_Reports_Click);
            // 
            // btn_Generation
            // 
            this.btn_Generation.Depth = 0;
            this.btn_Generation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Generation.FlatAppearance.BorderSize = 0;
            this.btn_Generation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Generation.Location = new System.Drawing.Point(0, 40);
            this.btn_Generation.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Generation.Name = "btn_Generation";
            this.btn_Generation.Primary = true;
            this.btn_Generation.Size = new System.Drawing.Size(250, 40);
            this.btn_Generation.TabIndex = 1;
            this.btn_Generation.Text = "Формирование";
            this.btn_Generation.UseVisualStyleBackColor = true;
            this.btn_Generation.Click += new System.EventHandler(this.btn_Generation_Click);
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
            this.btnMakeRegularReport.Text = "Считывание отчётов";
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
            this.btnClose.Location = new System.Drawing.Point(0, 692);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = false;
            this.btnClose.Size = new System.Drawing.Size(250, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelRegular
            // 
            this.panelRegular.Controls.Add(this.btnRegular);
            this.panelRegular.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegular.Location = new System.Drawing.Point(0, 0);
            this.panelRegular.Name = "panelRegular";
            this.panelRegular.Size = new System.Drawing.Size(250, 103);
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
            this.btnRegular.Text = "Отчёты";
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
            this.panelHead.Size = new System.Drawing.Size(1005, 32);
            this.panelHead.TabIndex = 9;
            // 
            // Frm_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 760);
            this.Controls.Add(this.panelAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Frm_Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система предоставления отчётности по банковским платёжным картам";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAll.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSubMenu.ResumeLayout(false);
            this.panelSubMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_Prognoz.ResumeLayout(false);
            this.panelStatistika.ResumeLayout(false);
            this.panelRegularSubMenu.ResumeLayout(false);
            this.panelRegular.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelSubMenu;
        private MaterialSkin.Controls.MaterialFlatButton btnClose;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panelRegularSubMenu;
        private System.Windows.Forms.Panel panelRegular;
        private MaterialSkin.Controls.MaterialRaisedButton btnRegular;
        private MaterialSkin.Controls.MaterialRaisedButton btnMakeRegularReport;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Generation;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialRaisedButton button_Show_List_Reports;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Panel panelStatistika;
        private MaterialSkin.Controls.MaterialRaisedButton button_Statistika;
        private MaterialSkin.Controls.MaterialRaisedButton button_Prognoz;
        private System.Windows.Forms.Panel panel_Prognoz;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRaisedButton button_Settings;
    }
}

