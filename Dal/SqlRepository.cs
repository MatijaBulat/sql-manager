using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class SqlRepository : IRepository
    {
        private string cs;
        private string cs2;

        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.TABLES";
        //private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        //private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        //private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";

        //private const string UseDatabase = "USE {0}";
        private const string ConString = "Server={0};Database={1};Uid={2};Password={3};Trusted_Connection=true;";
        private string Server = "";
        private string Username = "";
        private string Password = "";

        public void LogIn(string server, string username, string password)
        {
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionString, server, username, password)))
            {
                cs = con.ConnectionString;
                Server = server;
                Username = username;
                Password = password;
                con.Open();
            }
        }

        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = SelectDatabases;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Database
                            {
                                Name = dr[nameof(Database.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Table> GetDBTables(Database database)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectEntities, database.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Table
                            {
                                Name = dr[nameof(Table.Name)].ToString(),
                                Schema = dr[nameof(Table.Schema)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Column> GetColumns(Table entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectColumns, entity.Database.Name, entity.Name);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Column
                            {
                                Name = dr[nameof(Column.Name)].ToString(),
                                DataType = dr[nameof(Column.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }

        //vraca info message o izrsenoj komandi i nekakav error
        string IRepository.ExecuteQuery(string query, Database database)
        {
            string message = "";
            cs2 = string.Format(ConString, Server, database.Name, Username, Password);
            using (SqlConnection con = new SqlConnection(cs2))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                con.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
                {
                    message += "\n" + e.Message;
                };

                return message;
            }
        }

        //vraca select i info message -> dataset sa tablicom i nekakav string
        public SqlResponse CreateDataSet(string query, Database database)
        {
            //string message = "";
            cs2 = string.Format(ConString, Server, database.Name, Username, Password);

            SqlResponse sqlResponse = new SqlResponse();

            using (SqlConnection con = new SqlConnection(cs2))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();

                da.Fill(ds);
                ds.Tables[0].TableName = "Result";

                sqlResponse.DataSet = ds;

                con.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
                {
                    sqlResponse.Message += "\n" + e.Message.ToString();
                };

                Console.WriteLine(sqlResponse.Message);
                return sqlResponse;
            }
        }

        //private void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        //{
            
        //}
    }
}
