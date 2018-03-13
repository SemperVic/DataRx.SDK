using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Common;
using DataRx.SDK.Model;

namespace DataRx.SDK.Contracts
{
    /// <summary>
	/// The ITaxonomyObjectProvider is implemented by one or more Taxonomy Data Access 
	/// Object Provider(s) depending on the data access layer implementation.
	/// </summary>
    public interface ITaxonomyObjectProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        void SetDataSource(DataSource ds);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By TaxKey
        /// </summary>
        /// <param name="taxKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByTaxKey(String taxKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By SuperKey
        /// </summary>
        /// <param name="superKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectBySuperKey(String superKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By IndexName
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByIndexName(String indexName);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By MDRKey
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByMDRKey(String mdrKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By MDRSuperKey
        /// </summary>
        /// <param name="mdrSuperKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByMDRSuperKey(String mdrSuperKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By TaxKey and SuperKey
        /// </summary>
        /// <param name="taxKey"></param>
        /// <param name="superKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByTaxKeyComposite(String taxKey, String superKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By MDRKey and MDRSuperKey
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <param name="mdrSuperKey"></param>
        /// <returns></returns>
        List<TaxonomyObject> GetTaxonomyObjectByMDRKeyComposite(String mdrKey, String mdrSuperKey);
        /// <summary>
        /// Interface contract method stub returns TaxonomyObject By TNS
        /// </summary>
        /// <param name="mdrSuperKey">MDR Super Key</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        List<TaxonomyObject> GetCompositeModelByTNS(String mdrSuperKey);
        /// <summary>
        /// Interface contract method stub to save DTO data w/state.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        TaxonomyObject SetTaxonomyObject(TaxonomyObject dto);
        /// <summary>
        /// Interface contract method stub to save DTO data w/o state
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        TaxonomyObject SetStatelessTaxonomyObject(TaxonomyObject dto);
        /// <summary>
        /// Interface contract method stub to insert DTO data.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        TaxonomyObject InsertObject(TaxonomyObject dto);
        /// <summary>
        /// Interface contract method stub to udate DTO data.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        TaxonomyObject UpdateObject(TaxonomyObject dto);
    }
}
