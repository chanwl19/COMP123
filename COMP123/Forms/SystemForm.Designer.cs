using System.Windows.Forms;

namespace COMP123.Forms
{
    partial class SystemForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.salaryGroupBox = new System.Windows.Forms.GroupBox();
            this.salaryTotal = new System.Windows.Forms.Label();
            this.salaryMonth = new System.Windows.Forms.Label();
            this.salaryMonthSelect = new System.Windows.Forms.ComboBox();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.managerError = new System.Windows.Forms.Label();
            this.managerIdOpt = new System.Windows.Forms.ComboBox();
            this.managerLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.activeRadio = new System.Windows.Forms.RadioButton();
            this.inactiveRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modifyRadio = new System.Windows.Forms.RadioButton();
            this.addRadio = new System.Windows.Forms.RadioButton();
            this.confirmPasswordError = new System.Windows.Forms.Label();
            this.passwordError = new System.Windows.Forms.Label();
            this.emailError = new System.Windows.Forms.Label();
            this.nameError = new System.Windows.Forms.Label();
            this.actionBtn = new System.Windows.Forms.Button();
            this.roleSelect = new System.Windows.Forms.ComboBox();
            this.confirmPwTxt = new System.Windows.Forms.TextBox();
            this.pwTxt = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.existingUsersGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.accountantTab = new System.Windows.Forms.TabPage();
            this.saveEntryBtn = new System.Windows.Forms.Button();
            this.selectMonth = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.generalEntryGrid = new System.Windows.Forms.DataGridView();
            this.managerTab = new System.Windows.Forms.TabPage();
            this.rejectBtn = new System.Windows.Forms.Button();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.approveBtn = new System.Windows.Forms.Button();
            this.generateBtn = new System.Windows.Forms.Button();
            this.toDateTime = new System.Windows.Forms.DateTimePicker();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.managerAccountOpt = new System.Windows.Forms.RadioButton();
            this.managerEntryOpt = new System.Windows.Forms.RadioButton();
            this.managerDashBoardOpt = new System.Windows.Forms.RadioButton();
            this.managerGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.adminTab.SuspendLayout();
            this.salaryGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existingUsersGrid)).BeginInit();
            this.accountantTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalEntryGrid)).BeginInit();
            this.managerTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.adminTab);
            this.tabControl.Controls.Add(this.accountantTab);
            this.tabControl.Controls.Add(this.managerTab);
            this.tabControl.Location = new System.Drawing.Point(-1, 65);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1011, 768);
            this.tabControl.TabIndex = 0;
            // 
            // adminTab
            // 
            this.adminTab.BackColor = System.Drawing.Color.Gray;
            this.adminTab.Controls.Add(this.salaryGroupBox);
            this.adminTab.Controls.Add(this.managerError);
            this.adminTab.Controls.Add(this.managerIdOpt);
            this.adminTab.Controls.Add(this.managerLabel);
            this.adminTab.Controls.Add(this.groupBox2);
            this.adminTab.Controls.Add(this.groupBox1);
            this.adminTab.Controls.Add(this.confirmPasswordError);
            this.adminTab.Controls.Add(this.passwordError);
            this.adminTab.Controls.Add(this.emailError);
            this.adminTab.Controls.Add(this.nameError);
            this.adminTab.Controls.Add(this.actionBtn);
            this.adminTab.Controls.Add(this.roleSelect);
            this.adminTab.Controls.Add(this.confirmPwTxt);
            this.adminTab.Controls.Add(this.pwTxt);
            this.adminTab.Controls.Add(this.emailTxt);
            this.adminTab.Controls.Add(this.nameTxt);
            this.adminTab.Controls.Add(this.label6);
            this.adminTab.Controls.Add(this.label5);
            this.adminTab.Controls.Add(this.label4);
            this.adminTab.Controls.Add(this.label3);
            this.adminTab.Controls.Add(this.label1);
            this.adminTab.Controls.Add(this.existingUsersGrid);
            this.adminTab.Controls.Add(this.label2);
            this.adminTab.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTab.ForeColor = System.Drawing.Color.Blue;
            this.adminTab.Location = new System.Drawing.Point(4, 22);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminTab.Size = new System.Drawing.Size(1003, 742);
            this.adminTab.TabIndex = 0;
            this.adminTab.Text = "Admin Page";
            // 
            // salaryGroupBox
            // 
            this.salaryGroupBox.Controls.Add(this.salaryTotal);
            this.salaryGroupBox.Controls.Add(this.salaryMonth);
            this.salaryGroupBox.Controls.Add(this.salaryMonthSelect);
            this.salaryGroupBox.Controls.Add(this.salaryBox);
            this.salaryGroupBox.Location = new System.Drawing.Point(464, 573);
            this.salaryGroupBox.Name = "salaryGroupBox";
            this.salaryGroupBox.Size = new System.Drawing.Size(532, 65);
            this.salaryGroupBox.TabIndex = 37;
            this.salaryGroupBox.TabStop = false;
            // 
            // salaryTotal
            // 
            this.salaryTotal.AutoSize = true;
            this.salaryTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.salaryTotal.Location = new System.Drawing.Point(239, 23);
            this.salaryTotal.Name = "salaryTotal";
            this.salaryTotal.Size = new System.Drawing.Size(114, 24);
            this.salaryTotal.TabIndex = 47;
            this.salaryTotal.Text = "Salary :";
            this.salaryTotal.Visible = false;
            // 
            // salaryMonth
            // 
            this.salaryMonth.AutoSize = true;
            this.salaryMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.salaryMonth.Location = new System.Drawing.Point(11, 19);
            this.salaryMonth.Name = "salaryMonth";
            this.salaryMonth.Size = new System.Drawing.Size(101, 24);
            this.salaryMonth.TabIndex = 46;
            this.salaryMonth.Text = "Month :";
            this.salaryMonth.Visible = false;
            // 
            // salaryMonthSelect
            // 
            this.salaryMonthSelect.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryMonthSelect.FormattingEnabled = true;
            this.salaryMonthSelect.Location = new System.Drawing.Point(118, 23);
            this.salaryMonthSelect.Name = "salaryMonthSelect";
            this.salaryMonthSelect.Size = new System.Drawing.Size(115, 24);
            this.salaryMonthSelect.TabIndex = 18;
            this.salaryMonthSelect.SelectedIndexChanged += new System.EventHandler(this.salaryMonthSelect_SelectedIndexChanged);
            // 
            // salaryBox
            // 
            this.salaryBox.Location = new System.Drawing.Point(361, 20);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(151, 31);
            this.salaryBox.TabIndex = 17;
            // 
            // managerError
            // 
            this.managerError.AutoSize = true;
            this.managerError.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerError.ForeColor = System.Drawing.Color.Red;
            this.managerError.Location = new System.Drawing.Point(694, 353);
            this.managerError.Name = "managerError";
            this.managerError.Size = new System.Drawing.Size(240, 19);
            this.managerError.TabIndex = 45;
            this.managerError.Text = "Please Select Manager";
            this.managerError.Visible = false;
            // 
            // managerIdOpt
            // 
            this.managerIdOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.managerIdOpt.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerIdOpt.FormattingEnabled = true;
            this.managerIdOpt.Location = new System.Drawing.Point(698, 318);
            this.managerIdOpt.Name = "managerIdOpt";
            this.managerIdOpt.Size = new System.Drawing.Size(166, 32);
            this.managerIdOpt.TabIndex = 44;
            this.managerIdOpt.Visible = false;
            // 
            // managerLabel
            // 
            this.managerLabel.AutoSize = true;
            this.managerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.managerLabel.Location = new System.Drawing.Point(694, 291);
            this.managerLabel.Name = "managerLabel";
            this.managerLabel.Size = new System.Drawing.Size(101, 24);
            this.managerLabel.TabIndex = 43;
            this.managerLabel.Text = "Manager";
            this.managerLabel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.activeRadio);
            this.groupBox2.Controls.Add(this.inactiveRadio);
            this.groupBox2.Location = new System.Drawing.Point(464, 511);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 55);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            // 
            // activeRadio
            // 
            this.activeRadio.AutoSize = true;
            this.activeRadio.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeRadio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.activeRadio.Location = new System.Drawing.Point(6, 21);
            this.activeRadio.Name = "activeRadio";
            this.activeRadio.Size = new System.Drawing.Size(106, 28);
            this.activeRadio.TabIndex = 15;
            this.activeRadio.TabStop = true;
            this.activeRadio.Text = "Active";
            this.activeRadio.UseVisualStyleBackColor = true;
            // 
            // inactiveRadio
            // 
            this.inactiveRadio.AutoSize = true;
            this.inactiveRadio.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveRadio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.inactiveRadio.Location = new System.Drawing.Point(160, 21);
            this.inactiveRadio.Name = "inactiveRadio";
            this.inactiveRadio.Size = new System.Drawing.Size(132, 28);
            this.inactiveRadio.TabIndex = 16;
            this.inactiveRadio.TabStop = true;
            this.inactiveRadio.Text = "Inactive";
            this.inactiveRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modifyRadio);
            this.groupBox1.Controls.Add(this.addRadio);
            this.groupBox1.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(464, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 64);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // modifyRadio
            // 
            this.modifyRadio.AutoSize = true;
            this.modifyRadio.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyRadio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.modifyRadio.Location = new System.Drawing.Point(160, 29);
            this.modifyRadio.Name = "modifyRadio";
            this.modifyRadio.Size = new System.Drawing.Size(171, 28);
            this.modifyRadio.TabIndex = 14;
            this.modifyRadio.TabStop = true;
            this.modifyRadio.Text = "Modify User";
            this.modifyRadio.UseVisualStyleBackColor = true;
            this.modifyRadio.CheckedChanged += new System.EventHandler(this.ModifyRadio_CheckedChanged);
            // 
            // addRadio
            // 
            this.addRadio.AutoSize = true;
            this.addRadio.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRadio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.addRadio.Location = new System.Drawing.Point(6, 29);
            this.addRadio.Name = "addRadio";
            this.addRadio.Size = new System.Drawing.Size(132, 28);
            this.addRadio.TabIndex = 13;
            this.addRadio.TabStop = true;
            this.addRadio.Text = "Add User";
            this.addRadio.UseVisualStyleBackColor = true;
            this.addRadio.CheckedChanged += new System.EventHandler(this.AddRadio_CheckedChanged);
            // 
            // confirmPasswordError
            // 
            this.confirmPasswordError.AutoSize = true;
            this.confirmPasswordError.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordError.ForeColor = System.Drawing.Color.Red;
            this.confirmPasswordError.Location = new System.Drawing.Point(736, 470);
            this.confirmPasswordError.Name = "confirmPasswordError";
            this.confirmPasswordError.Size = new System.Drawing.Size(240, 19);
            this.confirmPasswordError.TabIndex = 41;
            this.confirmPasswordError.Text = "Please Input Password";
            this.confirmPasswordError.Visible = false;
            // 
            // passwordError
            // 
            this.passwordError.AutoSize = true;
            this.passwordError.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordError.ForeColor = System.Drawing.Color.Red;
            this.passwordError.Location = new System.Drawing.Point(736, 396);
            this.passwordError.Name = "passwordError";
            this.passwordError.Size = new System.Drawing.Size(240, 19);
            this.passwordError.TabIndex = 40;
            this.passwordError.Text = "Please Input Password";
            this.passwordError.Visible = false;
            // 
            // emailError
            // 
            this.emailError.AutoSize = true;
            this.emailError.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailError.ForeColor = System.Drawing.Color.Red;
            this.emailError.Location = new System.Drawing.Point(736, 249);
            this.emailError.Name = "emailError";
            this.emailError.Size = new System.Drawing.Size(207, 19);
            this.emailError.TabIndex = 39;
            this.emailError.Text = "Please Input Email";
            this.emailError.Visible = false;
            // 
            // nameError
            // 
            this.nameError.AutoSize = true;
            this.nameError.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameError.ForeColor = System.Drawing.Color.Red;
            this.nameError.Location = new System.Drawing.Point(736, 178);
            this.nameError.Name = "nameError";
            this.nameError.Size = new System.Drawing.Size(196, 19);
            this.nameError.TabIndex = 38;
            this.nameError.Text = "Please Input Name";
            this.nameError.Visible = false;
            // 
            // actionBtn
            // 
            this.actionBtn.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.actionBtn.Location = new System.Drawing.Point(624, 644);
            this.actionBtn.Name = "actionBtn";
            this.actionBtn.Size = new System.Drawing.Size(132, 46);
            this.actionBtn.TabIndex = 37;
            this.actionBtn.Text = "Modify";
            this.actionBtn.UseVisualStyleBackColor = true;
            this.actionBtn.Click += new System.EventHandler(this.actionBtn_Click);
            // 
            // roleSelect
            // 
            this.roleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleSelect.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleSelect.FormattingEnabled = true;
            this.roleSelect.Location = new System.Drawing.Point(464, 318);
            this.roleSelect.Name = "roleSelect";
            this.roleSelect.Size = new System.Drawing.Size(166, 32);
            this.roleSelect.TabIndex = 35;
            this.roleSelect.SelectedIndexChanged += new System.EventHandler(this.roleSelect_SelectedIndexChanged);
            // 
            // confirmPwTxt
            // 
            this.confirmPwTxt.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPwTxt.Location = new System.Drawing.Point(464, 462);
            this.confirmPwTxt.Name = "confirmPwTxt";
            this.confirmPwTxt.Size = new System.Drawing.Size(254, 31);
            this.confirmPwTxt.TabIndex = 34;
            // 
            // pwTxt
            // 
            this.pwTxt.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTxt.Location = new System.Drawing.Point(464, 388);
            this.pwTxt.Name = "pwTxt";
            this.pwTxt.Size = new System.Drawing.Size(254, 31);
            this.pwTxt.TabIndex = 33;
            // 
            // emailTxt
            // 
            this.emailTxt.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxt.Location = new System.Drawing.Point(464, 241);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(254, 31);
            this.emailTxt.TabIndex = 32;
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(464, 170);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(254, 31);
            this.nameTxt.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(460, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(460, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 29;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(460, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 24);
            this.label4.TabIndex = 28;
            this.label4.Text = "Role";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(460, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(460, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Name";
            // 
            // existingUsersGrid
            // 
            this.existingUsersGrid.AllowUserToAddRows = false;
            this.existingUsersGrid.AllowUserToDeleteRows = false;
            this.existingUsersGrid.AllowUserToOrderColumns = true;
            this.existingUsersGrid.AllowUserToResizeColumns = false;
            this.existingUsersGrid.AllowUserToResizeRows = false;
            this.existingUsersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.existingUsersGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.existingUsersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.existingUsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.existingUsersGrid.Location = new System.Drawing.Point(23, 103);
            this.existingUsersGrid.MultiSelect = false;
            this.existingUsersGrid.Name = "existingUsersGrid";
            this.existingUsersGrid.ReadOnly = true;
            this.existingUsersGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.existingUsersGrid.RowTemplate.Height = 24;
            this.existingUsersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.existingUsersGrid.Size = new System.Drawing.Size(379, 460);
            this.existingUsersGrid.TabIndex = 25;
            this.existingUsersGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.existingUsersGrid_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(333, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "Admin Page";
            // 
            // accountantTab
            // 
            this.accountantTab.BackColor = System.Drawing.Color.Gray;
            this.accountantTab.Controls.Add(this.saveEntryBtn);
            this.accountantTab.Controls.Add(this.selectMonth);
            this.accountantTab.Controls.Add(this.label8);
            this.accountantTab.Controls.Add(this.generalEntryGrid);
            this.accountantTab.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountantTab.Location = new System.Drawing.Point(4, 22);
            this.accountantTab.Name = "accountantTab";
            this.accountantTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountantTab.Size = new System.Drawing.Size(1003, 742);
            this.accountantTab.TabIndex = 1;
            this.accountantTab.Text = "Accountant Page";
            // 
            // saveEntryBtn
            // 
            this.saveEntryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.saveEntryBtn.Location = new System.Drawing.Point(835, 6);
            this.saveEntryBtn.Name = "saveEntryBtn";
            this.saveEntryBtn.Size = new System.Drawing.Size(148, 41);
            this.saveEntryBtn.TabIndex = 5;
            this.saveEntryBtn.Text = "Save";
            this.saveEntryBtn.UseVisualStyleBackColor = true;
            this.saveEntryBtn.Click += new System.EventHandler(this.saveEntryBtn_Click);
            // 
            // selectMonth
            // 
            this.selectMonth.FormattingEnabled = true;
            this.selectMonth.Location = new System.Drawing.Point(130, 9);
            this.selectMonth.Name = "selectMonth";
            this.selectMonth.Size = new System.Drawing.Size(220, 35);
            this.selectMonth.TabIndex = 4;
            this.selectMonth.SelectedIndexChanged += new System.EventHandler(this.selectMonth_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 27);
            this.label8.TabIndex = 3;
            this.label8.Text = "Month : ";
            // 
            // generalEntryGrid
            // 
            this.generalEntryGrid.AllowUserToOrderColumns = true;
            this.generalEntryGrid.AllowUserToResizeColumns = false;
            this.generalEntryGrid.AllowUserToResizeRows = false;
            this.generalEntryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.generalEntryGrid.BackgroundColor = System.Drawing.Color.White;
            this.generalEntryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.generalEntryGrid.Location = new System.Drawing.Point(9, 51);
            this.generalEntryGrid.MultiSelect = false;
            this.generalEntryGrid.Name = "generalEntryGrid";
            this.generalEntryGrid.RowTemplate.Height = 24;
            this.generalEntryGrid.Size = new System.Drawing.Size(987, 684);
            this.generalEntryGrid.TabIndex = 2;
            this.generalEntryGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.generalEntryGrid_EditingControlShowing);
            this.generalEntryGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.generalEntryGrid_RowPostPaint);
            this.generalEntryGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.generalEntryGrid_RowsAdded);
            this.generalEntryGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.generalEntryGrid_UserDeletingRow);
            // 
            // managerTab
            // 
            this.managerTab.BackColor = System.Drawing.Color.Gray;
            this.managerTab.Controls.Add(this.rejectBtn);
            this.managerTab.Controls.Add(this.categoryLabel);
            this.managerTab.Controls.Add(this.categoryComboBox);
            this.managerTab.Controls.Add(this.approveBtn);
            this.managerTab.Controls.Add(this.generateBtn);
            this.managerTab.Controls.Add(this.toDateTime);
            this.managerTab.Controls.Add(this.fromDateTime);
            this.managerTab.Controls.Add(this.toLabel);
            this.managerTab.Controls.Add(this.fromLabel);
            this.managerTab.Controls.Add(this.groupBox3);
            this.managerTab.Controls.Add(this.managerGridView);
            this.managerTab.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerTab.ForeColor = System.Drawing.Color.Blue;
            this.managerTab.Location = new System.Drawing.Point(4, 22);
            this.managerTab.Name = "managerTab";
            this.managerTab.Size = new System.Drawing.Size(1003, 742);
            this.managerTab.TabIndex = 2;
            this.managerTab.Text = "Manager Page";
            // 
            // rejectBtn
            // 
            this.rejectBtn.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectBtn.Location = new System.Drawing.Point(887, 95);
            this.rejectBtn.Name = "rejectBtn";
            this.rejectBtn.Size = new System.Drawing.Size(95, 34);
            this.rejectBtn.TabIndex = 11;
            this.rejectBtn.Text = "Reject";
            this.rejectBtn.UseVisualStyleBackColor = true;
            this.rejectBtn.Click += new System.EventHandler(this.rejectBtn_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(12, 78);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(79, 16);
            this.categoryLabel.TabIndex = 10;
            this.categoryLabel.Text = "Account:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(127, 75);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(145, 24);
            this.categoryComboBox.TabIndex = 9;
            // 
            // approveBtn
            // 
            this.approveBtn.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveBtn.Location = new System.Drawing.Point(768, 95);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(95, 34);
            this.approveBtn.TabIndex = 8;
            this.approveBtn.Text = "Approve";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBtn.Location = new System.Drawing.Point(496, 95);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(95, 34);
            this.generateBtn.TabIndex = 7;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // toDateTime
            // 
            this.toDateTime.CalendarFont = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTime.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTime.Location = new System.Drawing.Point(333, 104);
            this.toDateTime.Name = "toDateTime";
            this.toDateTime.Size = new System.Drawing.Size(145, 23);
            this.toDateTime.TabIndex = 6;
            // 
            // fromDateTime
            // 
            this.fromDateTime.CalendarFont = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTime.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTime.Location = new System.Drawing.Point(127, 104);
            this.fromDateTime.Name = "fromDateTime";
            this.fromDateTime.Size = new System.Drawing.Size(145, 23);
            this.fromDateTime.TabIndex = 4;
            this.fromDateTime.ValueChanged += new System.EventHandler(this.fromDateTime_ValueChanged);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(284, 104);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(43, 16);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "To :";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(13, 104);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(61, 16);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "From :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.managerAccountOpt);
            this.groupBox3.Controls.Add(this.managerEntryOpt);
            this.groupBox3.Controls.Add(this.managerDashBoardOpt);
            this.groupBox3.Location = new System.Drawing.Point(9, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 57);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // managerAccountOpt
            // 
            this.managerAccountOpt.AutoSize = true;
            this.managerAccountOpt.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerAccountOpt.Location = new System.Drawing.Point(234, 19);
            this.managerAccountOpt.Name = "managerAccountOpt";
            this.managerAccountOpt.Size = new System.Drawing.Size(115, 20);
            this.managerAccountOpt.TabIndex = 2;
            this.managerAccountOpt.TabStop = true;
            this.managerAccountOpt.Text = "By Account";
            this.managerAccountOpt.UseVisualStyleBackColor = true;
            this.managerAccountOpt.CheckedChanged += new System.EventHandler(this.managerAccountOpt_CheckedChanged);
            // 
            // managerEntryOpt
            // 
            this.managerEntryOpt.AutoSize = true;
            this.managerEntryOpt.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerEntryOpt.Location = new System.Drawing.Point(118, 19);
            this.managerEntryOpt.Name = "managerEntryOpt";
            this.managerEntryOpt.Size = new System.Drawing.Size(115, 20);
            this.managerEntryOpt.TabIndex = 1;
            this.managerEntryOpt.TabStop = true;
            this.managerEntryOpt.Text = "By Entries";
            this.managerEntryOpt.UseVisualStyleBackColor = true;
            this.managerEntryOpt.CheckedChanged += new System.EventHandler(this.managerEntryOpt_CheckedChanged);
            // 
            // managerDashBoardOpt
            // 
            this.managerDashBoardOpt.AutoSize = true;
            this.managerDashBoardOpt.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerDashBoardOpt.Location = new System.Drawing.Point(7, 19);
            this.managerDashBoardOpt.Name = "managerDashBoardOpt";
            this.managerDashBoardOpt.Size = new System.Drawing.Size(106, 20);
            this.managerDashBoardOpt.TabIndex = 0;
            this.managerDashBoardOpt.TabStop = true;
            this.managerDashBoardOpt.Text = "Dashboard";
            this.managerDashBoardOpt.UseVisualStyleBackColor = true;
            this.managerDashBoardOpt.CheckedChanged += new System.EventHandler(this.managerDashBoard_CheckedChanged);
            // 
            // managerGridView
            // 
            this.managerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.managerGridView.BackgroundColor = System.Drawing.Color.White;
            this.managerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.managerGridView.Location = new System.Drawing.Point(7, 144);
            this.managerGridView.Name = "managerGridView";
            this.managerGridView.RowTemplate.Height = 24;
            this.managerGridView.Size = new System.Drawing.Size(989, 595);
            this.managerGridView.TabIndex = 0;
            this.managerGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.managerGridView_RowPostPaint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(335, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "Acconting System";
            // 
            // logoutBtn
            // 
            this.logoutBtn.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.logoutBtn.Location = new System.Drawing.Point(885, 12);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(94, 33);
            this.logoutBtn.TabIndex = 48;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1011, 834);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SystemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl.ResumeLayout(false);
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.salaryGroupBox.ResumeLayout(false);
            this.salaryGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existingUsersGrid)).EndInit();
            this.accountantTab.ResumeLayout(false);
            this.accountantTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalEntryGrid)).EndInit();
            this.managerTab.ResumeLayout(false);
            this.managerTab.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl;
        private TabPage adminTab;
        private GroupBox groupBox2;
        private RadioButton activeRadio;
        private RadioButton inactiveRadio;
        private GroupBox groupBox1;
        private RadioButton modifyRadio;
        private RadioButton addRadio;
        private Label confirmPasswordError;
        private Label passwordError;
        private Label emailError;
        private Label nameError;
        private Button actionBtn;
        private ComboBox roleSelect;
        private TextBox confirmPwTxt;
        private TextBox pwTxt;
        private TextBox emailTxt;
        private TextBox nameTxt;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DataGridView existingUsersGrid;
        private Label label2;
        private TabPage accountantTab;
        private TabPage managerTab;
        private Label label7;
        private DataGridView generalEntryGrid;
        private ComboBox selectMonth;
        private Label label8;
        private Button saveEntryBtn;
        private GroupBox groupBox3;
        private DataGridView managerGridView;
        private RadioButton managerAccountOpt;
        private RadioButton managerEntryOpt;
        private RadioButton managerDashBoardOpt;
        private DateTimePicker toDateTime;
        private DateTimePicker fromDateTime;
        private Label toLabel;
        private Label fromLabel;
        private ComboBox managerIdOpt;
        private Label managerLabel;
        private Label managerError;
        private Button generateBtn;
        private Button approveBtn;
        private Label categoryLabel;
        private ComboBox categoryComboBox;
        private Button rejectBtn;
        private GroupBox salaryGroupBox;
        private TextBox salaryBox;
        private Label salaryMonth;
        private ComboBox salaryMonthSelect;
        private Label salaryTotal;
        private Button logoutBtn;
    }
}