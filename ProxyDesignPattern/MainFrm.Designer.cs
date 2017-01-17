namespace ProxyDesignPattern
{
    partial class MainFrm
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
            this.callServiceBTN = new System.Windows.Forms.Button();
            this.refreshBTN = new System.Windows.Forms.Button();
            this.resultLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // callServiceBTN
            // 
            this.callServiceBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.callServiceBTN.Location = new System.Drawing.Point(47, 41);
            this.callServiceBTN.Name = "callServiceBTN";
            this.callServiceBTN.Size = new System.Drawing.Size(300, 55);
            this.callServiceBTN.TabIndex = 0;
            this.callServiceBTN.Text = "Call Service";
            this.callServiceBTN.UseVisualStyleBackColor = true;
            this.callServiceBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshBTN
            // 
            this.refreshBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.refreshBTN.Location = new System.Drawing.Point(47, 251);
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(300, 55);
            this.refreshBTN.TabIndex = 1;
            this.refreshBTN.Text = "Refresh";
            this.refreshBTN.UseVisualStyleBackColor = true;
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // resultLBL
            // 
            this.resultLBL.AutoSize = true;
            this.resultLBL.Font = new System.Drawing.Font("Tahoma", 18F);
            this.resultLBL.Location = new System.Drawing.Point(55, 163);
            this.resultLBL.Name = "resultLBL";
            this.resultLBL.Size = new System.Drawing.Size(0, 29);
            this.resultLBL.TabIndex = 2;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 342);
            this.Controls.Add(this.resultLBL);
            this.Controls.Add(this.refreshBTN);
            this.Controls.Add(this.callServiceBTN);
            this.Name = "MainFrm";
            this.Text = "Proxy Design Pattern";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button callServiceBTN;
        private System.Windows.Forms.Button refreshBTN;
        private System.Windows.Forms.Label resultLBL;
    }
}

