
namespace C868
{
    partial class DeleteDoctor
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
            this.docComboBox = new System.Windows.Forms.ComboBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.No_Rad_Box = new System.Windows.Forms.RadioButton();
            this.Yes_Rad_Bttn = new System.Windows.Forms.RadioButton();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.activeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.type_ComboBox = new System.Windows.Forms.ComboBox();
            this.type_Label = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.phone_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_label
            // 
            this.Title_label.AutoSize = true;
            this.Title_label.Location = new System.Drawing.Point(208, 9);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(172, 25);
            this.Title_label.TabIndex = 23;
            this.Title_label.Text = "Delete Customer";
            // 
            // docComboBox
            // 
            this.docComboBox.FormattingEnabled = true;
            this.docComboBox.Location = new System.Drawing.Point(151, 73);
            this.docComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.docComboBox.Name = "docComboBox";
            this.docComboBox.Size = new System.Drawing.Size(167, 23);
            this.docComboBox.TabIndex = 97;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(24, 77);
            this.idLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(89, 13);
            this.idLabel.TabIndex = 96;
            this.idLabel.Text = "Doctor Select:";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.SystemColors.Control;
            this.clearButton.Location = new System.Drawing.Point(206, 299);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 36);
            this.clearButton.TabIndex = 95;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.searchButton.Location = new System.Drawing.Point(42, 299);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 36);
            this.searchButton.TabIndex = 94;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(206, 358);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 36);
            this.cancelButton.TabIndex = 93;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Enabled = false;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteButton.Location = new System.Drawing.Point(40, 358);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 36);
            this.deleteButton.TabIndex = 92;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // No_Rad_Box
            // 
            this.No_Rad_Box.AutoSize = true;
            this.No_Rad_Box.Enabled = false;
            this.No_Rad_Box.Location = new System.Drawing.Point(273, 265);
            this.No_Rad_Box.Margin = new System.Windows.Forms.Padding(4);
            this.No_Rad_Box.Name = "No_Rad_Box";
            this.No_Rad_Box.Size = new System.Drawing.Size(41, 19);
            this.No_Rad_Box.TabIndex = 91;
            this.No_Rad_Box.TabStop = true;
            this.No_Rad_Box.Text = "No";
            this.No_Rad_Box.UseVisualStyleBackColor = true;
            // 
            // Yes_Rad_Bttn
            // 
            this.Yes_Rad_Bttn.AutoSize = true;
            this.Yes_Rad_Bttn.Enabled = false;
            this.Yes_Rad_Bttn.Location = new System.Drawing.Point(151, 265);
            this.Yes_Rad_Bttn.Margin = new System.Windows.Forms.Padding(4);
            this.Yes_Rad_Bttn.Name = "Yes_Rad_Bttn";
            this.Yes_Rad_Bttn.Size = new System.Drawing.Size(42, 19);
            this.Yes_Rad_Bttn.TabIndex = 90;
            this.Yes_Rad_Bttn.TabStop = true;
            this.Yes_Rad_Bttn.Text = "Yes";
            this.Yes_Rad_Bttn.UseVisualStyleBackColor = true;
            // 
            // Name_Box
            // 
            this.Name_Box.Enabled = false;
            this.Name_Box.Location = new System.Drawing.Point(138, 142);
            this.Name_Box.Margin = new System.Windows.Forms.Padding(4);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(180, 23);
            this.Name_Box.TabIndex = 84;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 142);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 77;
            this.nameLabel.Text = "Name:";
            // 
            // activeLabel
            // 
            this.activeLabel.AutoSize = true;
            this.activeLabel.Location = new System.Drawing.Point(51, 269);
            this.activeLabel.Name = "activeLabel";
            this.activeLabel.Size = new System.Drawing.Size(43, 15);
            this.activeLabel.TabIndex = 98;
            this.activeLabel.Text = "Active:";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(151, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(79, 15);
            this.TitleLabel.TabIndex = 99;
            this.TitleLabel.Text = "Delete Doctor";
            // 
            // type_ComboBox
            // 
            this.type_ComboBox.FormattingEnabled = true;
            this.type_ComboBox.Items.AddRange(new object[] {
            "GP",
            "Surgeon",
            "Nurse Practitioner"});
            this.type_ComboBox.Location = new System.Drawing.Point(138, 210);
            this.type_ComboBox.Name = "type_ComboBox";
            this.type_ComboBox.Size = new System.Drawing.Size(180, 23);
            this.type_ComboBox.TabIndex = 103;
            // 
            // type_Label
            // 
            this.type_Label.AutoSize = true;
            this.type_Label.Location = new System.Drawing.Point(24, 218);
            this.type_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.type_Label.Name = "type_Label";
            this.type_Label.Size = new System.Drawing.Size(34, 15);
            this.type_Label.TabIndex = 102;
            this.type_Label.Text = "Type:";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(138, 173);
            this.phoneBox.Margin = new System.Windows.Forms.Padding(4);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(180, 23);
            this.phoneBox.TabIndex = 101;
            // 
            // phone_Label
            // 
            this.phone_Label.AutoSize = true;
            this.phone_Label.Location = new System.Drawing.Point(24, 176);
            this.phone_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone_Label.Name = "phone_Label";
            this.phone_Label.Size = new System.Drawing.Size(44, 15);
            this.phone_Label.TabIndex = 100;
            this.phone_Label.Text = "Phone:";
            // 
            // DeleteDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 452);
            this.Controls.Add(this.type_ComboBox);
            this.Controls.Add(this.type_Label);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.phone_Label);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.activeLabel);
            this.Controls.Add(this.docComboBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.No_Rad_Box);
            this.Controls.Add(this.Yes_Rad_Bttn);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.nameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeleteDoctor";
            this.Text = "DeleteDoctor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title_label;
        private System.Windows.Forms.ComboBox docComboBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.RadioButton No_Rad_Box;
        private System.Windows.Forms.RadioButton Yes_Rad_Bttn;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label activeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ComboBox type_ComboBox;
        private System.Windows.Forms.Label type_Label;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label phone_Label;
    }
}