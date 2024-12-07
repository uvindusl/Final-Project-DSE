namespace Final_Project
{
    partial class Sales_Person_Quotation
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
            this.btnsavetodatabse = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txttotaldiscount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numaricqunatity = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.combocname = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtsubdicount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtqid = new System.Windows.Forms.TextBox();
            this.comboproduct = new System.Windows.Forms.ComboBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnprint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numaricqunatity)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsavetodatabse
            // 
            this.btnsavetodatabse.Location = new System.Drawing.Point(1198, 568);
            this.btnsavetodatabse.Name = "btnsavetodatabse";
            this.btnsavetodatabse.Size = new System.Drawing.Size(75, 23);
            this.btnsavetodatabse.TabIndex = 71;
            this.btnsavetodatabse.Text = "Save";
            this.btnsavetodatabse.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(1312, 568);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 70;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            // 
            // txttotaldiscount
            // 
            this.txttotaldiscount.Location = new System.Drawing.Point(1183, 482);
            this.txttotaldiscount.Name = "txttotaldiscount";
            this.txttotaldiscount.ReadOnly = true;
            this.txttotaldiscount.Size = new System.Drawing.Size(188, 20);
            this.txttotaldiscount.TabIndex = 69;
            this.txttotaldiscount.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1015, 531);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 68;
            this.label16.Text = "Net Total";
            // 
            // txttotalamount
            // 
            this.txttotalamount.Location = new System.Drawing.Point(1183, 524);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.ReadOnly = true;
            this.txttotalamount.Size = new System.Drawing.Size(188, 20);
            this.txttotalamount.TabIndex = 67;
            this.txttotalamount.Text = "0.00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1015, 485);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 66;
            this.label17.Text = "Net Discount";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(879, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 397);
            this.dataGridView1.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(832, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(261, 25);
            this.label8.TabIndex = 64;
            this.label8.Text = "Sales Person Quotation";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.txtdiscount);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtsubtotal);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.numaricqunatity);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.combocname);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtsubdicount);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtqid);
            this.panel3.Controls.Add(this.comboproduct);
            this.panel3.Controls.Add(this.txtprice);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(329, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 397);
            this.panel3.TabIndex = 63;
            // 
            // txtdiscount
            // 
            this.txtdiscount.Location = new System.Drawing.Point(248, 207);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(188, 20);
            this.txtdiscount.TabIndex = 42;
            this.txtdiscount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Discount (Optional)";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(248, 328);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(188, 20);
            this.txtsubtotal.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Sub Total";
            // 
            // numaricqunatity
            // 
            this.numaricqunatity.Location = new System.Drawing.Point(250, 243);
            this.numaricqunatity.Name = "numaricqunatity";
            this.numaricqunatity.Size = new System.Drawing.Size(130, 20);
            this.numaricqunatity.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // combocname
            // 
            this.combocname.FormattingEnabled = true;
            this.combocname.Location = new System.Drawing.Point(250, 78);
            this.combocname.Name = "combocname";
            this.combocname.Size = new System.Drawing.Size(186, 21);
            this.combocname.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(76, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Quotation Id";
            // 
            // txtsubdicount
            // 
            this.txtsubdicount.Location = new System.Drawing.Point(248, 283);
            this.txtsubdicount.Name = "txtsubdicount";
            this.txtsubdicount.ReadOnly = true;
            this.txtsubdicount.Size = new System.Drawing.Size(188, 20);
            this.txtsubdicount.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 286);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Sub Discount";
            // 
            // txtqid
            // 
            this.txtqid.Location = new System.Drawing.Point(248, 36);
            this.txtqid.Name = "txtqid";
            this.txtqid.ReadOnly = true;
            this.txtqid.Size = new System.Drawing.Size(188, 20);
            this.txtqid.TabIndex = 26;
            // 
            // comboproduct
            // 
            this.comboproduct.FormattingEnabled = true;
            this.comboproduct.Location = new System.Drawing.Point(248, 123);
            this.comboproduct.Name = "comboproduct";
            this.comboproduct.Size = new System.Drawing.Size(188, 21);
            this.comboproduct.TabIndex = 31;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(248, 167);
            this.txtprice.Name = "txtprice";
            this.txtprice.ReadOnly = true;
            this.txtprice.Size = new System.Drawing.Size(188, 20);
            this.txtprice.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Quantity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Customer Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Product";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 632);
            this.panel1.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Desktop;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(143, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Products";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Desktop;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(143, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inventory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Desktop;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(143, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(143, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employees";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(43, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 10);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Final_Project.Properties.Resources.WhatsApp_Image_2024_11_07_at_09_30_23_20f03f32_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(39, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 86);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(1092, 569);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 23);
            this.btnprint.TabIndex = 61;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // Sales_Person_Quotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 606);
            this.Controls.Add(this.btnsavetodatabse);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.txttotaldiscount);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txttotalamount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnprint);
            this.Name = "Sales_Person_Quotation";
            this.Text = "Sales Person Quotation";
            this.Load += new System.EventHandler(this.Sales_Person_Quotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numaricqunatity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsavetodatabse;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txttotaldiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numaricqunatity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combocname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtsubdicount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtqid;
        private System.Windows.Forms.ComboBox comboproduct;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnprint;
    }
}