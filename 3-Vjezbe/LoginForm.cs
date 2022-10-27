using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Vježbe
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                RepositoryFactory.GetRepository().LogIn(TbServer.Text.Trim(), TbUsername.Text.Trim(), TbPassword.Text.Trim());
                new MainForm().Show();
                Hide(); 
            }
            catch (Exception ex)
            {
                LbError.Text = ex.Message;
            }
        }
    }
}
