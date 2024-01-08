using COMP123.CheckAllBox;
using COMP123.ColumnDateTimePicker;
using COMP123.Model;
using COMP123.Utility;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static COMP123.Utility.Parameters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace COMP123.Forms
{
    public partial class SystemForm : Form
    {
        private Staff operateStaff;
        private List<Staff> staffs;
        private bool isNeedManager = false;
        //private DateTimePicker dateTimePicker;
        private List<string> accounts;
        GeneralEntryHandler generalEntry = new GeneralEntryHandler();
        AccountEntryHandler accountEntry = new AccountEntryHandler();
        private DataGridViewCellStyle dataGridViewHeaderStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();

        //Form Methods
        public SystemForm(List<Staff> inputStaffs, Staff inputStaff)
        {
            InitializeComponent();
            InitializeCellStyle();
            operateStaff = inputStaff;
            staffs = (inputStaffs != null) ? inputStaffs : new List<Staff>();
            InitializeTabs(operateStaff);
            switch (inputStaff.Role)
            {
                case 0:
                    InitializeAdminData(staffs);
                    InitializeRoleComboBox();
                    break;
                case 1:
                    InitializeAccountantData(operateStaff);
                    break;
                case 2:
                    InitializeManagerData();
                    break;
                default:
                    MessageBox.Show("No user role found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm loginForm = new LoginForm();
                    this.Hide();
                    loginForm.Show();
                    break;
            }
        }

        private void InitializeTabs(Staff staff)
        {
            this.tabControl.TabPages.Remove(this.adminTab);
            this.tabControl.TabPages.Remove(this.managerTab);
            this.tabControl.TabPages.Remove(this.accountantTab);
            this.existingUsersGrid.AllowUserToAddRows = false;
            this.existingUsersGrid.AutoGenerateColumns = false;
            this.managerGridView.AllowUserToAddRows = false;
            this.managerGridView.AutoGenerateColumns = false;
            switch (staff.Role)
            {
                case 0:
                    this.tabControl.TabPages.Add(this.adminTab);
                    break;
                case 1:
                    this.tabControl.TabPages.Add(this.accountantTab); ;
                    break;
                case 2:
                    this.tabControl.TabPages.Add(this.managerTab);
                    break;
                default:
                    break;
            }
        }

        private void InitializeCellStyle() {
            dataGridViewHeaderStyle.Font = new Font("MS Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewHeaderStyle.ForeColor = Color.Black;

            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle.BackColor = SystemColors.Window;
            dataGridViewCellStyle.Font = new Font("MS Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
        }


        //Admin Tab methods

        private void InitializeAdminData(List<Staff> staffs)
        {
            this.salaryGroupBox.Visible = false;
            this.salaryBox.Visible = false;
            this.salaryBox.ReadOnly = true;
            this.salaryMonth.Visible = false;
            this.salaryTotal.Visible = false;
            this.salaryMonthSelect.Visible = false;
            this.existingUsersGrid.DefaultCellStyle = dataGridViewCellStyle;
            this.existingUsersGrid.ColumnHeadersDefaultCellStyle = dataGridViewHeaderStyle;
            this.existingUsersGrid.Rows.Clear();
            this.existingUsersGrid.Columns.Clear();
            InitializeSalaryMonth();
            foreach (string header in Parameters.ADMIN_HEADERS)
            {
                this.existingUsersGrid.Columns.Add(header, header);
            }

            if (staffs != null && staffs.Count > 0)
            {
                foreach (Staff staff in staffs)
                {
                    object[] rowData = { staff.StaffId, staff.Name, (Roles)staff.Role };
                    int rowIndex = this.existingUsersGrid.Rows.Add(rowData);
                    this.existingUsersGrid.Rows[rowIndex].Tag = staff;
                }
            }
            this.existingUsersGrid.ClearSelection();
        }

        private void existingUsersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Staff selectedStaff = (Staff)this.existingUsersGrid.SelectedRows[0].Tag;
                this.nameTxt.Text = selectedStaff.Name;
                this.emailTxt.Text = selectedStaff.Email;
                this.roleSelect.SelectedItem = (Roles)selectedStaff.Role;
                this.pwTxt.Text = Encryption.Decrypt(selectedStaff.Password);
                this.activeRadio.Checked = selectedStaff.IsActive;
                this.inactiveRadio.Checked = !selectedStaff.IsActive;
                this.confirmPwTxt.Text = "";
                this.salaryGroupBox.Visible = true;
                this.salaryBox.Visible = true;
                this.salaryTotal.Visible = true;
                this.salaryMonthSelect.Visible = true;
                this.salaryMonth.Visible = true;
                this.salaryBox.Text = "";

                CalculateSalary(selectedStaff);
                
            }
        }

        private void CalculateSalary(Staff staff) {
            DateTime fromDate = Convert.ToDateTime("01-" + this.salaryMonthSelect.SelectedValue.ToString());
            DateTime toDate = fromDate.AddMonths(1);
            List<AccountEntry> entries = this.generalEntry.RetrieveEnrties(staff.StaffId, fromDate, toDate, true, 4, "");
            decimal salary = staff.CalculateSalary(entries);
            this.salaryBox.Text = salary.ToString("0.00");
        } 

        private void salaryMonthSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.existingUsersGrid.SelectedRows.Count> 0) { 
                Staff selectedStaff = (Staff)this.existingUsersGrid.SelectedRows[0].Tag;
                CalculateSalary(selectedStaff);
            }
        }

        private void InitializeSalaryMonth() { 
            //Use Lambda
            List<string> months = Enumerable.Range(0, 12)
                                 .Select(offset => DateTime.Today.AddMonths(-offset))
                                 .Select(date => date.ToString("MMM-yyyy"))
                                 .ToList();
            this.salaryMonthSelect.DataSource = months;
        }

        private void InitializeRoleComboBox()
        {
            this.roleSelect.DataSource = Enum.GetValues(typeof(Roles));
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.existingUsersGrid.ClearSelection();
            this.modifyRadio.Checked = true;
            checkActionBtnColor();
        }

        private void AddRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.addRadio.Checked)
            {
                this.existingUsersGrid.ClearSelection();
                this.existingUsersGrid.Enabled = false;
                this.nameTxt.Text = "";
                this.emailTxt.Text = "";
                this.pwTxt.Text = "";
                this.confirmPwTxt.Text = "";
                this.salaryGroupBox.Visible = false;
                this.salaryBox.Visible = false;
                this.salaryTotal.Visible = false;
                this.salaryMonthSelect.Visible = false;
                this.salaryMonth.Visible = false;
            }
            checkActionBtnColor();
            removeError();
        }

        private void ModifyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.modifyRadio.Checked)
            {
                this.existingUsersGrid.Enabled = true;
                this.existingUsersGrid.ClearSelection();
                this.nameTxt.Text = "";
                this.emailTxt.Text = "";
                this.pwTxt.Text = "";
                this.confirmPwTxt.Text = "";
                this.salaryGroupBox.Visible = false;
                this.salaryBox.Visible = false;
                this.salaryTotal.Visible = false;
                this.salaryMonthSelect.Visible = false;
                this.salaryMonth.Visible = false;
            }
            checkActionBtnColor();
            removeError();
        }

        private void removeError() {
            this.nameError.Visible = false;
            this.emailError.Visible = false;
            this.passwordError.Visible = false;
            this.confirmPasswordError.Visible = false;
            this.managerError.Visible = false;
        }

        private void checkActionBtnColor()
        {
            if (this.addRadio.Checked)
            {
                this.actionBtn.Text = "Add";
                this.activeRadio.Enabled = false;
                this.inactiveRadio.Enabled = false;
                this.activeRadio.Visible = false;
                this.inactiveRadio.Visible = false;
                this.groupBox2.Visible = false;
            }
            else
            {
                this.actionBtn.Text = "Modify";
                this.activeRadio.Enabled = true;
                this.inactiveRadio.Enabled = true;
                this.activeRadio.Visible = true;
                this.inactiveRadio.Visible = true;
                this.groupBox2.Visible = true;
            }
        }

        private void actionBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Admin Form - Submit", $"Start submit admin form, action performed by {operateStaff.Name}");
            try
            {
                Logger.WriteLog((int)LogLevels.Info, $"Admin Form- ValidateForm", $"Start to validate form, action performed by {operateStaff.Name}");
                bool isAddNew = this.addRadio.Checked;
                if (ValidateAdminForm(isAddNew))
                {
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form- ValidateForm", $"Finish to validate form, action performed by {operateStaff.Name}");
                    string formAction = isAddNew ? "Add new user" : "Modify user";
                    bool isActive = isAddNew ? true : (this.activeRadio.Checked ? true : false);
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Start to {formAction}, staff name : {this.nameTxt.Text}, staff email : {this.emailTxt.Text}, staff role : {this.roleSelect.Text}, active : {isActive}, action performed by {operateStaff.Name}");
                    SubmitUserAction(isAddNew, isActive);
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Finish to {formAction}, staff name : {this.nameTxt.Text}, staff email : {this.emailTxt.Text}, staff role : {this.roleSelect.Text}, active : {isActive}, action performed by {operateStaff.Name}");
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Start to initialize staff list, action performed by {operateStaff.Name}");
                    InitializeAdminData(staffs);
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Finish to initialize staff list, action performed by {operateStaff.Name}");
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Start to write updated staff list to file, action performed by {operateStaff.Name}");
                    SerializationHandler.JsonSerializater(staffs, ConfigurationManager.AppSettings["userFilePath"] + ConfigurationManager.AppSettings["userFile"]);
                    Logger.WriteLog((int)LogLevels.Info, $"Admin Form - {formAction}", $"Finish to write updated staff list to file, action performed by {operateStaff.Name}");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog((int)LogLevels.Error, "Admin Form - Submit", ex);
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "Admin Form - Submit", $"Finish submit admin form, action performed by {operateStaff.Name}");
            }
        }

        private bool ValidateAdminForm(bool isAdd)
        {
            bool isPass = true;

            if (!isAdd)
            {
                if (this.existingUsersGrid.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select an existing user");
                    isPass = false;
                    return isPass;
                }
            }

            if (FunctionUtil.IsEmptyOrNull(this.nameTxt.Text))
            {
                this.nameError.Visible = true;
                isPass = false;
            }
            else
            {
                this.nameError.Visible = false;
            }

            if (FunctionUtil.IsEmptyOrNull(this.emailTxt.Text))
            {
                this.emailError.Visible = true;
                isPass = false;
            }
            else
            {
                Regex regex = new Regex(Parameters.EMAIL_REGEX);
                if (regex.IsMatch(this.emailTxt.Text))
                {
                    this.emailError.Visible = false;
                }
                else
                {
                    this.emailError.Visible = true;
                    this.emailError.Text = "Please input a valid email";
                    isPass = false;
                }
            }

            if (FunctionUtil.IsEmptyOrNull(this.pwTxt.Text))
            {
                this.passwordError.Visible = true;
                isPass = false;
            }
            else
            {
                this.passwordError.Visible = false;
            }

            if (FunctionUtil.IsEmptyOrNull(this.confirmPwTxt.Text))
            {
                this.confirmPasswordError.Visible = true;
                isPass = false;
            }
            else
            {
                this.confirmPasswordError.Visible = false;
            }

            if (!FunctionUtil.IsEmptyOrNull(this.pwTxt.Text) &&
                !FunctionUtil.IsEmptyOrNull(this.confirmPwTxt.Text))
            {
                if (this.pwTxt.Text != this.confirmPwTxt.Text)
                {
                    this.confirmPasswordError.Visible = true;
                    this.confirmPasswordError.Text = "Passwords are not equal";
                    isPass = false;
                }
                else
                {
                    this.confirmPasswordError.Visible = false;
                }
            }

            if (this.isNeedManager && this.managerIdOpt.SelectedIndex == -1)
            {
                this.managerError.Visible = true;
                this.managerError.Text = "Please select manager";
                isPass = false;
            } else {
                this.managerError.Visible = false;
            }

            return isPass;
        }

        private void roleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            determineNeedSelectManager();
        }

        private void determineNeedSelectManager() {
            Roles role;
            if (Enum.TryParse(this.roleSelect.SelectedValue.ToString(), out role) && role == Roles.Accountant)
            {
                this.isNeedManager = true;
                List<Staff> managerStaffs = this.staffs.Where(staff => staff.Role == (int)Roles.Manager).ToList();
                if (managerStaffs != null && managerStaffs.Count > 0)
                {
                    this.managerIdOpt.DataSource = managerStaffs.Select(manager => manager.StaffId).ToList();
                    this.managerIdOpt.Visible = true;
                    this.managerLabel.Visible = true;
                }
                else
                {
                    this.managerIdOpt.Visible = true;
                    this.managerLabel.Visible = true;
                    MessageBox.Show("No manager can be selected");
                }
            }
            else
            {
                this.managerIdOpt.Visible = false;
                this.managerLabel.Visible = false;
                this.isNeedManager = false;
            }
        }

        private void SubmitUserAction(bool addNewUser, bool isActiveUser)
        {
            Logger.WriteLog((int)LogLevels.Info, "Admin Form - SubmitUserAction", $"Start perform user action add new user : {addNewUser}, action performed by {operateStaff.Name}");
            try
            {
                Staff newStaff = null;
                string staffId = null;
                if (!addNewUser)
                {
                    staffId = this.existingUsersGrid.SelectedRows[0].Cells["Staff ID"].Value.ToString();
                    staffs = staffs.Where(staff => staff.StaffId != staffId).ToList();
                }
                if (!ValidateUser() && addNewUser)
                {
                    MessageBox.Show("User already exists");
                    return;
                }
                switch ((Roles)this.roleSelect.SelectedItem)
                {
                    case (Parameters.Roles.Admin):
                        newStaff = new Admin(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), isActiveUser);
                        break;
                    case (Roles.Manager):
                        newStaff = new Manager(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), isActiveUser);
                        break;
                    case (Roles.Accountant):
                        newStaff = new Accountant(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), this.managerIdOpt.SelectedValue.ToString(), isActiveUser);
                        break;
                    default:
                        throw new Exception($"Invalid user role - {this.roleSelect.SelectedItem}");
                }
                staffs.Add(newStaff);
                Logger.WriteLog((int)LogLevels.Info, "Admin Form - SubmitUserAction", $"Start perform user action add new user : {addNewUser}, " +
                    $" ,staff name {newStaff.Name}, staff id {newStaff.StaffId}, staff email {newStaff.Email}, staff role : {newStaff.Role}, active : {newStaff.IsActive}" +
                    $" ,action performed by {operateStaff.Name}");
            }
            catch (Exception e)
            {
                Logger.WriteLog((int)LogLevels.Error, "Admin Form - SubmitUserAction", e);
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "Admin Form - SubmitUserAction", $"Finish perform user action add new user : {addNewUser}, action performed by {operateStaff.Name}");
            }
        }

        private bool ValidateUser()
        {
            List<Staff> duplicatedStaffs = staffs.Where(staff => string.Compare(staff.Name, this.nameTxt.Text, true) == 0).ToList();
            return (duplicatedStaffs == null || duplicatedStaffs.Count == 0);
        }

        //Accountant Tab methods

        private void InitializeAccountantData(Staff staff)
        {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - InitializeAccountantData", $"Start initialize accountant form data with staff : {operateStaff.StaffId}");
            this.generalEntryGrid.DefaultCellStyle = dataGridViewCellStyle;
            this.generalEntryGrid.ColumnHeadersDefaultCellStyle = dataGridViewHeaderStyle;
            this.generalEntryGrid.Rows.Clear();
            this.generalEntryGrid.Columns.Clear();
            this.selectMonth.DataSource = GetAvaliableMonth();
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - InitializeAccountantData", $"Get account data from file with staff : {operateStaff.StaffId}");
            accounts = SerializationHandler.JsonDeserialization<List<string>>(ConfigurationManager.AppSettings["accountFilePath"] +
                                                                       ConfigurationManager.AppSettings["accountFile"]);
            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //comboBoxColumn.Name = "Account";
            //comboBoxColumn.HeaderText = "Account";
            //comboBoxColumn.DataSource = accounts;
            //this.generalEntryGrid.Columns.Add(comboBoxColumn);
            //DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)this.generalEntryGrid.Columns["Account"];
            //dataGridViewComboBoxColumn.DataSource = accounts;

            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - InitializeAccountantData", $"Create header of the data grid view with staff : {operateStaff.StaffId}");
            foreach (string header in Parameters.ACCOUNT_HEADERS)
            {
                switch (header)
                {
                    case "Date":
                        CalendarColumn calendarCol = new CalendarColumn();
                        calendarCol.Name = header;
                        calendarCol.HeaderText = header;
                        this.generalEntryGrid.Columns.Add(calendarCol);
                        break;
                    case "Status":
                    case "Comment":
                        this.generalEntryGrid.Columns.Add(header, header);
                        this.generalEntryGrid.Columns[header].ReadOnly = true;
                        break;
                    default:
                        this.generalEntryGrid.Columns.Add(header, header);
                        break;
                }
            }

            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - InitializeAccountantData", $"Get entries data from file with staff : {operateStaff.StaffId}");
            DisplayEntryData();
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - InitializeAccountantData", $"Finish initialize accountant form data with staff : {operateStaff.StaffId}");
        }

        private List<string> GetAvaliableMonth() {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - GetAvaliableMonth", $"Start to get avaliable months (half year) with staff : {operateStaff.StaffId}");
            List<string> availableMonth = new List<string>();
            DateTime minMonth = DateTime.Today.AddMonths(-6);
            while (minMonth <= DateTime.Today)
            {
                availableMonth.Add(minMonth.ToString(Parameters.MONTH_OPTION_FORMAT));
                minMonth = minMonth.AddMonths(1);
            }
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - GetAvaliableMonth", $"Finish to get avaliable months (half year) with staff : {operateStaff.StaffId}");
            return availableMonth;
        }

        private void generalEntryGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.RowIndex >= 0 && dgv.CurrentCell.ColumnIndex > 0)
            {
                TextBox tb = (TextBox)e.Control;
                e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                tb.AutoCompleteMode = AutoCompleteMode.None;
                tb.AutoCompleteSource = AutoCompleteSource.None;
                tb.AutoCompleteCustomSource = null;
                tb.CharacterCasing = CharacterCasing.Normal;
                if (dgv.CurrentCell.OwningColumn.Name == "Account")
                {
                    autoCompleteCollection.AddRange(accounts.ToArray());
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteCollection;
                    tb.CharacterCasing = CharacterCasing.Upper;
                }

                if (dgv.CurrentCell.OwningColumn.Name == "Credit" ||
                    dgv.CurrentCell.OwningColumn.Name == "Debit")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }

        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-'
                && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void saveEntryBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"Start to save input entries with staff : {operateStaff.StaffId}");
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"Start validate entries with staff : {operateStaff.StaffId}");
            Dictionary<string,object> errorDict = ValidateGeneralEntry();
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"Finish to validate entries with staff : {operateStaff.StaffId}");
            if ((bool)errorDict["hasError"]) { 
                string errorString = FunctionUtil.GetErrorFromDictionary(errorDict);
                MessageBox.Show(this, errorString);
                return;
            }
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"Generate confirm dialog to ask for confirmation with staff : {operateStaff.StaffId}");
            DialogResult result = MessageBox.Show(this, "Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"User confirms the submission with staff : {operateStaff.StaffId}");
                SubmitEntries();
            }
            DisplayEntryData();
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SaveForm", $"Finish to save input entries with staff : {operateStaff.StaffId}");
            //HashSet<string> newAccounts = new HashSet<string>();
            //var test = FunctionUtil.TransferEntriesToObjects(this.generalEntryGrid, operateStaff.StaffId, accounts, this.selectMonth.SelectedValue.ToString());
            /*for (int i=0; i < this.generalEntryGrid.RowCount -1; i++) { 
                DataGridViewRow row = this.generalEntryGrid.Rows[i];
                DateTime entryDate = Convert.ToDateTime(row.Cells[0].Value.ToString());
                string entryAccount = row.Cells[1].Value.ToString();
                string entryDesc = row.Cells[2].Value.ToString();
                decimal entryCredit = FunctionUtil.IsCellEmptyOrNUll(row.Cells[3]) ? decimal.Zero : decimal.Parse(row.Cells[3].Value.ToString());
                decimal entryDebit = FunctionUtil.IsCellEmptyOrNUll(row.Cells[4]) ? decimal.Zero : decimal.Parse(row.Cells[4].Value.ToString());

            }*/
        }

        private void generalEntryGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Rectangle rectangle = new Rectangle(e.RowBounds.Left,
                                                e.RowBounds.Top,
                                                dgv.RowHeadersWidth,
                                                e.RowBounds.Height);
            SolidBrush brush = new SolidBrush(this.generalEntryGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, rectangle, sf);
        }

        private void selectMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.generalEntryGrid.Columns != null && this.generalEntryGrid.Columns.Count > 0)
            {
                DisplayEntryData();
            }
        }

        private void DisplayEntryData() {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Start to retrieve data from files with staff : {operateStaff.StaffId}");
            this.generalEntryGrid.Rows.Clear();
            //int selectedMonth = DateTime.Parse(this.selectMonth.SelectedValue.ToString()).Month;
            //int selectedYear = DateTime.Parse(this.selectMonth.SelectedValue.ToString()).Year;
            DateTime startDate = DateTime.Parse("01-" + this.selectMonth.SelectedValue.ToString());
            DateTime endDate = DateTime.Parse("01-" + this.selectMonth.SelectedValue.ToString()).AddMonths(+1);
            //string entryFile = ConfigurationManager.AppSettings["generalEntryFilePath"] + this.operateStaff.StaffId + @"\" + ConfigurationManager.AppSettings["generalEntryFile"];
            List<AccountEntry> entries = this.generalEntry.RetrieveEnrties(operateStaff.StaffId, startDate, endDate, true, 4, null);
            if (entries != null && entries.Count > 0) {
                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Entries from files is not null with staff : {operateStaff.StaffId}");
                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Generate data in dataGridView with staff : {operateStaff.StaffId}");
                foreach (AccountEntry entry in entries)
                {
                    object[] rowData = { entry.EntryDate, entry.Account, entry.Description, entry.IsCredit ? entry.Amount.ToString() : null, !entry.IsCredit ? entry.Amount.ToString() : null, (RecordStatus)entry.Status , entry.Reason};
                    int rowIndex = this.generalEntryGrid.Rows.Add(rowData);
                    this.generalEntryGrid.Rows[rowIndex].Tag = entry;
                    if (entry.Status != (int)RecordStatus.Rejected)
                    {
                        this.generalEntryGrid.Rows[rowIndex].ReadOnly = true;
                    }
                }
            }
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Finish to retrieve data from file with staff : {operateStaff.StaffId}");
            //List<AccountEntry> entries = SerializationHandler.JsonDeserialization<List<AccountEntry>>(entryFile);
            //if (entries != null && entries.Count > 0)
            //{
            //    Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Entries from files is not null with staff : {operateStaff.StaffId}");
            //    entries = entries.Where(entry => entry.EntryDate.Month == selectedMonth &&
            //                                 entry.EntryDate.Year == selectedYear)
            //                               .ToList();
            //    Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Generate data in dataGridView with staff : {operateStaff.StaffId}");
            //    foreach (AccountEntry entry in entries)
            //    {
            //        object[] rowData = { entry.EntryDate, entry.Account, entry.Description, entry.IsCredit ? entry.Amount.ToString() : null, !entry.IsCredit ? entry.Amount.ToString() : null, (RecordStatus) entry.Status };
            //        int rowIndex = this.generalEntryGrid.Rows.Add(rowData);
            //        if (entry.Status != (int)RecordStatus.Rejected) {
            //            this.generalEntryGrid.Rows[rowIndex].ReadOnly = true;
            //        }
            //    }
            //    Logger.WriteLog((int)LogLevels.Info, "Accountant Form - DisplayEntryData", $"Finish to retrieve data from file with staff : {operateStaff.StaffId}");
            //}
        }

        private void SubmitEntries()
        {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Start to submit entries with staff : {operateStaff.StaffId}");
            string generalEntryFolder = ConfigurationManager.AppSettings["generalEntryFilePath"] + this.operateStaff.StaffId;
            string generalEntryFile = generalEntryFolder + @"\" +ConfigurationManager.AppSettings["generalEntryFile"];
            string accountFilePath = ConfigurationManager.AppSettings["accountFilePath"] + ConfigurationManager.AppSettings["accountFile"];
            Dictionary<string, string> accountFolderDict = new Dictionary<string, string>();
            //List<AccountEntry> entries = new List<AccountEntry>();
            //List<AccountEntry> orgEntries = new List<AccountEntry>();
            HashSet<string> megredAccounts = MegreAccount();
            //foreach (string account in accounts) {   
            //    accountFolderDict.Add(account, ConfigurationManager.AppSettings["accountEntryFilePath"] + account + @"\" + entryMonth);
            //}
            //or use lambda
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Merge existing accounts with new added accounts with staff : {operateStaff.StaffId}");
            accountFolderDict = megredAccounts.ToDictionary(
                                    megredAccount => megredAccount,
                                    megredAccount => ConfigurationManager.AppSettings["accountEntryFilePath"] + megredAccount);

            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Write merged accounts to file with staff : {operateStaff.StaffId}");
            SerializationHandler.JsonSerializater(megredAccounts, accountFilePath);

            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Loop through dataGridView to create entry objects with staff : {operateStaff.StaffId}");
            List<AccountEntry> allEntries = this.generalEntry.RetrieveEnrties(operateStaff.StaffId, DateTime.MinValue, DateTime.MaxValue, true, 4, null);

            if (this.generalEntryGrid != null && this.generalEntryGrid.RowCount > 0)
            {
                for (int i = 0; i < this.generalEntryGrid.RowCount - 1; i++)
                {
                    DataGridViewRow row = this.generalEntryGrid.Rows[i];
                    string entryId = null;
                    DateTime entryDate = Convert.ToDateTime(row.Cells[0].Value.ToString());
                    string entryAccount = row.Cells[1].Value.ToString();
                    string entryDesc = row.Cells[2].Value.ToString();
                    decimal entryCredit = FunctionUtil.IsCellEmptyOrNUll(row.Cells[3]) ? decimal.Zero : decimal.Parse(row.Cells[3].Value.ToString());
                    decimal entryDebit = FunctionUtil.IsCellEmptyOrNUll(row.Cells[4]) ? decimal.Zero : decimal.Parse(row.Cells[4].Value.ToString());
                    bool isCredit = (entryCredit.CompareTo(decimal.Zero) == 0 ? false : true);
                    decimal amount = isCredit ? entryCredit : entryDebit;

                    if (row.Tag != null)
                    {
                        AccountEntry existingEntry = (AccountEntry)row.Tag;
                        entryId = existingEntry.EntryId;
                        int index = allEntries.FindIndex(entry =>
                                                         entry.EntryId == entry.EntryId);
                        if (allEntries[index].EntryId == existingEntry.EntryId &&
                           !existingEntry.EqualValue(entryDate, entryAccount, entryDesc, amount, isCredit, entryId))
                        {                            
                            allEntries[index].ResubmitEntry(entryDate, entryDesc, amount, isCredit, entryAccount, operateStaff.StaffId);
                        } 
                    } else {
                        AccountEntry newEntry = new AccountEntry(entryDate, entryDesc, isCredit ? entryCredit : entryDebit,
                                                                 operateStaff.StaffId, isCredit, entryAccount, entryId,
                                                                 operateStaff.ManagerId);
                        allEntries.Add(newEntry);
                    }
                }
            }

            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"write entry objects to file {generalEntryFile} with staff : {operateStaff.StaffId}");
            FunctionUtil.CreateFolder(generalEntryFolder);
            SerializationHandler.JsonSerializater(allEntries, generalEntryFile);
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Finish to submt entries with staff : {operateStaff.StaffId}");

            //Get the original objects
            //if (File.Exists(generalEntryFile))
            //{
            //    int selectedMonth = DateTime.Parse(this.selectMonth.SelectedValue.ToString()).Month;
            //    int selectedYear = DateTime.Parse(this.selectMonth.SelectedValue.ToString()).Year;
            //    orgEntries = SerializationHandler.JsonDeserialization <List<AccountEntry>>(generalEntryFile);
            //    orgEntries = orgEntries.Where(orgEntry => orgEntry.EntryDate.Year != selectedYear &&
            //                                              orgEntry.EntryDate.Month != selectedMonth).ToList();
            //}
            //orgEntries.AddRange(entries);
            //FunctionUtil.CreateFolder(generalEntryFolder);
            //SerializationHandler.JsonSerializater(orgEntries, generalEntryFile);
            //Logger.WriteLog((int)LogLevels.Info, "Accountant Form - SubmitEntries", $"Finish to submt entries with staff : {operateStaff.StaffId}");

            /*
            FunctionUtil.CreateFolder(generalEntryFolder);
            List<GeneralEntry> generalEntries = new List<GeneralEntry>();
            GeneralEntry generalEntry = new GeneralEntry(this.operateStaff.StaffId, DateTime.Parse("01" + this.selectMonth.SelectedValue.ToString()));
            generalEntry.AddEntries(entries);
            if (File.Exists(generalEntryFile)) {
                generalEntries = ObjectHandler.JsonDeserialization<List<GeneralEntry>>(generalEntryFile);
                foreach (GeneralEntry ge in generalEntries)
                {
                    Console.WriteLine("before ge month " + ge.EntryMonth);
                }
                if (generalEntries != null) {
                    generalEntries = generalEntries
                                        .Where(resultEntry => resultEntry.EntryMonth.Date != DateTime.Parse("01" + this.selectMonth.SelectedValue.ToString()).Date)
                                        .ToList();
                }
                foreach (GeneralEntry ge in generalEntries) {
                    Console.WriteLine("ge month " + ge.EntryMonth);
                }
                generalEntries.Add(generalEntry);
            } else {
                generalEntries.Add(generalEntry);
            };
            ObjectHandler.JsonSerializater(generalEntries, generalEntryFile);

            foreach (KeyValuePair<string, string> accountEntry in accountFolderDict)
            {
                FunctionUtil.CreateFolder(accountEntry.Value);
                string accountFile = accountEntry.Value + @"\" + ConfigurationManager.AppSettings["accountEntryFile"];
                Account accountRecord = File.Exists(accountFile) ?
                    ObjectHandler.JsonDeserialization<Account>(accountFile) :
                    accountRecord = new Account(accountEntry.Key);
                List<Entry> accountEntries = entries.Where(entry => string.Compare(entry.Account, accountEntry.Key) == 0).ToList();
                if (accountEntries != null || accountEntries.Count > 0) { 
                    accountRecord.AddEntries(accountEntries);
                    ObjectHandler.JsonSerializater(accountRecord, accountFile);
                }
            }*/
        }

        private HashSet<string> MegreAccount()
        {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - MegreAccount", $"Start to submt existing accounts with new accounts with staff : {operateStaff.StaffId}");
            HashSet<String> mergedAccounts = new HashSet<string>();
            mergedAccounts = this.generalEntryGrid.Rows
                                        .OfType<DataGridViewRow>()
                                        .Where(row => !FunctionUtil.IsCellEmptyOrNUll(row.Cells[1]))
                                        .Select(row => row.Cells[1].Value.ToString())
                                        .ToHashSet();
            mergedAccounts.UnionWith(this.accounts);
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - MegreAccount", $"Finish to submt existing accounts with new accounts with staff : {operateStaff.StaffId}");
            return mergedAccounts;
        }

        private void generalEntryGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DateTime defaultDate = DateTime.Parse("01" + this.selectMonth.SelectedValue.ToString());
            int rowIndex = this.generalEntryGrid.Rows.Count - 1;
            if (rowIndex >= 0) {
                this.generalEntryGrid.Rows[rowIndex].Cells["Date"].Value = defaultDate;
            }
        }

        private Dictionary<string, object> ValidateGeneralEntry()
        {
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Start to validate entries with staff : {operateStaff.StaffId}");
            DataGridView dataGridView = this.generalEntryGrid;
            Dictionary<string, object> errorDict = new Dictionary<string, object>();
            errorDict.Add("hasError", false);
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Validate if there is no entries at all with staff : {operateStaff.StaffId}");
            if ((dataGridView.RowCount - 1) == 0)
            {
                errorDict["hasError"] = true;
                errorDict.Add("Error", "The entry is empty.");
                return errorDict;
            }
            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                string rowError = "";
                bool hasError = false;

                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Validate {i+1} row Date column with staff : {operateStaff.StaffId}");
                if (FunctionUtil.IsCellEmptyOrNUll(row.Cells[0])){
                    rowError += "Date is empty. ";
                    hasError = true;
                } else {
                    DateTime entryDate = DateTime.Parse(row.Cells[0].Value.ToString());
                    DateTime selectedMonth = DateTime.Parse("01-" + this.selectMonth.SelectedValue.ToString());
                    if (entryDate.Year != selectedMonth.Year ||
                        entryDate.Month != selectedMonth.Month) {
                        rowError += "Selected date is out of range. ";
                        hasError = true;
                    }

                }

                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Validate {i + 1} row Account column with staff : {operateStaff.StaffId}");
                if (FunctionUtil.IsCellEmptyOrNUll(row.Cells[1]))
                {
                    rowError += "Account is empty. ";
                    hasError = true;
                }

                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Validate {i + 1} row Description column with staff : {operateStaff.StaffId}");
                if (FunctionUtil.IsCellEmptyOrNUll(row.Cells[2]))
                {
                    rowError += "Description is empty. ";
                    hasError = true;
                }

                Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Validate {i + 1} row Credit and Debit column with staff : {operateStaff.StaffId}");
                if (FunctionUtil.IsCellEmptyOrNUll(row.Cells[3]) && FunctionUtil.IsCellEmptyOrNUll(row.Cells[4]))
                {
                    rowError += "Either Credit or Debit must have value. ";
                    hasError = true;
                }
                else if (!FunctionUtil.IsCellEmptyOrNUll(row.Cells[3]) && !FunctionUtil.IsCellEmptyOrNUll(row.Cells[4]))
                {
                    rowError += "Both Credit and Debit cannot have values at the same time. ";
                    hasError = true;
                }
                else
                {
                    if (!FunctionUtil.IsCellEmptyOrNUll(row.Cells[3]) &&
                        !decimal.TryParse(row.Cells[3].Value.ToString(), out decimal credit))
                    {
                        rowError += "Credit is invalid. ";
                        hasError = true;
                    }

                    if (!FunctionUtil.IsCellEmptyOrNUll(row.Cells[4]) &&
                        !decimal.TryParse(row.Cells[4].Value.ToString(), out decimal debit))
                    {
                        rowError += "Debit is invalid";
                        hasError = true;
                    }
                }

                if (hasError)
                {
                    errorDict.Add($"Row {i + 1}", rowError + System.Environment.NewLine);
                    errorDict["hasError"] = true;
                }

            }
            Logger.WriteLog((int)LogLevels.Info, "Accountant Form - ValidateGeneralEntry", $"Finish to validate entries with staff : {operateStaff.StaffId}");
            return errorDict;
        }

        private void generalEntryGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!FunctionUtil.IsCellEmptyOrNUll(this.generalEntryGrid.Rows[e.Row.Index].Cells[5]) &&
                !FunctionUtil.IsEmptyOrNull(this.generalEntryGrid.Rows[e.Row.Index].Cells[5].Value.ToString()))
            {
                e.Cancel = true;
            }
        }

        /*
        private void generalEntryGrid_CellClick(object sender, DataGridViewCellEventArgs e){
            if (e.RowIndex >=0 && e.ColumnIndex == 0){
                
                dateTimePicker = new DateTimePicker();
                this.generalEntryGrid.Controls.Add(dateTimePicker);
                dateTimePicker.Format = DateTimePickerFormat.Short;
                Rectangle rectangle = this.generalEntryGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height);
                dateTimePicker.Location = new Point(rectangle.X, rectangle.Y);
                dateTimePicker.CloseUp += new EventHandler(datetimepicker_closeup);
                dateTimePicker.TextChanged +=(dtSender, dtEvent) => datetimepicker_textchange(sender, e, e.RowIndex, e.ColumnIndex);
                dateTimePicker.Visible = true;
        }
        private void datetimepicker_textchange(object sender, EventArgs e, int rowIndex, int columnIndex){
            this.generalEntryGrid[columnIndex, rowIndex].Value = dateTimePicker.Text.ToString();
        }
        private void datetimepicker_closeup(object sender, EventArgs e){
            dateTimePicker.Visible = false;
        }
        */


        //Method for manager tab
        private void InitializeManagerData() {
            if (!this.managerAccountOpt.Checked &&
                !this.managerAccountOpt.Checked &&
                !this.managerDashBoardOpt.Checked)
            {
                this.managerDashBoardOpt.Checked = true;
            }
        }

        private void managerDashBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.managerDashBoardOpt.Checked) InitializeDashBoard();
        }

        private void InitializeDashBoard() {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - InitializeDashBoard", $"Start to initialize dash board with staff : {operateStaff.StaffId}");
            this.managerGridView.Columns.Clear();
            this.managerGridView.Rows.Clear();
            this.categoryLabel.Visible = false;
            this.categoryComboBox.Visible = false;
            this.fromLabel.Visible = false;
            this.fromDateTime.Visible = false;
            this.toLabel.Visible = false;
            this.toDateTime.Visible = false;
            this.generateBtn.Visible = false;
            RetrieveRecord();
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - InitializeDashBoard", $"Finish to initialize dash board with staff : {operateStaff.StaffId}");
        }

        private void managerEntryOpt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.managerEntryOpt.Checked)
            {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - managerEntryOpt_CheckedChanged", $"Start to initialize when manager option is selected with staff : {operateStaff.StaffId}");
                this.managerGridView.Columns.Clear();
                this.managerGridView.Rows.Clear();
                this.categoryLabel.Visible = true;
                this.categoryComboBox.Visible = true;
                this.fromLabel.Visible = true;
                this.fromDateTime.Visible = true;
                this.toLabel.Visible = true;
                this.toDateTime.Visible = true;
                this.generateBtn.Visible = true;

                List<Staff> staffs = SerializationHandler.JsonDeserialization();
                staffs.RemoveAll(staff => staff.Role != (int)Roles.Accountant);
                this.categoryLabel.Text = "Staff ID : ";
                this.categoryComboBox.DataSource = staffs.Select(staff => staff.StaffId).ToList();
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - managerEntryOpt_CheckedChanged", $"Finish to initialize when manager option is selected with staff : {operateStaff.StaffId}");

            }
        }

        private void managerAccountOpt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.managerAccountOpt.Checked)
            {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - managerAccountOpt_CheckedChanged", $"Start to initialize when account option is selected with staff : {operateStaff.StaffId}");
                this.managerGridView.Columns.Clear();
                this.managerGridView.Rows.Clear();
                this.categoryLabel.Visible = true;
                this.categoryComboBox.Visible = true;
                this.fromLabel.Visible = true;
                this.fromDateTime.Visible = true;
                this.toLabel.Visible = true;
                this.toDateTime.Visible = true;
                this.generateBtn.Visible = true;

                List<string> accounts = SerializationHandler
                                        .JsonDeserialization<List<string>>(ConfigurationManager.AppSettings["accountFilePath"] +
                                                                           ConfigurationManager.AppSettings["accountFile"]);
                this.categoryLabel.Text = "Account : ";
                this.categoryComboBox.DataSource = accounts;
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - managerAccountOpt_CheckedChanged", $"Finish to initialize when account option is selected with staff : {operateStaff.StaffId}");

            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - generateBtn_Click", $"Start to process when generate button is clicked with staff : {operateStaff.StaffId}");
            Dictionary<string, object> errDict = ValidateManagerTab();
            if ((bool)errDict["hasError"]) {
                string errorMessage = FunctionUtil.GetErrorFromDictionary(errDict);
                MessageBox.Show(this, errorMessage);
                return;
            }
            RetrieveRecord(); 
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - generateBtn_Click", $"Finish to process when generate button is clicked with staff : {operateStaff.StaffId}");
        }

        private void fromDateTime_ValueChanged(object sender, EventArgs e)
        {
            this.toDateTime.MinDate = this.fromDateTime.Value;
        }

        private Dictionary<string, object> ValidateManagerTab() {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - generateBtn_Click", $"Start to validate selected option with staff : {operateStaff.StaffId}");
            Dictionary<string, object> errorDict = new Dictionary<string, object>();
            errorDict.Add("hasError", false);
            int errorIndex = 1;
            DateTime fromDt = this.fromDateTime.Value;
            DateTime toDt = this.toDateTime.Value;
            if (fromDt > toDt)
            {
                errorDict["hasError"] = true;
                errorDict.Add(errorIndex.ToString(), "From Date cannnot be greater than To Date");
            }
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - generateBtn_Click", $"Finish to validate selected option with staff : {operateStaff.StaffId}");
            return errorDict;
        }

        private void RetrieveRecord() {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Start to call retrieve record method with staff : {operateStaff.StaffId}");
            string staffId = operateStaff.StaffId;
            DateTime fromDate = this.fromDateTime.Value;
            DateTime toDate = this.toDateTime.Value;
            bool isAllRecord = true;
            int status = (int)RecordStatus.Pending;
            string accountName = "";
            bool isAccountTag = false;
            Func<string, DateTime, DateTime, bool, int, string, List<AccountEntry>> getEntryMethod = this.generalEntry.RetrieveEnrties;
            if (this.managerAccountOpt.Checked) {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Account option with staff : {operateStaff.StaffId}");
                accountName = this.categoryComboBox.SelectedValue.ToString();
                isAccountTag = true;
                getEntryMethod = this.accountEntry.RetrieveEnrties;
            } else if (this.managerEntryOpt.Checked) {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Entry option with staff : {operateStaff.StaffId}");
                staffId = this.categoryComboBox.SelectedValue.ToString();
            } else if (this.managerDashBoardOpt.Checked){
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Dashboard option with staff : {operateStaff.StaffId}");
                fromDate = DateTime.MinValue;
                toDate = DateTime.MaxValue;
                isAllRecord = false;
            }

            Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Start to call GenerateManagerGrid with staff : {operateStaff.StaffId}");
            GenerateManagerGrid(getEntryMethod, staffId, fromDate, toDate, isAllRecord, status, accountName, isAccountTag);
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - RetrieveRecord", $"Finish to call retrieve record method with staff : {operateStaff.StaffId}");
        }
        //private void GenerateManagerGrid() {
        //Rewrite using delegate
        private void GenerateManagerGrid(Func<string, DateTime, DateTime, bool, int, string, List<AccountEntry>> getEntries, string staffId, DateTime fromDate, DateTime toDate, bool allRecord, int status, string accountName, bool isAccountTag)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Start to generate manager grid view with staff : {operateStaff.StaffId}");
            this.managerGridView.DefaultCellStyle = dataGridViewCellStyle;
            this.managerGridView.ColumnHeadersDefaultCellStyle = dataGridViewHeaderStyle;
            this.managerGridView.Rows.Clear();
            this.managerGridView.Columns.Clear();
            decimal totalCredit = decimal.Zero;
            decimal totalDebit = decimal.Zero;
            List<AccountEntry> accountEntries = getEntries(staffId, fromDate, toDate, allRecord, status, accountName);
            /*
            if (this.managerAccountOpt.Checked)
            { 
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Account option is checked with staff : {operateStaff.StaffId}");
                accountEntries = this.accountEntry.RetrieveEnrties(this.operateStaff.StaffId, this.fromDateTime.Value, this.toDateTime.Value, true, 4, this.categoryComboBox.SelectedValue.ToString());
                isAccountTag = true;
            } else if (this.managerEntryOpt.Checked) {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Entry option is checked with staff : {operateStaff.StaffId}");
                accountEntries = this.generalEntry.RetrieveEnrties(this.categoryComboBox.SelectedValue.ToString(), this.fromDateTime.Value, this.toDateTime.Value, true, 4, null);
            } else {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"DashBoard option is checked with staff : {operateStaff.StaffId}");
                accountEntries = this.generalEntry.RetrieveEnrties(this.operateStaff.StaffId, DateTime.MinValue, DateTime.MaxValue, false, (int)RecordStatus.Pending, null);
                //this.managerDashBoardOpt.Checked = true;
            }
            */

            Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Stat to generate header with staff : {operateStaff.StaffId}");
            foreach (string header in Parameters.MANAGER_HEADERS) {
                switch (header){
                    case "Select":
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        CheckBoxHeaderCell checkBoxHeader = new CheckBoxHeaderCell();
                        checkBoxHeader.OnCheckBoxHeaderClick += checkBoxHeader_OnCheckBoxHeaderClick;
                        checkBoxColumn.HeaderCell = checkBoxHeader;
                        checkBoxColumn.Name = header;
                        this.managerGridView.Columns.Add(checkBoxColumn);
                        break;
                    case "Comment":
                        this.managerGridView.Columns.Add(header, header);
                        break;
                    default:
                        this.managerGridView.Columns.Add(header, header);
                        this.managerGridView.Columns[header].ReadOnly = true;
                        break;
                }
            }

            Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Stat to generate rows with staff : {operateStaff.StaffId}");
            if (accountEntries != null && accountEntries.Count > 0) 
            {
                this.managerGridView.Rows.Clear();
                foreach (AccountEntry entry in accountEntries)
                {
                    object[] rowData = { false, entry.EntryDate, entry.CreateUser, entry.Account, entry.Description, entry.IsCredit ? entry.Amount.ToString() : null, !entry.IsCredit ? entry.Amount.ToString() : null, (RecordStatus)entry.Status, entry.Reason };
                    int rowIndex = this.managerGridView.Rows.Add(rowData);
                    this.managerGridView.Rows[rowIndex].Tag = entry;
                    if (entry.Status != (int)RecordStatus.Pending)
                    {
                        this.managerGridView.Rows[rowIndex].ReadOnly = true;
                    }
                    if (entry.IsCredit){
                        totalCredit = decimal.Add(totalCredit, entry.Amount);
                    } else {
                        totalDebit = decimal.Add(totalDebit, entry.Amount);
                    }
                }

                if (isAccountTag)
                {
                    Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Is account tag generate total debit and credit with staff : {operateStaff.StaffId}");
                    object[] rowData = { false, "", "", "", "Total", totalCredit, totalDebit, null, null };
                    int rowIndex = this.managerGridView.Rows.Add(rowData);
                    this.managerGridView.Rows[rowIndex].ReadOnly = true;
                    //this.managerGridView.Rows[rowIndex].Tag =
                    //    new AccountEntry(DateTime.Today, "", decimal.Zero, this.operateStaff.StaffId, true, "", null, DateTime.Today, null, this.operateStaff.ManagerId, DateTime.Now, (int)RecordStatus.Approved, null); ;
                }
            }
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - GenerateManagerGrid", $"Finish to generate manager grid view with staff : {operateStaff.StaffId}");
        }
        private void checkBoxHeader_OnCheckBoxHeaderClick(CheckBoxHeaderCellEventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - checkBoxHeader_OnCheckBoxHeaderClick", $"Start Checked all was selected with staff : {operateStaff.StaffId}");
            this.managerGridView.BeginEdit(true);
            foreach (DataGridViewRow item in this.managerGridView.Rows)
            {
                AccountEntry accountEntry = (AccountEntry) item.Tag;
                if (accountEntry != null && accountEntry.Status == (int) RecordStatus.Pending) {
                    item.Cells[0].Value = e.IsChecked;
                }
            }
            this.managerGridView.EndEdit();
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - checkBoxHeader_OnCheckBoxHeaderClick", $"Finish Checked all was selected with staff : {operateStaff.StaffId}");
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - approveBtn_Click", $"Start to approve entries with staff : {operateStaff.StaffId}");
            bool hasRecordSelected = false;
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - approveBtn_Click", $"Check all entries are valid with staff : {operateStaff.StaffId}");
            foreach (DataGridViewRow row in this.managerGridView.Rows) {
                int rowIndex = row.Index;
                if ((bool) row.Cells["Select"].Value) {
                    string approveReason = null;
                    if (!FunctionUtil.IsCellEmptyOrNUll(row.Cells["Comment"]) &&
                        !FunctionUtil.IsEmptyOrNull(row.Cells["Comment"].Value.ToString())) {
                        approveReason = row.Cells["Comment"].Value.ToString();
                    }
                    Logger.WriteLog((int)LogLevels.Info, "Manager Form - approveBtn_Click", $"Update entry with staff : {operateStaff.StaffId}");
                    this.UpdateEntryStatus((AccountEntry) row.Tag, operateStaff.StaffId, (int)RecordStatus.Approved, approveReason);
                    hasRecordSelected = true;
                }
            }

            if (!hasRecordSelected) {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - approveBtn_Click", $"No records were selected with staff : {operateStaff.StaffId}");
                MessageBox.Show(this, "No record selected");
                return;
            }
            RetrieveRecord();
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - approveBtn_Click", $"Finish to approve entries with staff : {operateStaff.StaffId}");
        }
        private void UpdateEntryStatus(AccountEntry entry, string actionStaffId, int status, string reason)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - UpdateEntryStatus", $"Start to update entry with staff : {operateStaff.StaffId}");
            string filePath = ConfigurationManager.AppSettings["generalEntryFilePath"] +
                              @"\" + entry.CreateUser + @"\" +
                              ConfigurationManager.AppSettings["generalEntryFile"];
            if (File.Exists(filePath))
            {
                List<AccountEntry> existingEntries = SerializationHandler.JsonDeserialization<List<AccountEntry>>(filePath);
                if (existingEntries != null && existingEntries.Count > 0)
                {
                    int index = existingEntries.FindIndex(existingEntry =>
                                                    existingEntry.EntryId == entry.EntryId &&
                                                    existingEntry.Status == (int)RecordStatus.Pending);
                    if (index >= 0)
                    {
                        existingEntries[index].SetStatus(status, actionStaffId, reason);
                    }
                    Logger.WriteLog((int)LogLevels.Info, "Manager Form - UpdateEntryStatus", $"Start to serialize entry to file with staff : {operateStaff.StaffId}");
                    SerializationHandler.JsonSerializater<List<AccountEntry>>(existingEntries, filePath);
                }
            }            
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - rejectBtn_Click", $"Start to process reject entries with staff : {operateStaff.StaffId}");
            //Another way to validate 
            List<DataGridViewRow> selectedRows = this.managerGridView.Rows.Cast<DataGridViewRow>()
                                                  .Where(row => Convert.ToBoolean(row.Cells["Select"].Value) == true)
                                                  .ToList();
            if (selectedRows == null || selectedRows.Count == 0)
            {
                MessageBox.Show(this, "No record selected");
                return;
            }

            Logger.WriteLog((int)LogLevels.Info, "Manager Form - rejectBtn_Click", $"Generate selected reject entries with staff : {operateStaff.StaffId}");
            selectedRows = this.managerGridView.Rows.Cast<DataGridViewRow>()
                                                    .Where(row => Convert.ToBoolean(row.Cells["Select"].Value) == true &&
                                                                 (FunctionUtil.IsCellEmptyOrNUll(row.Cells["Comment"]) ||
                                                                  FunctionUtil.IsEmptyOrNull(row.Cells["Comment"].Value.ToString())))
                                                    .ToList();
            if (selectedRows != null && selectedRows.Count > 0)
            {
                Logger.WriteLog((int)LogLevels.Info, "Manager Form - rejectBtn_Click", $"At least one of the entries has no record with staff : {operateStaff.StaffId}");
                List<int> rejectWithoutReason = selectedRows.Select(row => row.Index+1).ToList();
                string errorMsg = $"Row : {string.Join(",", rejectWithoutReason)} does not provide reason";
                MessageBox.Show(this, errorMsg);
                return;
            }

            foreach (DataGridViewRow row in this.managerGridView.Rows)
            {
                int rowIndex = row.Index;
                if ((bool)row.Cells["Select"].Value)
                {
                    string rejectReason = null;
                    if (!FunctionUtil.IsCellEmptyOrNUll(row.Cells["Comment"]) &&
                        !FunctionUtil.IsEmptyOrNull(row.Cells["Comment"].Value.ToString()))
                    {
                        rejectReason = row.Cells["Comment"].Value.ToString();
                    }
                    Logger.WriteLog((int)LogLevels.Info, "Manager Form - rejectBtn_Click", $"Update records status with staff : {operateStaff.StaffId}");
                    this.UpdateEntryStatus((AccountEntry)row.Tag, operateStaff.StaffId, (int)RecordStatus.Rejected, rejectReason);
                }
            }
            RetrieveRecord();
            Logger.WriteLog((int)LogLevels.Info, "Manager Form - rejectBtn_Click", $"Finish to process reject entries with staff : {operateStaff.StaffId}");
        }

        private void managerGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Rectangle rectangle = new Rectangle(e.RowBounds.Left,
                                                e.RowBounds.Top,
                                                dgv.RowHeadersWidth,
                                                e.RowBounds.Height);
            SolidBrush brush = new SolidBrush(this.generalEntryGrid.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, rectangle, sf);
        }
        
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }
    }
}
