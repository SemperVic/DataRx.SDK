using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Common;
using DataRx.SDK.Contracts;
using DataRx.SDK.Model;

namespace DataRx.SDK.Data.SQLITE3
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CompositeObjectDAOProvider : ICompositeModelProvider
    {
        private static CompositeObjectDAOProvider instance = new CompositeObjectDAOProvider();
        /// <summary>
        /// 
        /// </summary>
        public static CompositeObjectDAOProvider Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tnsKey"></param>
        /// <returns></returns>
        public List<CompositeModel> GetCompositeModelByTNS(string tnsKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        public void SetDataSource(DataSource ds)
        {
            throw new NotImplementedException();
        }
    }
}
