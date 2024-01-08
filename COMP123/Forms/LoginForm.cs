using System.Collections.Generic;
using System;
using System.Windows.Forms;
using COMP123.Utility;
using static COMP123.Utility.Parameters;
using COMP123.Model;
using COMP123.Forms;
using System.Linq;

namespace COMP123
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void loginBtn_Click(object sender, EventArgs e)
        {
            Logger.WriteLog((int)LogLevels.Info, "Login Form - Login", $"Start to Login with user name {userNametxt.Text}");
            try
            {
                if (!string.IsNullOrEmpty(passwordtxt.Text) &&
                    !string.IsNullOrWhiteSpace(passwordtxt.Text) &&
                    !string.IsNullOrEmpty(userNametxt.Text) &&
                    !string.IsNullOrWhiteSpace(userNametxt.Text))
                {
                    List<Staff> resultStaffs = SerializationHandler.JsonDeserialization();
                    Staff loginStaff = CheckLogin(userNametxt.Text, passwordtxt.Text, resultStaffs);

                    if (loginStaff != null)
                    {
                        Logger.WriteLog((int)LogLevels.Info, "Login Form - Login", $"Successfully login with {userNametxt.Text} with role {(Roles)loginStaff.Role}");
                        switch (loginStaff.Role)
                        {
                            case 0:
                            case 1:
                            case 2:
                                SystemForm systenForm = new SystemForm(resultStaffs, loginStaff);
                                systenForm.Show();
                                this.Hide();
                                break;
                            default:
                                MessageBox.Show(this, "Invalid User Role");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Invalid password or username");
                        Logger.WriteLog((int)LogLevels.Info, "Login Form - Login", $"Invalid user name or password {userNametxt.Text}");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Password or user name cannot be empty");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog((int)LogLevels.Error, "Login Form - Login", ex);
            }
            finally
            {
                Logger.WriteLog((int)LogLevels.Info, "Login Form - Login", "Empty password or user name");
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            passwordtxt.Text = "";
            userNametxt.Text = "";
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }

        private Staff CheckLogin(string userName, string password, List<Staff> staffs)
        {
            if ((string.Compare(userName, "admin", true) == 0 &&
                 string.Compare(password, "password", true) == 0))
            {
                Staff returnStaff = new Admin("admin", null, "", "", true);
                return returnStaff;
            }

            if (staffs != null && staffs.Count > 0)
            {
                password = Encryption.Encrypt(password);
                Staff returnStaff = staffs.FirstOrDefault(staff =>
                                    staff.Name.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                                    staff.Password == password &&
                                    staff.IsActive);
                return returnStaff;
            }
            return null;
        }
    }
}
