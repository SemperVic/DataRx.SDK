using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRx.SDK.Common;
using DataRx.SDK.Contracts;
using DataRx.SDK.Data;
using DataRx.SDK.Model;

namespace DataRx.SDK.Service
{
    /// <summary>
    /// The TaxonomyObjectServiceProvider serves as the primary entry point for the 
    /// TaxonomyObject data transfer object (DTO)
    /// </summary>
    public sealed class TaxonomyObjectServiceProvider : ITaxonomyObjectProvider
    {
         #region Standard Singleton Initialization
        /// <summary>
        /// Early Class Instantiation. 
        /// </summary>
        /// <remarks>Static settings holds only one instance of this class. Double lock not required.</remarks>
        private static TaxonomyObjectServiceProvider instance = new TaxonomyObjectServiceProvider();

        /// <summary>
        /// Sinleton Constructor
        /// </summary>
        /// <remarks>
        /// Single point of entry
        /// </remarks>
        public static TaxonomyObjectServiceProvider Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Private constructor instantiates the SQLiteConnection object
        /// </summary>
        private TaxonomyObjectServiceProvider()
        {
            // Set Data Source Object
            this.dataSource = new DataSource();
            this.dataSource.DSN = Settings.Default.DSN;
            this.dataSource.DBHost = Settings.Default.DBHost;
            this.dataSource.DBCatalog = Settings.Default.DBCatalog;
            this.dataSource.DBUser = Settings.Default.DBUser;
            this.dataSource.DBPassword = Settings.Default.DBPassword;
            this.dataSource.DBFactory = Settings.Default.DBFactory;
            this.dataSource.DBTrust = Settings.Default.DBTrust;
            this.dataSource.CNString = Settings.Default.CNString;

            // Set the factory
            this.factory = DAOFactory.Instance.GetDAOFactory(this.dataSource.DBFactory);
            //logger.Info("Initializing MetadataADOProvider");
        }        
        #endregion
        
        private DataSource dataSource;
        /// <summary>
        /// Callstack API Settings
        /// </summary>
        private Settings config;
        /// <summary>
        /// DAO Factory 
        /// </summary>
        private IDAOFactory factory;

        public void ChangeDSN(DataSource ds)
        {
            this.dataSource.DSN = ds.DSN;
            this.dataSource.DBHost = ds.DBHost;
            this.dataSource.DBCatalog = ds.DBCatalog;
            this.dataSource.DBUser = ds.DBUser;
            this.dataSource.DBPassword = ds.DBPassword;
            this.dataSource.DBFactory = ds.DBFactory;
            // Set the factory
            this.factory = DAOFactory.Instance.GetDAOFactory(this.dataSource.DBFactory);
            //We need to add an optional datasource attribute to all data class calls
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKey(string taxKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="superKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectBySuperKey(string superKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByIndexName(string indexName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKey(string mdrKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdrSuperKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRSuperKey(string mdrSuperKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxKey"></param>
        /// <param name="superKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKeyComposite(string taxKey, string superKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdrKey"></param>
        /// <param name="mdrSuperKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKeyComposite(string mdrKey, string mdrSuperKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdrSuperKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetCompositeModelByTNS(string mdrSuperKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TaxonomyObject SetTaxonomyObject(TaxonomyObject dto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TaxonomyObject SetStatelessTaxonomyObject(TaxonomyObject dto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TaxonomyObject InsertObject(TaxonomyObject dto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TaxonomyObject UpdateObject(TaxonomyObject dto)
        {
            throw new NotImplementedException();
        }
    }
}
