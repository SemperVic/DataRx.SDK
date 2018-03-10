using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Contracts;
using DataRx.SDK.Model;

namespace DataRx.SDK.Data.COUCH
{
    public sealed class CompositeObjectDAOProvider : ICompositeModelProvider
    {
        private static CompositeObjectDAOProvider instance = new CompositeObjectDAOProvider();

        public static CompositeObjectDAOProvider Instance
        {
            get { return instance; }
        }

        public List<CompositeModel> GetCompositeModelByTNS(string tnsKey)
        {
            throw new NotImplementedException();
        }
    }
}
