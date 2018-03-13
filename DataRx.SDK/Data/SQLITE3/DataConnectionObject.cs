using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DataRx.SDK.Common;

namespace DataRx.SDK.Data.SQLITE3
{
    public class DataConnectionObject
    {
        /// <summary>
        /// SQLite DB Connection Object
        /// </summary>
        private SQLiteConnection dbConn;
        private SQLiteTransaction2 transaction;
        private DataSource dataSource;

        /// <summary>
        /// Default Constuctor
        /// </summary>
        public DataConnectionObject() 
        {
            dataSource = new DataSource();
            dataSource.DSN = Settings.Default.DSN;
            dataSource.DBHost = Settings.Default.DBHost;
            dataSource.DBCatalog = Settings.Default.DBCatalog;
            dataSource.DBUser = Settings.Default.DBUser;
            dataSource.DBPassword = Settings.Default.DBPassword;
            dataSource.DBFactory = Settings.Default.DBFactory;
            dataSource.DBTrust = Settings.Default.DBTrust;
            dataSource.CNString = Settings.Default.CNString;
            
            // Instantiate DB Connection
            dbConn =  new SQLiteConnection();
                        
        }
        /// <summary>
        /// Default Constructor w/Connection String overide
        /// </summary>
        /// <param name="cnString"></param>
        public DataConnectionObject(String cnString) 
        {
            // Instantiate DB Connection
            dbConn =  new SQLiteConnection(cnString);
            dataSource = new DataSource();
        }
        /// <summary>
        /// Returns SQLiteConnection object
        /// </summary>
        public SQLiteConnection DBConn
        {
            get { return this.dbConn; }
        }

        public DataSource DSN
        {
            get { return this.dataSource; }
            set { this.dataSource = value; }
        }
    }
}
