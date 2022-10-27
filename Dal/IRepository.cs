using Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IRepository
    {
        void LogIn(string server, string username, string password);
        IEnumerable<Database> GetDatabases();
        IEnumerable<Table> GetDBTables(Database database);
        IEnumerable<Column> GetColumns(Table entity);
        string ExecuteQuery(string query, Database database);
        SqlResponse CreateDataSet(string query, Database database);

    }
}
