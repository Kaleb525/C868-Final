
namespace C868
{
    partial class AddAppointment
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.typeCombobox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.Con_Box = new System.Windows.Forms.TextBox();
            this.Loc_Box = new System.Windows.Forms.TextBox();
            this.Desc_Box = new System.Windows.Forms.TextBox();
            this.Title_Box = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.createCusButton = new System.Windows.Forms.Button();
            this.custLabel = new System.Windows.Forms.Label();
            this.custComboBox = new System.Windows.Forms.ComboBox();
            this.docComboBox = new System.Windows.Forms.ComboBox();
            this.Doctor_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeCombobox
            // 
            this.typeCombobox.FormattingEnabled = true;
            this.typeCombobox.Items.AddRange(new object[] {
            "Event",
            "Follow Up",
            "Initial Consultation",
            "Lab Visit",
            "Other",
            "Physical",
            "Surgery"});
            this.typeCombobox.Location = new System.Drawing.Point(207, 337);
            this.typeCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.typeCombobox.Name = "typeCombobox";
            this.typeCombobox.Size = new System.Drawing.Size(223, 23);
            this.typeCombobox.TabIndex = 73;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(319, 510);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 36);
            this.cancelButton.TabIndex = 72;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(94, 450);
            this.endLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(59, 15);
            this.endLabel.TabIndex = 71;
            this.endLabel.Text = "End Time:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(94, 394);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(63, 15);
            this.startLabel.TabIndex = 70;
            this.startLabel.Text = "Start Time:";
            // 
            // endDTP
            // 
            this.endDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDTP.Location = new System.Drawing.Point(207, 444);
            this.endDTP.Margin = new System.Windows.Forms.Padding(4);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(223, 23);
            this.endDTP.TabIndex = 69;
            // 
            // startDTP
            // 
            this.startDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDTP.Location = new System.Drawing.Point(207, 387);
            this.startDTP.Margin = new System.Windows.Forms.Padding(4);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(223, 23);
            this.startDTP.TabIndex = 68;
            // 
            // Con_Box
            // 
            this.Con_Box.Location = new System.Drawing.Point(207, 294);
            this.Con_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Con_Box.Name = "Con_Box";
            this.Con_Box.Size = new System.Drawing.Size(223, 23);
            this.Con_Box.TabIndex = 67;
            // 
            // Loc_Box
            // 
            this.Loc_Box.Location = new System.Drawing.Point(207, 254);
            this.Loc_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Loc_Box.Name = "Loc_Box";
            this.Loc_Box.Size = new System.Drawing.Size(223, 23);
            this.Loc_Box.TabIndex = 66;
            // 
            // Desc_Box
            // 
            this.Desc_Box.Location = new System.Drawing.Point(207, 176);
            this.Desc_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Desc_Box.Multiline = true;
            this.Desc_Box.Name = "Desc_Box";
            this.Desc_Box.Size = new System.Drawing.Size(223, 59);
            this.Desc_Box.TabIndex = 65;
            // 
            // Title_Box
            // 
            this.Title_Box.Location = new System.Drawing.Point(207, 131);
            this.Title_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Title_Box.MaxLength = 255;
            this.Title_Box.Name = "Title_Box";
            this.Title_Box.Size = new System.Drawing.Size(223, 23);
            this.Title_Box.TabIndex = 64;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(94, 337);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 15);
            this.typeLabel.TabIndex = 63;
            this.typeLabel.Text = "Type:";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Location = new System.Drawing.Point(94, 297);
            this.contactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(52, 15);
            this.contactLabel.TabIndex = 62;
            this.contactLabel.Text = "Contact:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(94, 258);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(56, 15);
            this.locationLabel.TabIndex = 61;
            this.locationLabel.Text = "Location:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(94, 176);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(70, 15);
            this.descriptionLabel.TabIndex = 60;
            this.descriptionLabel.Text = "Description:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(94, 131);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(32, 15);
            this.titleLabel.TabIndex = 59;
            this.titleLabel.Text = "Title:";
            // 
            // createCusButton
            // 
            this.createCusButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.createCusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createCusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createCusButton.ForeColor = System.Drawing.SystemColors.Control;
            this.createCusButton.Location = new System.Drawing.Point(97, 510);
            this.createCusButton.Margin = new System.Windows.Forms.Padding(4);
            this.createCusButton.Name = "createCusButton";
            this.createCusButton.Size = new System.Drawing.Size(112, 36);
            this.createCusButton.TabIndex = 58;
            this.createCusButton.Text = "Create";
            this.createCusButton.UseVisualStyleBackColor = false;
            this.createCusButton.Click += new System.EventHandler(this.createCusButton_Click);
            // 
            // custLabel
            // 
            this.custLabel.AutoSize = true;
            this.custLabel.Location = new System.Drawing.Point(94, 62);
            this.custLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.custLabel.Name = "custLabel";
            this.custLabel.Size = new System.Drawing.Size(62, 15);
            this.custLabel.TabIndex = 57;
            this.custLabel.Text = "Customer:";
            // 
            // custComboBox
            // 
            this.custComboBox.FormattingEnabled = true;
            this.custComboBox.Location = new System.Drawing.Point(207, 59);
            this.custComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.custComboBox.Name = "custComboBox";
            this.custComboBox.Size = new System.Drawing.Size(223, 23);
            this.custComboBox.TabIndex = 56;
            // 
            // docComboBox
            // 
            this.docComboBox.FormattingEnabled = true;
            this.docComboBox.Location = new System.Drawing.Point(207, 89);
            this.docComboBox.Name = "docComboBox";
            this.docComboBox.Size = new System.Drawing.Size(223, 23);
            this.docComboBox.TabIndex = 74;
            // 
            // Doctor_label
            // 
            this.Doctor_label.AutoSize = true;
            this.Doctor_label.Location = new System.Drawing.Point(97, 96);
            this.Doctor_label.Name = "Doctor_label";
            this.Doctor_label.Size = new System.Drawing.Size(46, 15);
            this.Doctor_label.TabIndex = 75;
            this.Doctor_label.Text = "Doctor:";
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 578);
            this.Controls.Add(this.Doctor_label);
            this.Controls.Add(this.docComboBox);
            this.Controls.Add(this.typeCombobox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.Con_Box);
            this.Controls.Add(this.Loc_Box);
            this.Controls.Add(this.Desc_Box);
            this.Controls.Add(this.Title_Box);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.createCusButton);
            this.Controls.Add(this.custLabel);
            this.Controls.Add(this.custComboBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeCombobox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.TextBox Con_Box;
        private System.Windows.Forms.TextBox Loc_Box;
        private System.Windows.Forms.TextBox Desc_Box;
        private System.Windows.Forms.TextBox Title_Box;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button createCusButton;
        private System.Windows.Forms.Label custLabel;
        private System.Windows.Forms.ComboBox custComboBox;
        private System.Windows.Forms.ComboBox docComboBox;
        private System.Windows.Forms.Label Doctor_label;
    }
}

