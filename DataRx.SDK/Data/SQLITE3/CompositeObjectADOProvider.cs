using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DataRx.SDK.Contracts;
using DataRx.SDK.Model;

namespace DataRx.SDK.Data.SQLITE3
{
    /// <summary>
    /// TODO: Code Commentary
    /// </summary>
    public sealed class CompositeObjectADOProvider : ICompositeModelProvider
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
        private static CompositeObjectADOProvider instance = new CompositeObjectADOProvider();
        
        /// <summary>
        /// Sinleton Constructor
        /// </summary>
        /// <remarks>
        /// Single point of entry
        /// </remarks>
        public static CompositeObjectADOProvider Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        private CompositeObjectADOProvider()
        {
            //logger.Info("Initializing MetadataADOProvider");
            SQL3DBase dbase = new SQL3DBase();
            dbConn = dbase.DBConnection();
        }
        #endregion

        /// <summary>
        /// TODO: Code Commentary
        /// </summary>
        /// <param name="tnsKey"></param>
        /// <returns></returns>
        public List<CompositeModel> GetCompositeModelByTNS(string tnsKey)
        {
            List<CompositeModel> dtoArray = new List<CompositeModel>();

            StringBuilder sb = new StringBuilder(String.Empty);
            sb.AppendLine(String.Format(SQL.TaxonomyObjectSQL.GetCompositeModelByTNS, tnsKey));
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
                        //CompositeModel dto = new CompositeModel();
                        //dto.
                        //dto.MetaKey = sqlReader["META_KEY"].ToString();
                        //dto.ParentKey = sqlReader["PARENT_KEY"].ToString();
                        //dto.Lexicon = sqlReader["LEXICON"].ToString();
                        //dto.Description = sqlReader["DESCRIPTION"].ToString();
                        //dto.IconRef = sqlReader["ICON_REF"].ToString();
                        //dto.IsHidden = (Boolean)sqlReader["IS_HIDDEN"];
                        //dto.Partition = sqlReader["PARTITION"].ToString();
                        //dto.Ordinal = (Int32)sqlReader["ORDINAL"];
                        //dto.Partition = sqlReader["PARENT_KEY"].ToString();
                        //dto.TargetTable = sqlReader["TARGET_TABLE"].ToString();
                        //dto.TargetColumn = sqlReader["TARGET_COLUMN"].ToString();
                        //dto.MetaSource = sqlReader["META_SOURCE"].ToString();
                        //dto.LastModifiedDate = (DateTime)sqlReader["LAST_MODIFIED_DATE"];
                        //dto.ObjectState = DTOState.Clean;
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

            //throw new NotImplementedException();
        }

        

    }
}
