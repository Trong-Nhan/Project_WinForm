﻿
namespace Project_1
{
    partial class frmTour
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTour = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtTourTime = new System.Windows.Forms.TextBox();
            this.txtDescrible = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDestinations = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.errField = new System.Windows.Forms.ErrorProvider(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cboVehicle = new System.Windows.Forms.ComboBox();
            this.cboTourType = new System.Windows.Forms.ComboBox();
            this.cboTourGuide = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errField)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Thời gian";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Mô tả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Giá tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(546, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Điểm đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Tên Tour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mã Tour";
            // 
            // dgvTour
            // 
            this.dgvTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTour.Location = new System.Drawing.Point(3, 285);
            this.dgvTour.Name = "dgvTour";
            this.dgvTour.Size = new System.Drawing.Size(964, 183);
            this.dgvTour.TabIndex = 38;
            this.dgvTour.Click += new System.EventHandler(this.dgvTour_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(644, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(523, 256);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(384, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Lưu/Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(252, 256);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTourTime
            // 
            this.txtTourTime.Location = new System.Drawing.Point(77, 167);
            this.txtTourTime.Name = "txtTourTime";
            this.txtTourTime.Size = new System.Drawing.Size(201, 20);
            this.txtTourTime.TabIndex = 29;
            // 
            // txtDescrible
            // 
            this.txtDescrible.Location = new System.Drawing.Point(373, 125);
            this.txtDescrible.Multiline = true;
            this.txtDescrible.Name = "txtDescrible";
            this.txtDescrible.Size = new System.Drawing.Size(574, 62);
            this.txtDescrible.TabIndex = 28;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(77, 125);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(201, 20);
            this.txtPrice.TabIndex = 27;
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(294, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 20);
            this.txtName.TabIndex = 26;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(77, 85);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(125, 20);
            this.txtId.TabIndex = 25;
            // 
            // txtDestinations
            // 
            this.txtDestinations.Location = new System.Drawing.Point(609, 85);
            this.txtDestinations.Name = "txtDestinations";
            this.txtDestinations.Size = new System.Drawing.Size(338, 20);
            this.txtDestinations.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Phương tiện di chuyển";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Loại Tour";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(627, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Hướng dẫn viên";
            // 
            // errField
            // 
            this.errField.ContainerControl = this;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(343, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(255, 31);
            this.label10.TabIndex = 53;
            this.label10.Text = "Quản lý Tour du lịch";
            // 
            // cboVehicle
            // 
            this.cboVehicle.FormattingEnabled = true;
            this.cboVehicle.Location = new System.Drawing.Point(136, 214);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Size = new System.Drawing.Size(142, 21);
            this.cboVehicle.TabIndex = 54;
            this.cboVehicle.Click += new System.EventHandler(this.cboVehicle_Click);
            // 
            // cboTourType
            // 
            this.cboTourType.FormattingEnabled = true;
            this.cboTourType.Location = new System.Drawing.Point(428, 214);
            this.cboTourType.Name = "cboTourType";
            this.cboTourType.Size = new System.Drawing.Size(118, 21);
            this.cboTourType.TabIndex = 55;
            this.cboTourType.Click += new System.EventHandler(this.cboTourType_Click);
            // 
            // cboTourGuide
            // 
            this.cboTourGuide.FormattingEnabled = true;
            this.cboTourGuide.Location = new System.Drawing.Point(716, 214);
            this.cboTourGuide.Name = "cboTourGuide";
            this.cboTourGuide.Size = new System.Drawing.Size(169, 21);
            this.cboTourGuide.TabIndex = 56;
            this.cboTourGuide.Click += new System.EventHandler(this.cboTourGuide_Click);
            // 
            // frmTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 471);
            this.Controls.Add(this.cboTourGuide);
            this.Controls.Add(this.cboTourType);
            this.Controls.Add(this.cboVehicle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestinations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTour);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtTourTime);
            this.Controls.Add(this.txtDescrible);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Name = "frmTour";
            this.Text = "Ứng dụng quản lý khách đi du lịch";
            this.Load += new System.EventHandler(this.frmTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTour;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtTourTime;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDestinations;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDescrible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errField;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTourGuide;
        private System.Windows.Forms.ComboBox cboTourType;
        private System.Windows.Forms.ComboBox cboVehicle;
    }
}