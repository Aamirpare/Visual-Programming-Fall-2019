using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo2
{
    public partial class Login : Form
    {
        private LoginModel Credentials => new LoginModel() { Username = "Aamir", Password = "hec@123" };
        private LoginModel LoginModel { get; set; } = new LoginModel();
        public Login()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Copies the contorls to LoginModel
            DataBind();

            //if(ValidateProperty(LoginModel, typeof(LoginModel).GetProperties()[0]))
            //if(this.Validate())
            //if(this.ValidateChildren())
            if (ValidateLoginModel())
            {
                if(!ValidateCredentials())
                {
                    MessageBox.Show("Username or passoword is wrong", "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                var frm = new Editor();
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
            //else
            //{
            //    MessageBox.Show("You have not provided all the required fields", "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        private bool ValidateCredentials()
        {
            return (LoginModel.Password.Equals(Credentials.Password) &&
                    LoginModel.Username.ToLower().Equals(Credentials.Username.ToLower()));
        }
        private void DataBind()
        {
            LoginModel.Username = this.textBoxUserName.Text;
            LoginModel.Password = this.textBoxPassword.Text;
            labelUsernameError.Visible = false;
            labelPasswordError.Visible = false;
        }
        private bool ValidateLoginModel()
        {
            var context = new ValidationContext(LoginModel);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(LoginModel, context, result, true);

            result.ForEach(e =>
            {
                //MessageBox.Show( e.ErrorMessage );
                foreach (var m in e.MemberNames)
                {
                   switch (m)
                   {
                       case "Username":
                           labelUsernameError.Visible = true;
                           break;
                       case "Password":
                           labelPasswordError.Visible = true;
                           break;
                   }
                }
            });
            return isValid;
        }
        private bool ValidateProperty(LoginModel model, PropertyInfo property)
        {
            var context = new ValidationContext(model) { MemberName = property.Name };
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(property.GetValue(model), context, result);
            return isValid;
        }
        private void textBoxUserName_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                e.Cancel = true;
                labelUsernameError.Visible = true;
                return;
            }
            e.Cancel = false;
        }
        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                e.Cancel = true;
                labelPasswordError.Visible = true;
                return;
            }
            e.Cancel = false;
        }
    }

    public class LoginModel
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
