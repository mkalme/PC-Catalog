namespace PC_Catalog
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Number of cores");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Socket");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Form Factor");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Memory Type");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Memory Modules");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Memory Amount");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("SSD");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("HDD");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("GPU");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("PSU Wattage");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("USB 2.0");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("USB 3.0");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Memory Slots");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Sata Ports");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("CPU Manufacturer");
            this.filterGlobal = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filterGlobal
            // 
            this.filterGlobal.CheckBoxes = true;
            this.filterGlobal.Location = new System.Drawing.Point(12, 46);
            this.filterGlobal.Name = "filterGlobal";
            treeNode1.Name = "cores";
            treeNode1.Text = "Number of cores";
            treeNode2.Name = "socket";
            treeNode2.Text = "Socket";
            treeNode3.Name = "formFactor";
            treeNode3.Text = "Form Factor";
            treeNode4.Name = "memoryType";
            treeNode4.Text = "Memory Type";
            treeNode5.Name = "memoryModule";
            treeNode5.Text = "Memory Modules";
            treeNode6.Name = "memoryAmount";
            treeNode6.Text = "Memory Amount";
            treeNode7.Name = "ssd";
            treeNode7.Text = "SSD";
            treeNode8.Name = "hdd";
            treeNode8.Text = "HDD";
            treeNode9.Name = "gpu";
            treeNode9.Text = "GPU";
            treeNode10.Name = "psuWattage";
            treeNode10.Text = "PSU Wattage";
            treeNode11.Name = "usb2";
            treeNode11.Text = "USB 2.0";
            treeNode12.Name = "usb3";
            treeNode12.Text = "USB 3.0";
            treeNode13.Name = "memorySlots";
            treeNode13.Text = "Memory Slots";
            treeNode14.Name = "sataPorts";
            treeNode14.Text = "Sata Ports";
            treeNode15.Name = "sataManu";
            treeNode15.Text = "CPU Manufacturer";
            this.filterGlobal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.filterGlobal.Size = new System.Drawing.Size(204, 570);
            this.filterGlobal.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(77, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(222, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(936, 570);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1063, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 628);
            this.Controls.Add(this.filterGlobal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC Catalog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView filterGlobal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
    }
}

