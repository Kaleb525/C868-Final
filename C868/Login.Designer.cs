
namespace C868
{
    partial class Login
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
            this.UserName_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.UserName_Box = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Cancel_bttn = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserName_Label
            // 
            this.UserName_Label.AutoSize = true;
            this.UserName_Label.Location = new System.Drawing.Point(27, 163);
            this.UserName_Label.Name = "UserName_Label";
            this.UserName_Label.Size = new System.Drawing.Size(119, 25);
            this.UserName_Label.TabIndex = 0;
            this.UserName_Label.Text = "UserName:";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(27, 248);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(112, 25);
            this.Password_Label.TabIndex = 1;
            this.Password_Label.Text = "Password:";
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(202, 245);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.PasswordChar = '*';
            this.Password_Box.Size = new System.Drawing.Size(250, 31);
            this.Password_Box.TabIndex = 4;
            // 
            // UserName_Box
            // 
            this.UserName_Box.Location = new System.Drawing.Point(202, 163);
            this.UserName_Box.Name = "UserName_Box";
            this.UserName_Box.Size = new System.Drawing.Size(250, 31);
            this.UserName_Box.TabIndex = 3;
            // 
            // Login_Button
            // 
            this.Login_Button.BackColor = System.Drawing.Color.MidnightBlue;
            this.Login_Button.ForeColor = System.Drawing.SystemColors.Control;
            this.Login_Button.Location = new System.Drawing.Point(92, 356);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(165, 63);
            this.Login_Button.TabIndex = 5;
            this.Login_Button.Text = "Log-In";
            this.Login_Button.UseVisualStyleBackColor = false;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Cancel_bttn
            // 
            this.Cancel_bttn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Cancel_bttn.ForeColor = System.Drawing.SystemColors.Control;
            this.Cancel_bttn.Location = new System.Drawing.Point(369, 356);
            this.Cancel_bttn.Name = "Cancel_bttn";
            this.Cancel_bttn.Size = new System.Drawing.Size(154, 63);
            this.Cancel_bttn.TabIndex = 6;
            this.Cancel_bttn.Text = "Cancel";
            this.Cancel_bttn.UseVisualStyleBackColor = false;
            this.Cancel_bttn.Click += new System.EventHandler(this.Cancel_bttn_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(227, 80);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(201, 25);
            this.Title.TabIndex = 6;
            this.Title.Text = "Please Login Below";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 535);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Cancel_bttn);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.UserName_Box);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.UserName_Label);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserName_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.TextBox UserName_Box;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button Cancel_bttn;
        private System.Windows.Forms.Label Title;
    }
}