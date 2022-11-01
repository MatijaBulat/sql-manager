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
        private string serverConnectionString;
        private string databaseConnectionString;

        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.TABLES";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";

        private const string ConString = "Server={0};Database={1};Uid={2};Password={3};Trusted_Connection=true;";
        private string Server = "";
        private string Username = "";
        private string Password = "";
        private const string rowsAffected =  " rows affected";

        public void LogIn(string server, string username, string password)
        {
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionString, server, username, password)))
            {
                serverConnectionString = con.ConnectionString;
                Server = server;
                Username = username;
                Password = password;
                con.Open();
            }
        }

        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection con = new SqlConnection(serverConnectionString))
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
            using (SqlConnection con = new SqlConnection(serverConnectionString))
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
            using (SqlConnection con = new SqlConnection(serverConnectionString))
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

        string IRepository.ExecuteQuery(string query, Database database)
        {
            string message = "";
            databaseConnectionString = string.Format(ConString, Server, database.Name, Username, Password);
            using (SqlConnection con = new SqlConnection(databaseConnectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        message = cmd.ExecuteNonQuery() != 0 ? "Commands completed successfully." : "";
                        message += GetCompletionTime();
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }

                return message;
            }
        }

        public SqlResponse CreateDataSet(string query, Database database)
        {
            databaseConnectionString = string.Format(ConString, Server, database.Name, Username, Password);

            SqlResponse sqlResponse = new SqlResponse();

            using (SqlConnection con = new SqlConnection(databaseConnectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();

                    sqlResponse.Message = da.Fill(ds).ToString();
                    sqlResponse.Message += rowsAffected;
                    sqlResponse.Message += GetCompletionTime();

                    ds.Tables[0].TableName = "Result";

                    sqlResponse.DataSet = ds;
                }
                catch (Exception ex)
                {
                    sqlResponse.Message = ex.Message;
                }

                return sqlResponse;
            }
        }

        public string GetCompletionTime() => $"\r\nCompletion time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
    }
}
