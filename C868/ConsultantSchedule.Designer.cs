
namespace C868
{
    partial class ConsultantSchedule
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
            this.Schedules_DGV = new System.Windows.Forms.DataGridView();
            this.consultantComboBox = new System.Windows.Forms.ComboBox();
            this.ReportButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Schedules_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor Schedules";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Schedules_DGV
            // 
            this.Schedules_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Schedules_DGV.Location = new System.Drawing.Point(67, 122);
            this.Schedules_DGV.Margin = new System.Windows.Forms.Padding(2);
            this.Schedules_DGV.Name = "Schedules_DGV";
            this.Schedules_DGV.RowHeadersWidth = 82;
            this.Schedules_DGV.RowTemplate.Height = 33;
            this.Schedules_DGV.Size = new System.Drawing.Size(668, 313);
            this.Schedules_DGV.TabIndex = 1;
            // 
            // consultantComboBox
            // 
            this.consultantComboBox.FormattingEnabled = true;
            this.consultantComboBox.Location = new System.Drawing.Point(164, 74);
            this.consultantComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.consultantComboBox.Name = "consultantComboBox";
            this.consultantComboBox.Size = new System.Drawing.Size(214, 23);
            this.consultantComboBox.TabIndex = 2;
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.ReportButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ReportButton.Location = new System.Drawing.Point(433, 65);
            this.ReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(85, 37);
            this.ReportButton.TabIndex = 3;
            this.ReportButton.Text = "Get Report";
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BackButton.Location = new System.Drawing.Point(582, 65);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(85, 37);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ConsultantSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 496);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.consultantComboBox);
            this.Controls.Add(this.Schedules_DGV);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConsultantSchedule";
            this.Text = "Doctor Schedules";
            ((System.ComponentModel.ISupportInitialize)(this.Schedules_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Schedules_DGV;
        private System.Windows.Forms.ComboBox consultantComboBox;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Button BackButton;
    }
}