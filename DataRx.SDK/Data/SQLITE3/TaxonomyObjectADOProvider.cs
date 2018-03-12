using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DataRx.SDK.Common;
using DataRx.SDK.Contracts;
using DataRx.SDK.Model;

namespace DataRx.SDK.Data.SQLITE3
{
    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class TaxonomyObjectADOProvider
    {
        #region Standard Singleton Initialization
        /// <summary>
        /// SQLite DB Connection Object
        /// </summary>
        private SQLiteConnection dbConn;

        /// <summary>
        /// Early Class Instantiation. 
        /// </summary>
        /// <remarks>Static settings holds only one instance of this class. Double lock not required.</remarks>
        private static TaxonomyObjectADOProvider instance = new TaxonomyObjectADOProvider();

        /// <summary>
        /// Sinleton Constructor
        /// </summary>
        /// <remarks>
        /// Single point of entry
        /// </remarks>
        public static TaxonomyObjectADOProvider Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        private TaxonomyObjectADOProvider()
        {
            //logger.Info("Initializing MetadataADOProvider");
            SQL3DBase dbase = new SQL3DBase();
            dbConn = dbase.DBConnection();
        }
        #endregion

        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        /// <param name="taxKey"></param>
        /// <returns></returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKey(String taxKey)
        {
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();
            StringBuilder sb = new StringBuilder(String.Empty);
            sb.AppendLine(SQL.MasterTaxonomyObjectSQL.SelectByTaxKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sb.ToString();
            sqlCmd.Parameters.Clear();
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();

            try
            {
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        TaxonomyObject dto = new TaxonomyObject();
                        dto.TaxKey = sqlReader["TAX_KEY"].ToString();
                        dto.SuperKey = sqlReader["SUPER_KEY"].ToString();
                        dto.IndexName = sqlReader["INDEX_NAME"].ToString();
                        dto.TargetMDR = sqlReader["TARGET_MDR"].ToString();
                        dto.MDRKey = sqlReader["MDR_KEY"].ToString();
                        dto.MDRSuperKey = sqlReader["MDR_SUPER_KEY"].ToString();
                        dto.MDRLexicon = sqlReader["MDR_LEXICON"].ToString();
                        dto.TaxStandard = sqlReader["TAX_STANDARD"].ToString();
                        dto.ShortDesc = sqlReader["SHORT_DESC"].ToString();
                        
                        // Set Object State
                        dto.ObjectState = DTOState.Clean;


                        dtoArray.Add(dto);
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                sqlReader.Close();
                dbConn.Close();
            }
            return dtoArray;
        }

    }
}
