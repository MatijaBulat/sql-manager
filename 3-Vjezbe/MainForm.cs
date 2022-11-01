using Dal;
using Dal.Models;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();      
        }

        private void Init() => LoadDatabases();

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void LoadDatabases() => CbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());


        private void CbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            LbDatabaseTables.DataSource = (CbDatabases.SelectedItem as Database).Tables;
        }

        private void LbDatabaseTables_SelectedIndexChanged(object sender, EventArgs e) => LbTableColumns.DataSource = (LbDatabaseTables.SelectedItem as Table).Columns;

        private void ClearControls()
        {
            LbTableColumns.DataSource = null;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            ClearTabControl();
            SqlResponse sqlResponse = new SqlResponse();
            Database database = CbDatabases.SelectedItem as Database;

            string query = TbQuery.Text.Replace("\n", " ").Replace("\t", "").Replace("\r", "");

            if (query.ToLower().Contains("select"))
            {
                sqlResponse = RepositoryFactory.GetRepository().CreateDataSet(query, database);
                DgvResults.DataSource = sqlResponse.DataSet.Tables[0];
                TbMessages.Text = sqlResponse.Message;
                TabControl.SelectTab(0);
            }
            else
            {
                TbMessages.Text = RepositoryFactory.GetRepository().ExecuteQuery(query, database);
                TabControl.SelectTab(1);
            }
            CbDatabases_SelectedIndexChanged(sender, e);
        }

        private void ClearTabControl()
        {
            TbMessages.Text = "";
            DgvResults.DataSource = "";
        }
    }
}
