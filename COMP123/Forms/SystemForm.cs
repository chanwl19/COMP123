using COMP123.ColumnDateTimePicker;
using COMP123.Model;
using COMP123.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static COMP123.Utility.Parameters;

namespace COMP123.Forms
{
    public partial class SystemForm : Form
    {
        private Staff operateStaff;
        private List<Staff> staffs;
        //private DateTimePicker dateTimePicker;
        private List<string> accounts;
        public SystemForm(List<Staff> inputStaffs, Staff inputStaff)
        {
            InitializeComponent();
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
            }
        }

        private void InitializeAdminData(List<Staff> staffs)
        {

            this.existingUsersGrid.Rows.Clear();
            this.existingUsersGrid.Columns.Clear();
            string[] headerArray = Parameters.tableHeader["adminHeader"];
            foreach (string header in headerArray)
            {
                this.existingUsersGrid.Columns.Add(header, header);
            }

            if (staffs != null && staffs.Count > 0)
            {
                foreach (Staff staff in staffs)
                {
                    object[] rowData = { staff.StaffId, staff.Name, (Roles)staff.Role };
                    this.existingUsersGrid.Rows.Add(rowData);
                    this.existingUsersGrid.Rows[this.existingUsersGrid.Rows.Count - 1].Tag = staff;
                }
            }
            this.existingUsersGrid.ClearSelection();
        }


        private void InitializeAccountantData(Staff staff)
        {
            this.generalEntryGrid.Rows.Clear();
            this.generalEntryGrid.Columns.Clear();
            accounts = ObjectHandler.JsonDeserialization<List<string>>(ConfigurationManager.AppSettings["accountFilePath"] +
                                                                       ConfigurationManager.AppSettings["accountFile"]);
            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //comboBoxColumn.Name = "Account";
            //comboBoxColumn.HeaderText = "Account";
            //comboBoxColumn.DataSource = accounts;
            //this.generalEntryGrid.Columns.Add(comboBoxColumn);
            //DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)this.generalEntryGrid.Columns["Account"];
            //dataGridViewComboBoxColumn.DataSource = accounts;

            string[] headerArray = Parameters.tableHeader["accountantHeader"];
            foreach (string header in headerArray)
            {
                switch (header)
                {
                    case "Date":
                        CalendarColumn calendarCol = new CalendarColumn();
                        calendarCol.Name = header;
                        calendarCol.HeaderText = header;
                        this.generalEntryGrid.Columns.Add(calendarCol);
                        break;
                    default:
                        this.generalEntryGrid.Columns.Add(header, header);
                        break;
                }
            }
        }

        private void generalEntryGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.RowIndex >= 0)
            {

                if (dgv.CurrentCell.OwningColumn.Name == "Account")
                {
                    System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)e.Control;
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
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
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-'
                && (sender as System.Windows.Forms.TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }
        }

        private void saveEntryBtn_Click(object sender, EventArgs e)
        {
            string errorString = ValidateEntry();
            if (!FunctionUtil.isEmptyOrNull(errorString))
            {
                MessageBox.Show(errorString);
                foreach (DataGridViewRow row in this.generalEntryGrid.Rows)
                {
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1); ;
                }
                return;
            }
        }

        private string ValidateEntry()
        {
            string returnStr = "";
            for (int i = 0; i < this.generalEntryGrid.RowCount - 1; i++)
            {
                DataGridViewRow row = this.generalEntryGrid.Rows[i];
                string rowError = $"Row {i + 1} : ";
                bool hasError = false;

                if (FunctionUtil.isCellEmptyOrNUll(row.Cells[1]))
                {
                    rowError += "Account is empty. ";
                    hasError = true;
                }

                if (FunctionUtil.isCellEmptyOrNUll(row.Cells[2]))
                {
                    rowError += "Description is empty. ";
                    hasError = true;
                }

                if (FunctionUtil.isCellEmptyOrNUll(row.Cells[3]))
                {
                    rowError += "Credit is empty. ";
                    hasError = true;
                }
                else
                {
                    if (!decimal.TryParse(row.Cells[3].Value.ToString(), out decimal credit))
                    {
                        rowError += "Credit is invalid. ";
                        hasError = true;
                    }
                }

                if (FunctionUtil.isCellEmptyOrNUll(row.Cells[4]))
                {
                    rowError += "Debit is empty. ";
                    hasError = true;
                }
                else
                {
                    if (!decimal.TryParse(row.Cells[4].Value.ToString(), out decimal debit))
                    {
                        rowError += "Debit is invalid";
                        hasError = true;
                    }
                }

                if (hasError)
                {
                    returnStr += rowError;
                    if (!FunctionUtil.isEmptyOrNull(returnStr))
                    {
                        returnStr += System.Environment.NewLine;
                    }
                }

            }
            return returnStr;
        }

        private void generalEntryGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //this.generalEntryGrid.Rows[e.RowIndex].HeaderCell.Value = "1";
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
            }
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
            }
            checkActionBtnColor();
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
            }
            checkActionBtnColor();
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
                if (ValidateForm(isAddNew))
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
                    ObjectHandler.JsonSerializater(staffs, ConfigurationManager.AppSettings["userFilePath"] + ConfigurationManager.AppSettings["userFile"]);
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

        private bool ValidateForm(bool isAdd)
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

            if (FunctionUtil.isEmptyOrNull(this.nameTxt.Text))
            {
                this.nameError.Visible = true;
                isPass = false;
            }
            else
            {
                this.nameError.Visible = false;
            }

            if (FunctionUtil.isEmptyOrNull(this.emailTxt.Text))
            {
                this.emailError.Visible = true;
                isPass = false;
            }
            else
            {
                Regex regex = new Regex(Parameters.emailPattern);
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

            if (FunctionUtil.isEmptyOrNull(this.pwTxt.Text))
            {
                this.passwordError.Visible = true;
                isPass = false;
            }
            else
            {
                this.passwordError.Visible = false;
            }

            if (FunctionUtil.isEmptyOrNull(this.confirmPwTxt.Text))
            {
                this.confirmPasswordError.Visible = true;
                isPass = false;
            }
            else
            {
                this.confirmPasswordError.Visible = false;
            }

            if (!FunctionUtil.isEmptyOrNull(this.pwTxt.Text) &&
                !FunctionUtil.isEmptyOrNull(this.confirmPwTxt.Text))
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
            return isPass;
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
                    case (Utility.Parameters.Roles.Admin):
                        newStaff = new Admin(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), isActiveUser);
                        break;
                    case (Roles.Manager):
                        newStaff = new Manager(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), isActiveUser);
                        break;
                    case (Roles.Accountant):
                        newStaff = new Accountant(this.nameTxt.Text, (addNewUser ? null : staffId), this.emailTxt.Text, Encryption.Encrypt(this.pwTxt.Text), isActiveUser);
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

        private void InitializeTabs(Staff staff)
        {
            this.tabControl.TabPages.Remove(this.adminTab);
            this.tabControl.TabPages.Remove(this.managerTab);
            this.tabControl.TabPages.Remove(this.accountantTab);
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

        private bool ValidateUser()
        {
            List<Staff> duplicatedStaffs = staffs.Where(staff => string.Compare(staff.Name, this.nameTxt.Text, true) == 0).ToList();
            return (duplicatedStaffs == null || duplicatedStaffs.Count == 0);
        }

    }
}
