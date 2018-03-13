using DataRx.SDK.Model;
using System;
using System.Collections.Generic;
using DataRx.SDK.Common;

namespace DataRx.SDK.Contracts
{
    /// <summary>
    /// TODO: Document code commentrary
    /// </summary>
    public interface ICompositeModelProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        void SetDataSource(DataSource ds);
        /// <summary>
        /// Get Composite Model by Taxonomy Namespace returns a collection of composite model objects.
        /// </summary>
        /// <param name="tnsKey">Taxonomy Namespace</param>
        /// <returns>Collection</returns>
        List<CompositeModel> GetCompositeModelByTNS(String tnsKey);
    }
}
