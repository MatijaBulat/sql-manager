using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Database
    {
        private readonly Lazy<IEnumerable<Table>> tables;

        //private readonly Lazy<IEnumerable<DBEntity>> views;
        //private readonly Lazy<IEnumerable<Procedure>> procedures;
        public Database()
        {
            tables = new Lazy<IEnumerable<Table>>(() => RepositoryFactory.GetRepository().GetDBTables(this));
            //views = new Lazy<IEnumerable<DBEntity>>(() => RepositoryFactory.GetRepository().GetDBEntities(this, DBEntityType.View));
            //procedures = new Lazy<IEnumerable<Procedure>>(() => RepositoryFactory.GetRepository().GetProcedures(this));
        }

        public IList<Table> Tables
        {
            get => new List<Table>(tables.Value);
        }

        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
