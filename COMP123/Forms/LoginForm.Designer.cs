namespace COMP123
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.label1 = new global::System.Windows.Forms.Label();
            this.label2 = new global::System.Windows.Forms.Label();
            this.label6 = new global::System.Windows.Forms.Label();
            this.userNametxt = new global::System.Windows.Forms.TextBox();
            this.passwordtxt = new global::System.Windows.Forms.TextBox();
            this.showPasswordCheckBox = new global::System.Windows.Forms.CheckBox();
            this.clearBtn = new global::System.Windows.Forms.Button();
            this.loginBtn = new global::System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new global::System.Drawing.Font("MS UI Gothic", 27.75F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = global::System.Drawing.Color.Blue;
            this.label1.Location = new global::System.Drawing.Point(5, 65);
            this.label1.Margin = new global::System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(336, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accounting System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new global::System.Drawing.Font("MS UI Gothic", 18F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = global::System.Drawing.Color.Blue;
            this.label2.Location = new global::System.Drawing.Point(13, 143);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(119, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new global::System.Drawing.Font("MS UI Gothic", 18F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = global::System.Drawing.Color.Blue;
            this.label6.Location = new global::System.Drawing.Point(13, 228);
            this.label6.Name = "label6";
            this.label6.Size = new global::System.Drawing.Size(106, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password";
            // 
            // userNametxt
            // 
            this.userNametxt.Location = new global::System.Drawing.Point(17, 170);
            this.userNametxt.Name = "userNametxt";
            this.userNametxt.Size = new global::System.Drawing.Size(260, 34);
            this.userNametxt.TabIndex = 6;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new global::System.Drawing.Point(17, 257);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.PasswordChar = '*';
            this.passwordtxt.Size = new global::System.Drawing.Size(260, 34);
            this.passwordtxt.TabIndex = 7;
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Font = new global::System.Drawing.Font("MS UI Gothic", 12F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPasswordCheckBox.ForeColor = global::System.Drawing.Color.Blue;
            this.showPasswordCheckBox.Location = new global::System.Drawing.Point(146, 296);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new global::System.Drawing.Size(131, 20);
            this.showPasswordCheckBox.TabIndex = 8;
            this.showPasswordCheckBox.Text = "Show Password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            this.showPasswordCheckBox.CheckedChanged += new global::System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new global::System.Drawing.Font("MS UI Gothic", 12F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = global::System.Drawing.Color.Blue;
            this.clearBtn.Location = new global::System.Drawing.Point(17, 384);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new global::System.Drawing.Size(260, 36);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new global::System.EventHandler(this.clearBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = global::System.Drawing.Color.Blue;
            this.loginBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
            this.loginBtn.Font = new global::System.Drawing.Font("MS UI Gothic", 12F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = global::System.Drawing.Color.White;
            this.loginBtn.Location = new global::System.Drawing.Point(17, 334);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new global::System.Drawing.Size(260, 44);
            this.loginBtn.TabIndex = 13;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new global::System.EventHandler(this.loginBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(15F, 27F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::System.Drawing.Color.White;
            this.ClientSize = new global::System.Drawing.Size(361, 470);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.userNametxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new global::System.Drawing.Font("MS UI Gothic", 20.25F, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = global::System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new global::System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::System.Windows.Forms.Label label1;
        private global::System.Windows.Forms.Label label2;
        private global::System.Windows.Forms.Label label6;
        private global::System.Windows.Forms.TextBox userNametxt;
        private global::System.Windows.Forms.TextBox passwordtxt;
        private global::System.Windows.Forms.CheckBox showPasswordCheckBox;
        private global::System.Windows.Forms.Button clearBtn;
        private global::System.Windows.Forms.Button loginBtn;
    }
}

