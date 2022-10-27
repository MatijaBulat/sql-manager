using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class SqlResponse
    {
        public DataSet DataSet { get; set; }
        public string Message { get; set; }
    }
}
