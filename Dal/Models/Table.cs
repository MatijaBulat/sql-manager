﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Table
    {
        private readonly Lazy<IEnumerable<Column>> columns;
        public Table()
        {
            columns = new Lazy<IEnumerable<Column>>(() => RepositoryFactory.GetRepository().GetColumns(this));
        }
        public IList<Column> Columns
        {
            get => new List<Column>(columns.Value);
        }
        public string Schema { get; set; }
        public string Name { get; set; }
        public Database Database { get; set; }
        public override string ToString() => $"{Schema}.{Name}";
    }
}
