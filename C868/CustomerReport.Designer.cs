
namespace C868
{
    partial class CustomerReport
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
            this.CWA_DGV = new System.Windows.Forms.DataGridView();
            this.Close_bttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CWA_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patients with Appointments";
            // 
            // CWA_DGV
            // 
            this.CWA_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CWA_DGV.Location = new System.Drawing.Point(71, 113);
            this.CWA_DGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CWA_DGV.Name = "CWA_DGV";
            this.CWA_DGV.RowHeadersWidth = 82;
            this.CWA_DGV.RowTemplate.Height = 33;
            this.CWA_DGV.Size = new System.Drawing.Size(437, 325);
            this.CWA_DGV.TabIndex = 1;
            // 
            // Close_bttn
            // 
            this.Close_bttn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Close_bttn.ForeColor = System.Drawing.SystemColors.Control;
            this.Close_bttn.Location = new System.Drawing.Point(497, 455);
            this.Close_bttn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Close_bttn.Name = "Close_bttn";
            this.Close_bttn.Size = new System.Drawing.Size(67, 32);
            this.Close_bttn.TabIndex = 2;
            this.Close_bttn.Text = "Back";
            this.Close_bttn.UseVisualStyleBackColor = false;
            this.Close_bttn.Click += new System.EventHandler(this.Close_bttn_Click);
            // 
            // CustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 494);
            this.Controls.Add(this.Close_bttn);
            this.Controls.Add(this.CWA_DGV);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerReport";
            this.Text = "Patient Report";
            this.Load += new System.EventHandler(this.CustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CWA_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CWA_DGV;
        private System.Windows.Forms.Button Close_bttn;
    }
}