using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRx.SDK.Contracts
{
    /// <summary>
    /// The DAO Factory interface implements the required contracts to access mechanism required to work with 
    /// the a specific data source. The data source could be a persistent store like an RDBMS or a DDBMS. 
    /// </summary>
    public interface IDAOFactory
    {
        /// <summary>
        /// SDK composite object interface provider.
        /// </summary>
        /// <returns>ICompositeModelProvider</returns>
        ICompositeModelProvider GetCompositeModelProvider();
    }
}
