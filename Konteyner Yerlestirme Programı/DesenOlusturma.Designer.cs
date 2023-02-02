namespace Konteyner_Yerlestirme_Programı
{
    partial class DesenOlusturma
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
            this.btnIbcDikey = new System.Windows.Forms.Button();
            this.btnIbcYatay = new System.Windows.Forms.Button();
            this.btnPalet1 = new System.Windows.Forms.Button();
            this.btnPalet4 = new System.Windows.Forms.Button();
            this.btnPalet2 = new System.Windows.Forms.Button();
            this.btnPalet3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIbcDikey
            // 
            this.btnIbcDikey.Location = new System.Drawing.Point(34, 29);
            this.btnIbcDikey.Name = "btnIbcDikey";
            this.btnIbcDikey.Size = new System.Drawing.Size(122, 82);
            this.btnIbcDikey.TabIndex = 0;
            this.btnIbcDikey.Text = "IBC Dikey";
            this.btnIbcDikey.UseVisualStyleBackColor = true;
            this.btnIbcDikey.Click += new System.EventHandler(this.btnIbcDikey_Click);
            // 
            // btnIbcYatay
            // 
            this.btnIbcYatay.Location = new System.Drawing.Point(162, 29);
            this.btnIbcYatay.Name = "btnIbcYatay";
            this.btnIbcYatay.Size = new System.Drawing.Size(122, 82);
            this.btnIbcYatay.TabIndex = 1;
            this.btnIbcYatay.Text = "IBC Yatay";
            this.btnIbcYatay.UseVisualStyleBackColor = true;
            this.btnIbcYatay.Click += new System.EventHandler(this.btnIbcYatay_Click);
            // 
            // btnPalet1
            // 
            this.btnPalet1.Location = new System.Drawing.Point(31, 26);
            this.btnPalet1.Name = "btnPalet1";
            this.btnPalet1.Size = new System.Drawing.Size(122, 82);
            this.btnPalet1.TabIndex = 2;
            this.btnPalet1.Text = "1. Varilli Palet";
            this.btnPalet1.UseVisualStyleBackColor = true;
            this.btnPalet1.Click += new System.EventHandler(this.btnPalet1_Click);
            // 
            // btnPalet4
            // 
            this.btnPalet4.Location = new System.Drawing.Point(159, 114);
            this.btnPalet4.Name = "btnPalet4";
            this.btnPalet4.Size = new System.Drawing.Size(122, 82);
            this.btnPalet4.TabIndex = 3;
            this.btnPalet4.Text = "4. Varilli Palet";
            this.btnPalet4.UseVisualStyleBackColor = true;
            this.btnPalet4.Click += new System.EventHandler(this.btnPalet4_Click);
            // 
            // btnPalet2
            // 
            this.btnPalet2.Location = new System.Drawing.Point(159, 26);
            this.btnPalet2.Name = "btnPalet2";
            this.btnPalet2.Size = new System.Drawing.Size(122, 82);
            this.btnPalet2.TabIndex = 4;
            this.btnPalet2.Text = "2.Varilli Palet";
            this.btnPalet2.UseVisualStyleBackColor = true;
            this.btnPalet2.Click += new System.EventHandler(this.btnPalet2_Click);
            // 
            // btnPalet3
            // 
            this.btnPalet3.Location = new System.Drawing.Point(31, 114);
            this.btnPalet3.Name = "btnPalet3";
            this.btnPalet3.Size = new System.Drawing.Size(122, 82);
            this.btnPalet3.TabIndex = 5;
            this.btnPalet3.Text = "3 Varilli Palet";
            this.btnPalet3.UseVisualStyleBackColor = true;
            this.btnPalet3.Click += new System.EventHandler(this.btnPalet3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIbcYatay);
            this.groupBox1.Controls.Add(this.btnIbcDikey);
            this.groupBox1.Location = new System.Drawing.Point(44, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IBC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPalet3);
            this.groupBox2.Controls.Add(this.btnPalet1);
            this.groupBox2.Controls.Add(this.btnPalet4);
            this.groupBox2.Controls.Add(this.btnPalet2);
            this.groupBox2.Location = new System.Drawing.Point(44, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 209);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PALET";
            // 
            // DesenOlusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DesenOlusturma";
            this.Text = "DesenOlusturma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIbcDikey;
        private System.Windows.Forms.Button btnIbcYatay;
        private System.Windows.Forms.Button btnPalet1;
        private System.Windows.Forms.Button btnPalet4;
        private System.Windows.Forms.Button btnPalet2;
        private System.Windows.Forms.Button btnPalet3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}