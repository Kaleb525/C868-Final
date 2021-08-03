
namespace C868
{
    partial class CreateDoctor
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.noRadio = new System.Windows.Forms.RadioButton();
            this.yesRadio = new System.Windows.Forms.RadioButton();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.phone_Label = new System.Windows.Forms.Label();
            this.type_Label = new System.Windows.Forms.Label();
            this.type_ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Doctor";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(196, 259);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 36);
            this.cancelButton.TabIndex = 49;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.ForeColor = System.Drawing.SystemColors.Control;
            this.createButton.Location = new System.Drawing.Point(32, 259);
            this.createButton.Margin = new System.Windows.Forms.Padding(4);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(112, 36);
            this.createButton.TabIndex = 48;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // noRadio
            // 
            this.noRadio.AutoSize = true;
            this.noRadio.Location = new System.Drawing.Point(263, 211);
            this.noRadio.Margin = new System.Windows.Forms.Padding(4);
            this.noRadio.Name = "noRadio";
            this.noRadio.Size = new System.Drawing.Size(41, 19);
            this.noRadio.TabIndex = 47;
            this.noRadio.Text = "No";
            this.noRadio.UseVisualStyleBackColor = true;
            // 
            // yesRadio
            // 
            this.yesRadio.AutoSize = true;
            this.yesRadio.Checked = true;
            this.yesRadio.Location = new System.Drawing.Point(141, 211);
            this.yesRadio.Margin = new System.Windows.Forms.Padding(4);
            this.yesRadio.Name = "yesRadio";
            this.yesRadio.Size = new System.Drawing.Size(42, 19);
            this.yesRadio.TabIndex = 46;
            this.yesRadio.TabStop = true;
            this.yesRadio.Text = "Yes";
            this.yesRadio.UseVisualStyleBackColor = true;
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(142, 75);
            this.nameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(166, 23);
            this.nameTextbox.TabIndex = 40;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(28, 75);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 33;
            this.nameLabel.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 50;
            this.label2.Text = "Active:";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(142, 114);
            this.phoneBox.Margin = new System.Windows.Forms.Padding(4);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(166, 23);
            this.phoneBox.TabIndex = 52;
            // 
            // phone_Label
            // 
            this.phone_Label.AutoSize = true;
            this.phone_Label.Location = new System.Drawing.Point(28, 117);
            this.phone_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone_Label.Name = "phone_Label";
            this.phone_Label.Size = new System.Drawing.Size(44, 15);
            this.phone_Label.TabIndex = 51;
            this.phone_Label.Text = "Phone:";
            // 
            // type_Label
            // 
            this.type_Label.AutoSize = true;
            this.type_Label.Location = new System.Drawing.Point(28, 159);
            this.type_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.type_Label.Name = "type_Label";
            this.type_Label.Size = new System.Drawing.Size(34, 15);
            this.type_Label.TabIndex = 53;
            this.type_Label.Text = "Type:";
            // 
            // type_ComboBox
            // 
            this.type_ComboBox.FormattingEnabled = true;
            this.type_ComboBox.Items.AddRange(new object[] {
            "GP",
            "Surgeon",
            "Nurse Practitioner"});
            this.type_ComboBox.Location = new System.Drawing.Point(142, 151);
            this.type_ComboBox.Name = "type_ComboBox";
            this.type_ComboBox.Size = new System.Drawing.Size(166, 23);
            this.type_ComboBox.TabIndex = 54;
            // 
            // CreateDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 308);
            this.Controls.Add(this.type_ComboBox);
            this.Controls.Add(this.type_Label);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.phone_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.noRadio);
            this.Controls.Add(this.yesRadio);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateDoctor";
            this.Text = "CreateDoctor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.RadioButton noRadio;
        private System.Windows.Forms.RadioButton yesRadio;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label phone_Label;
        private System.Windows.Forms.Label type_Label;
        private System.Windows.Forms.ComboBox type_ComboBox;
    }
}