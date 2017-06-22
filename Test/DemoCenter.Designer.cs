namespace Test
{
    partial class DemoCenter
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bt_ex_3_2 = new System.Windows.Forms.Button();
            this.bt_ex_3_3 = new System.Windows.Forms.Button();
            this.bt_ex_3_4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bt_ex_3_2);
            this.flowLayoutPanel1.Controls.Add(this.bt_ex_3_3);
            this.flowLayoutPanel1.Controls.Add(this.bt_ex_3_4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(89, 261);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // bt_ex_3_2
            // 
            this.bt_ex_3_2.Location = new System.Drawing.Point(3, 3);
            this.bt_ex_3_2.Name = "bt_ex_3_2";
            this.bt_ex_3_2.Size = new System.Drawing.Size(75, 23);
            this.bt_ex_3_2.TabIndex = 0;
            this.bt_ex_3_2.Text = "3.2";
            this.bt_ex_3_2.UseVisualStyleBackColor = true;
            this.bt_ex_3_2.Click += new System.EventHandler(this.bt_ex_3_2_Click);
            // 
            // bt_ex_3_3
            // 
            this.bt_ex_3_3.Location = new System.Drawing.Point(3, 32);
            this.bt_ex_3_3.Name = "bt_ex_3_3";
            this.bt_ex_3_3.Size = new System.Drawing.Size(75, 23);
            this.bt_ex_3_3.TabIndex = 1;
            this.bt_ex_3_3.Text = "3.3";
            this.bt_ex_3_3.UseVisualStyleBackColor = true;
            this.bt_ex_3_3.Click += new System.EventHandler(this.bt_ex_3_3_Click);
            // 
            // bt_ex_3_4
            // 
            this.bt_ex_3_4.Location = new System.Drawing.Point(3, 61);
            this.bt_ex_3_4.Name = "bt_ex_3_4";
            this.bt_ex_3_4.Size = new System.Drawing.Size(75, 23);
            this.bt_ex_3_4.TabIndex = 2;
            this.bt_ex_3_4.Text = "3.4";
            this.bt_ex_3_4.UseVisualStyleBackColor = true;
            this.bt_ex_3_4.Click += new System.EventHandler(this.bt_ex_3_4_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(89, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 261);
            this.panel1.TabIndex = 1;
            // 
            // DemoCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DemoCenter";
            this.Text = "DemoCenter";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bt_ex_3_2;
        private System.Windows.Forms.Button bt_ex_3_3;
        private System.Windows.Forms.Button bt_ex_3_4;
        private System.Windows.Forms.Panel panel1;
    }
}