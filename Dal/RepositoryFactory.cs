using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> repository = new Lazy<IRepository>(() => Activator.CreateInstance(typeof(SqlRepository)) as IRepository);
        public static IRepository GetRepository() => repository.Value;
    }
}
