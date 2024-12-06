namespace Final_Project
{
    partial class Admin_Add_Products
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdH = new System.Windows.Forms.RadioButton();
            this.rdS = new System.Windows.Forms.RadioButton();
            this.txtWarranty = new System.Windows.Forms.TextBox();
            this.s = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlatform = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSub = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(400, 44);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 22);
            this.txtId.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(400, 95);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Id";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(400, 140);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 22);
            this.txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(400, 180);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Product Type";
            // 
            // rdH
            // 
            this.rdH.AutoSize = true;
            this.rdH.Location = new System.Drawing.Point(400, 229);
            this.rdH.Name = "rdH";
            this.rdH.Size = new System.Drawing.Size(87, 20);
            this.rdH.TabIndex = 9;
            this.rdH.TabStop = true;
            this.rdH.Text = "Hardware";
            this.rdH.UseVisualStyleBackColor = true;
            this.rdH.CheckedChanged += new System.EventHandler(this.rdH_CheckedChanged);
            // 
            // rdS
            // 
            this.rdS.AutoSize = true;
            this.rdS.Location = new System.Drawing.Point(559, 229);
            this.rdS.Name = "rdS";
            this.rdS.Size = new System.Drawing.Size(80, 20);
            this.rdS.TabIndex = 10;
            this.rdS.TabStop = true;
            this.rdS.Text = "Software";
            this.rdS.UseVisualStyleBackColor = true;
            this.rdS.CheckedChanged += new System.EventHandler(this.rdS_CheckedChanged);
            // 
            // txtWarranty
            // 
            this.txtWarranty.Location = new System.Drawing.Point(174, 363);
            this.txtWarranty.Name = "txtWarranty";
            this.txtWarranty.Size = new System.Drawing.Size(100, 22);
            this.txtWarranty.TabIndex = 16;
            this.txtWarranty.TextChanged += new System.EventHandler(this.txtWarranty_TextChanged);
            this.txtWarranty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWarranty_KeyPress);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Location = new System.Drawing.Point(49, 363);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(104, 16);
            this.s.TabIndex = 15;
            this.s.Text = "Warranty Period";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(174, 318);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(100, 22);
            this.txtSerial.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hardware Id";
            // 
            // txtHId
            // 
            this.txtHId.Location = new System.Drawing.Point(174, 267);
            this.txtHId.Name = "txtHId";
            this.txtHId.Size = new System.Drawing.Size(100, 22);
            this.txtHId.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Serial Number";
            // 
            // txtPlatform
            // 
            this.txtPlatform.Location = new System.Drawing.Point(539, 409);
            this.txtPlatform.Name = "txtPlatform";
            this.txtPlatform.Size = new System.Drawing.Size(100, 22);
            this.txtPlatform.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Platform";
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(539, 369);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(100, 22);
            this.txtLicense.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "License Type";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(539, 324);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(100, 22);
            this.txtVersion.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(414, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Software Id";
            // 
            // txtSId
            // 
            this.txtSId.Location = new System.Drawing.Point(539, 273);
            this.txtSId.Name = "txtSId";
            this.txtSId.Size = new System.Drawing.Size(100, 22);
            this.txtSId.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(414, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Version";
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(539, 488);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(100, 22);
            this.txtSub.TabIndex = 28;
            this.txtSub.TextChanged += new System.EventHandler(this.txtSub_TextChanged);
            this.txtSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSub_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "Subscription Period";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(539, 448);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(100, 22);
            this.txtFileSize.TabIndex = 26;
            this.txtFileSize.TextChanged += new System.EventHandler(this.txtFileSize_TextChanged);
            this.txtFileSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileSize_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(414, 448);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "File size";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(294, 537);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Admin_Add_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 579);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPlatform);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtWarranty);
            this.Controls.Add(this.s);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdS);
            this.Controls.Add(this.rdH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Name = "Admin_Add_Products";
            this.Text = "Admin_Add_Products";
            this.Load += new System.EventHandler(this.Admin_Add_Products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdH;
        private System.Windows.Forms.RadioButton rdS;
        private System.Windows.Forms.TextBox txtWarranty;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPlatform;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSave;
    }
}