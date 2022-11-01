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

        public Database()
        {
            tables = new Lazy<IEnumerable<Table>>(() => RepositoryFactory.GetRepository().GetDBTables(this));
        }

        public IList<Table> Tables
        {
            get => new List<Table>(tables.Value);
        }

        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
