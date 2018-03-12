/*
- $Author:          SMC/DataRx
- $DateGenerated:	3/12/2018 7:45:07 PM UTC
- $CodeGenTool:		None - old school, hand crafted code grind
- $CodeGenVer:		0.1 (alpha)
- $Effort:          5 hours
*/

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
    /// The Taxonomy Object ADO Provider transforms persistent non-scalar 
    /// object values into scalar/atomized relational form and back.
    /// </summary>
    /// <remarks>TaxonomyObject DTOs are stored in MDR_TAXONOMY_OBJECT</remarks>
    public sealed class TaxonomyObjectADOProvider : ITaxonomyObjectProvider
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
        /// Private constructor instantiates the SQLiteConnection object
        /// </summary>
        private TaxonomyObjectADOProvider()
        {
            //logger.Info("Initializing MetadataADOProvider");
            SQL3DBase dbase = new SQL3DBase();
            dbConn = dbase.DBConnection();
        }
        #endregion

        #region Read Methods
        /// <summary>
        /// Returns TaxonomyObject By TaxKey
        /// </summary>
        /// <remarks>
        /// Note: all read requests for a DTO are returned in an array. 
        /// If the array is empty - no records exist.
        /// </remarks>
        /// <param name="taxKey">Primary key constraint</param>
        /// <returns>Collection with a single TaxonomyObject</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKey(String taxKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectByTaxKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@TAX_KEY", taxKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader result as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns TaxonomyObject By SuperKey
        /// </summary>
        /// <param name="superKey">Foriegn key constraint</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectBySuperKey(String superKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectBySuperKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@SUPER_KEY", superKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();

            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader result as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns TaxonomyObject By IndexName
        /// </summary>
        /// <param name="indexName">Index Name</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByIndexName(String indexName)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectByIndexName);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@INDEX_NAME", indexName));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns TaxonomyObject By MDRKey
        /// </summary>
        /// <param name="mdrKey">MDR Key</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKey(String mdrKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectByMDRKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_KEY", mdrKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns TaxonomyObject By MDRSuperKey
        /// </summary>
        /// <param name="mdrSuperKey">MDR Super Key</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRSuperKey(String mdrSuperKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectByMDRSuperKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@SUPER_KEY", mdrSuperKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns TaxonomyObject By TaxKey and SuperKey
        /// </summary>
        /// <param name="taxKey">Primary key constraint</param>
        /// <param name="superKey">Foereign key contraint</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByTaxKeyComposite(String taxKey, String superKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectWhere1EQ1);
            sql.AppendLine("AND TAX_KEY = @TAX_KEY");
            sql.AppendLine("AND SUPER_KEY = @SUPER_KEY");
            sql.AppendLine("ORDER BY TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY");
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@TAX_KEY", taxKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@SUPER_KEY", superKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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
        
        /// <summary>
        /// Returns TaxonomyObject By TaxKey and SuperKey
        /// </summary>
        /// <param name="taxKey">Primary key constraint</param>
        /// <param name="superKey">Foereign key contraint</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetTaxonomyObjectByMDRKeyComposite(String mdrKey, String mdrSuperKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.SelectWhere1EQ1);
            sql.AppendLine("AND MDR_KEY = @MDR_KEY");
            sql.AppendLine("AND MDR_SUPER_KEY = @MDR_SUPER_KEY");
            sql.AppendLine("ORDER BY MDR_KEY, MDR_SUPER_KEY, MDR_LEXICON");
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_KEY", mdrKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_SUPER_KEY", mdrSuperKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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

        /// <summary>
        /// Returns CompositeModel By TNS
        /// </summary>
        /// <param name="mdrSuperKey">Taxonomy Schema Namespace. e.g: COM or A2Z</param>
        /// <returns>Collection of TaxonomyObject(s)</returns>
        public List<TaxonomyObject> GetCompositeModelByTNS(String mdrSuperKey)
        {
            // Create TaxonomyObject Array
            List<TaxonomyObject> dtoArray = new List<TaxonomyObject>();            
            // Prepare for DB Connection and Query Statement
            StringBuilder sql = new StringBuilder(String.Empty);
            sql.AppendLine(SQL.TaxonomyObjectSQL.GetCompositeModelByTNS);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_SUPER_KEY", mdrSuperKey));
            dbConn.Open();
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();
            // Spin up the results
			try
			{
				while (sqlReader.Read())
				{
                    // Cast sqlReader row as DTO
                    dtoArray.Add(this.ToDataTransferObject(sqlReader));
				}
			}
			catch (Exception e)
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
        #endregion

        #region Inserts & Updates
        /// <summary>
		/// Saves object DTO w/state to a SQLite database. The object state is managed by 
        /// evaluating the object's state to determine id INSERT or UPDATE is required. 
        /// If the object state is clean - no insert or update will occur. NOTE: This 
        /// method should only be called from an environment with state. If you are 
        /// performing I/O in a stateless environment found in the web tier, you are 
        /// encouraged to call SetStatelessTaxonomyObject where the process will first 
        /// attempt to lookup the record being passed to determine state. 
		/// </summary>
        /// <remarks>
        /// When saving a DTO, the saving method will return a standalone clean object. 
        /// Arrays are not reurned when saving operations are performed.
        /// </remarks>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject SetTaxonomyObject(TaxonomyObject dto)
        {
            if(dto.ObjectState.Equals(DTOState.New))
            {
                return InsertObject(dto);
            } 
            else if(dto.ObjectState.Equals(DTOState.Dirty))
            {
                return UpdateObject(dto);
            }
            else
            {
                if(dto.ObjectState.Equals(DTOState.Clean))
                {
                    // Make log entry as warning
                }
                if(!dto.ObjectState.Equals(DTOState.Clean))
                {
                    // Make a log entry warning of object state anomoly
                }
                return dto;
            }
        }

        /// <summary>
        /// Saves object DTO w/o state to a SQLite database. Using this method assumes you are not 
        /// managing object state in your web tier. Accordingly, If you send this method an object 
        /// it will first attempt to lookup the record being passed to determine state. In the event 
        /// you DO NOT want the overhead of this additional thread being opened, you can manage the 
        /// state yourself and make the appropriate call to the appropriate InsertObject 
        /// method or UpdateObject method.
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject SetStatelessTaxonomyObject(TaxonomyObject dto)
        {
            List<TaxonomyObject> findDTO = GetTaxonomyObjectByTaxKey(dto.TaxKey);
            if(findDTO.Count.Equals(1))
            {
                return InsertObject(dto);
            }
            else
            {
                return UpdateObject(dto);
            }
        }

        /// <summary>
        /// Inserts TaxonomyObject DTO into the MDR_TAXONOMY_OBJECT table
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject InsertObject(TaxonomyObject dto)
        {
            // Construct SQL Script
			StringBuilder sql = new StringBuilder(String.Empty);
			sql.AppendLine(SQL.TaxonomyObjectSQL.InsertInto);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            // Add SQL Command Parameters
			this.ToSqlCmdParameters(dto, sqlCmd);

			// Execute the query
			try
			{
				sqlCmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				throw new Exception(e.Message, e);
			}
			finally
			{
				dbConn.Close();
			}

            return dto;
        }

        /// <summary>
        /// Updates TaxonomyObject DTO into the MDR_TAXONOMY_OBJECT table
        /// </summary>
        /// <param name="dto">TaxonomyObject</param>
        /// <returns>TaxonomyObject</returns>
        public TaxonomyObject UpdateObject(TaxonomyObject dto)
        {
            // Construct SQL Script
			StringBuilder sql = new StringBuilder(String.Empty);
			sql.AppendLine(SQL.TaxonomyObjectSQL.UpdateByTaxKey);
            SQLiteCommand sqlCmd = new SQLiteCommand(dbConn);
            sqlCmd.CommandText = sql.ToString();
            sqlCmd.Parameters.Clear();
            // Add SQL Command Parameters
			this.ToSqlCmdParameters(dto, sqlCmd);

			// Execute the query
			try
			{
				sqlCmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				throw new Exception(e.Message, e);
			}
			finally
			{
				dbConn.Close();
			}

            return dto;
        }
        #endregion

        #region ADO to DataTransferObject Relational Mappings
        /// <summary>
		/// Converts SQL Data Reader row to a TaxonomyObject.
		/// </summary>
		private TaxonomyObject ToDataTransferObject(SQLiteDataReader sqlReader)
		{
            // Populate data transfer object
            TaxonomyObject dto = new TaxonomyObject();
            dto.TaxKey = sqlReader.IsDBNull(sqlReader.GetOrdinal("TAX_KEY")) ? dto.TaxKey : sqlReader["TAX_KEY"].ToString();
            dto.SuperKey = sqlReader.IsDBNull(sqlReader.GetOrdinal("SUPER_KEY")) ? dto.TaxKey : sqlReader["SUPER_KEY"].ToString();
            dto.IndexName = sqlReader.IsDBNull(sqlReader.GetOrdinal("INDEX_NAME")) ? dto.TaxKey : sqlReader["INDEX_NAME"].ToString();
            dto.TargetMDR = sqlReader.IsDBNull(sqlReader.GetOrdinal("TARGET_MDR")) ? dto.TaxKey : sqlReader["TARGET_MDR"].ToString();
            dto.MDRKey = sqlReader.IsDBNull(sqlReader.GetOrdinal("MDR_KEY")) ? dto.TaxKey : sqlReader["MDR_KEY"].ToString();
            dto.MDRSuperKey = sqlReader.IsDBNull(sqlReader.GetOrdinal("MDR_SUPER_KEY")) ? dto.TaxKey : sqlReader["MDR_SUPER_KEY"].ToString();
            dto.MDRLexicon = sqlReader.IsDBNull(sqlReader.GetOrdinal("MDR_LEXICON")) ? dto.TaxKey : sqlReader["MDR_LEXICON"].ToString();
            dto.TaxStandard = sqlReader.IsDBNull(sqlReader.GetOrdinal("TAX_STANDARD")) ? dto.TaxKey : sqlReader["TAX_STANDARD"].ToString();
            dto.ShortDesc = sqlReader.IsDBNull(sqlReader.GetOrdinal("SHORT_DESC")) ? dto.TaxKey : sqlReader["SHORT_DESC"].ToString();
            // Set Object State
            dto.ObjectState = DTOState.Clean;

			return dto;
		}
        
        /// <summary>
		/// Adds SQL Command Parameters from the TaxonomyObject for UPDATES and INSERTS.
		/// </summary>
		private void ToSqlCmdParameters(TaxonomyObject dto, SQLiteCommand sqlCmd)
		{
			sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.Add(new SQLiteParameter("@TAX_KEY", dto.TaxKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@SUPER_KEY", dto.SuperKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@INDEX_NAME", dto.IndexName));
            sqlCmd.Parameters.Add(new SQLiteParameter("@TARGET_MDR", dto.TargetMDR));
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_KEY", dto.MDRKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_SUPER_KEY", dto.MDRSuperKey));
            sqlCmd.Parameters.Add(new SQLiteParameter("@MDR_LEXICON", dto.MDRLexicon));
            sqlCmd.Parameters.Add(new SQLiteParameter("@TAX_STANDARD", dto.TaxStandard));
            sqlCmd.Parameters.Add(new SQLiteParameter("@SHORT_DESC", dto.ShortDesc));
        }
        #endregion
    }
}
