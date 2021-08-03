
namespace C868
{
    partial class UpdateAppointment
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
            this.Title_label = new System.Windows.Forms.Label();
            this.typeCombobox = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.Contact_Box = new System.Windows.Forms.TextBox();
            this.Loc_Box = new System.Windows.Forms.TextBox();
            this.Desc_Box = new System.Windows.Forms.TextBox();
            this.Title_Box = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.appointSelectLabel = new System.Windows.Forms.Label();
            this.appointComboBox = new System.Windows.Forms.ComboBox();
            this.doctorComboBox = new System.Windows.Forms.ComboBox();
            this.doc_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_label
            // 
            this.Title_label.AutoSize = true;
            this.Title_label.Location = new System.Drawing.Point(136, 16);
            this.Title_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(119, 15);
            this.Title_label.TabIndex = 0;
            this.Title_label.Text = "Update Appointment";
            // 
            // typeCombobox
            // 
            this.typeCombobox.Enabled = false;
            this.typeCombobox.FormattingEnabled = true;
            this.typeCombobox.Items.AddRange(new object[] {
            "Event",
            "Follow Up",
            "Initial Consultation",
            "Lab Visit",
            "Other",
            "Physical",
            "Sugery"});
            this.typeCombobox.Location = new System.Drawing.Point(142, 352);
            this.typeCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.typeCombobox.Name = "typeCombobox";
            this.typeCombobox.Size = new System.Drawing.Size(223, 23);
            this.typeCombobox.TabIndex = 100;
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(29, 90);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(62, 15);
            this.customerLabel.TabIndex = 99;
            this.customerLabel.Text = "Customer:";
            // 
            // customerComboBox
            // 
            this.customerComboBox.Enabled = false;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(142, 86);
            this.customerComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(223, 23);
            this.customerComboBox.TabIndex = 98;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.SystemColors.Control;
            this.clearButton.Location = new System.Drawing.Point(232, 518);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 36);
            this.clearButton.TabIndex = 97;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.searchButton.Location = new System.Drawing.Point(67, 518);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 36);
            this.searchButton.TabIndex = 96;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(232, 577);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 36);
            this.cancelButton.TabIndex = 95;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.Enabled = false;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.ForeColor = System.Drawing.SystemColors.Control;
            this.updateButton.Location = new System.Drawing.Point(66, 577);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(112, 36);
            this.updateButton.TabIndex = 94;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(29, 469);
            this.endLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(59, 15);
            this.endLabel.TabIndex = 93;
            this.endLabel.Text = "End Time:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(29, 412);
            this.startLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(63, 15);
            this.startLabel.TabIndex = 92;
            this.startLabel.Text = "Start Time:";
            // 
            // endDTP
            // 
            this.endDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endDTP.Enabled = false;
            this.endDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDTP.Location = new System.Drawing.Point(142, 461);
            this.endDTP.Margin = new System.Windows.Forms.Padding(4);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(223, 23);
            this.endDTP.TabIndex = 91;
            // 
            // startDTP
            // 
            this.startDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startDTP.Enabled = false;
            this.startDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDTP.Location = new System.Drawing.Point(142, 405);
            this.startDTP.Margin = new System.Windows.Forms.Padding(4);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(223, 23);
            this.startDTP.TabIndex = 90;
            // 
            // Contact_Box
            // 
            this.Contact_Box.Enabled = false;
            this.Contact_Box.Location = new System.Drawing.Point(142, 311);
            this.Contact_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Contact_Box.Name = "Contact_Box";
            this.Contact_Box.Size = new System.Drawing.Size(223, 23);
            this.Contact_Box.TabIndex = 89;
            this.Contact_Box.TextChanged += new System.EventHandler(this.UpdateAppointment_TextChanged);
            // 
            // Loc_Box
            // 
            this.Loc_Box.Enabled = false;
            this.Loc_Box.Location = new System.Drawing.Point(142, 272);
            this.Loc_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Loc_Box.Name = "Loc_Box";
            this.Loc_Box.Size = new System.Drawing.Size(223, 23);
            this.Loc_Box.TabIndex = 88;
            this.Loc_Box.TextChanged += new System.EventHandler(this.UpdateAppointment_TextChanged);
            // 
            // Desc_Box
            // 
            this.Desc_Box.Enabled = false;
            this.Desc_Box.Location = new System.Drawing.Point(142, 194);
            this.Desc_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Desc_Box.Multiline = true;
            this.Desc_Box.Name = "Desc_Box";
            this.Desc_Box.Size = new System.Drawing.Size(223, 59);
            this.Desc_Box.TabIndex = 87;
            this.Desc_Box.TextChanged += new System.EventHandler(this.UpdateAppointment_TextChanged);
            // 
            // Title_Box
            // 
            this.Title_Box.Enabled = false;
            this.Title_Box.Location = new System.Drawing.Point(142, 149);
            this.Title_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Title_Box.MaxLength = 255;
            this.Title_Box.Name = "Title_Box";
            this.Title_Box.Size = new System.Drawing.Size(223, 23);
            this.Title_Box.TabIndex = 86;
            this.Title_Box.TextChanged += new System.EventHandler(this.UpdateAppointment_TextChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(29, 355);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 15);
            this.typeLabel.TabIndex = 85;
            this.typeLabel.Text = "Type:";
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Location = new System.Drawing.Point(29, 315);
            this.contactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(52, 15);
            this.contactLabel.TabIndex = 84;
            this.contactLabel.Text = "Contact:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(29, 276);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(56, 15);
            this.locationLabel.TabIndex = 83;
            this.locationLabel.Text = "Location:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(29, 194);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(70, 15);
            this.descriptionLabel.TabIndex = 82;
            this.descriptionLabel.Text = "Description:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(29, 149);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(32, 15);
            this.titleLabel.TabIndex = 81;
            this.titleLabel.Text = "Title:";
            // 
            // appointSelectLabel
            // 
            this.appointSelectLabel.AutoSize = true;
            this.appointSelectLabel.Location = new System.Drawing.Point(29, 43);
            this.appointSelectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appointSelectLabel.Name = "appointSelectLabel";
            this.appointSelectLabel.Size = new System.Drawing.Size(81, 15);
            this.appointSelectLabel.TabIndex = 80;
            this.appointSelectLabel.Text = "Appointment:";
            // 
            // appointComboBox
            // 
            this.appointComboBox.FormattingEnabled = true;
            this.appointComboBox.Location = new System.Drawing.Point(142, 39);
            this.appointComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.appointComboBox.Name = "appointComboBox";
            this.appointComboBox.Size = new System.Drawing.Size(223, 23);
            this.appointComboBox.TabIndex = 79;
            // 
            // doctorComboBox
            // 
            this.doctorComboBox.FormattingEnabled = true;
            this.doctorComboBox.Location = new System.Drawing.Point(142, 117);
            this.doctorComboBox.Name = "doctorComboBox";
            this.doctorComboBox.Size = new System.Drawing.Size(223, 23);
            this.doctorComboBox.TabIndex = 101;
            // 
            // doc_Label
            // 
            this.doc_Label.AutoSize = true;
            this.doc_Label.Location = new System.Drawing.Point(29, 117);
            this.doc_Label.Name = "doc_Label";
            this.doc_Label.Size = new System.Drawing.Size(46, 15);
            this.doc_Label.TabIndex = 102;
            this.doc_Label.Text = "Doctor:";
            // 
            // UpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 632);
            this.Controls.Add(this.doc_Label);
            this.Controls.Add(this.doctorComboBox);
            this.Controls.Add(this.typeCombobox);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.Contact_Box);
            this.Controls.Add(this.Loc_Box);
            this.Controls.Add(this.Desc_Box);
            this.Controls.Add(this.Title_Box);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.appointSelectLabel);
            this.Controls.Add(this.appointComboBox);
            this.Controls.Add(this.Title_label);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UpdateAppointment";
            this.Text = "UpdateAppointment";
            this.TextChanged += new System.EventHandler(this.UpdateAppointment_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title_label;
        private System.Windows.Forms.ComboBox typeCombobox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.TextBox Contact_Box;
        private System.Windows.Forms.TextBox Loc_Box;
        private System.Windows.Forms.TextBox Desc_Box;
        private System.Windows.Forms.TextBox Title_Box;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label appointSelectLabel;
        private System.Windows.Forms.ComboBox appointComboBox;
        private System.Windows.Forms.ComboBox doctorComboBox;
        private System.Windows.Forms.Label doc_Label;
    }
}