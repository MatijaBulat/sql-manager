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

        private void LbDatabaseTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbTableColumns.DataSource = (LbDatabaseTables.SelectedItem as Table).Columns;
            TbMessages.Text = LbDatabaseTables.SelectedItem.ToString();
        } 
        /*=> LbTableColumns.DataSource = (LbDatabaseTables.SelectedItem as Table).Columns;*/

        private void ClearControls()
        {
            LbTableColumns.DataSource = null;
        }

        //na klik event -> tbMessages.text = -> repofactory().getrepo() -> linq metoda koja vraca query rez
        //                                                              -> prima nekav parametar -> string u kojem je query za izvrsit

        //rezultat -> try catch 
                 //-> sve poruke i errore u tabmessages
                 //-> provjera je li rez null
                 //-> ako je tabMessages postavit na ""
                 //-> ako nije ispis rezultata u tablicu a tabMessage na nekakav succ
        private void BtnExecute_Click(object sender, EventArgs e)
        {
            SqlResponse sqlResponse = new SqlResponse();
            Table table = LbDatabaseTables.SelectedItem as Table;
            Database database = CbDatabases.SelectedItem as Database;

            string query = TbQuery.Text.Replace("\n", "").Replace("\t", "").Replace("\r", "").ToLower();

            if (query.Contains("select"))
            {
                sqlResponse = RepositoryFactory.GetRepository().CreateDataSet(query, database);
                DgvResults.DataSource = sqlResponse.DataSet.Tables[0];
                TbMessages.Text = sqlResponse.Message;
                TbMessages.Text = "aaa";
            }
            else
            {
                TbMessages.Text = RepositoryFactory.GetRepository().ExecuteQuery(query, database);
            }

            //DataSet ds = RepositoryFactory.GetRepository().ExecuteQuery(query, database);
            //DgvResults.DataSource = ds.Tables;

            //TbMessages.Text = query;
        }
    }
}
