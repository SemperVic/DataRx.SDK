using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Contracts;
using DataRx.SDK.Model;

namespace DataRx.SDK.Data.SQLITE3
{
    class TaxonomyObjectDAOProvider : ITaxonomyObjectProvider
    {
        #region Standard Singleton Initialization
        /// <summary>
        /// Early Class Instantiation. 
        /// </summary>
        /// <remarks>Static settings holds only one instance of this class. Double lock not required.</remarks>
        private static TaxonomyObjectDAOProvider instance = new TaxonomyObjectDAOProvider();

        /// <summary>
        /// Sinleton Constructor
        /// </summary>
        /// <remarks>
        /// Single point of entry
        /// </remarks>
        public static TaxonomyObjectDAOProvider Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Private constructor instantiates the SQLiteConnection object
        /// </summary>
        private TaxonomyObjectDAOProvider()
        {
            //logger.Info("Initializing MetadataADOProvider");
        }
        #endregion

        /// <summary>
        /// DAO Provider returns TaxonomyObject By TaxKey from ADO Provider.
        /// </summary>
        /// <param name="taxKey"></param>
        /// <returns>Collection with a single TaxonomyObject</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKey(String taxKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByTaxKey(taxKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By SuperKey from ADO Provider.
        /// </summary>
        /// <param name="superKey"></param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectBySuperKey(String superKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectBySuperKey(superKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjecst By IndexName from ADO Provider.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByIndexName(String indexName)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByIndexName(indexName);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By MDRKey from ADO Provider.
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKey(String mdrKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByMDRKey(mdrKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By MDRSuperKey from ADO Provider.
        /// </summary>
        /// <param name="mdrSuperKey">MDR Super Key</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRSuperKey(String mdrSuperKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByMDRSuperKey(mdrSuperKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By TaxKey and SuperKey from ADO Provider.
        /// </summary>
        /// <param name="taxKey">Primary key constraint</param>
        /// <param name="superKey">Foreign key constraint</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKeyComposite(String taxKey, String superKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByTaxKeyComposite(taxKey, superKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By MDRKey and MDRSuperKey from ADO Provider.
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <param name="mdrSuperKey"></param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKeyComposite(String mdrKey, String mdrSuperKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetTaxonomyObjectByMDRKeyComposite(mdrKey, mdrSuperKey);
        }
        /// <summary>
        /// DAO Provider returns TaxonomyObjects By Taxonomy Namespace (TNS) from ADO Provider.
        /// </summary>
        /// <param name="mdrSuperKey">MDR Super Key</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetCompositeModelByTNS(String mdrSuperKey)
        {
            return TaxonomyObjectADOProvider.Instance.GetCompositeModelByTNS(mdrSuperKey);
        }
        /// <summary>
        /// DAO Provider saves 'DIRTY' or 'NEW' DTO and returns 'CLEAN' TaxonomyObject from ADO Provider.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject SetTaxonomyObject(TaxonomyObject dto)
        {
            return TaxonomyObjectADOProvider.Instance.SetTaxonomyObject(dto);
        }
        /// <summary>
        /// DAO Provider saves DTO w/o state and returns 'CLEAN' TaxonomyObject from ADO Provider.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject SetStatelessTaxonomyObject(TaxonomyObject dto)
        {
            return TaxonomyObjectADOProvider.Instance.SetStatelessTaxonomyObject(dto);
        }
        /// <summary>
        /// DAO Provider returns 'CLEAN' TaxonomyObject after ADO performs it's SQL INSERT operation.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject InsertObject(TaxonomyObject dto)
        {
            return TaxonomyObjectADOProvider.Instance.InsertObject(dto);
        }
        /// <summary>
        /// DAO Provider returns 'CLEAN' TaxonomyObject after ADO performs it's SQL UPDATE operation.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject UpdateObject(TaxonomyObject dto)
        {
            return TaxonomyObjectADOProvider.Instance.UpdateObject(dto);
        }
    }
}
