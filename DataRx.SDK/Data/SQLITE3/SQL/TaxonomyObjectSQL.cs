using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRx.SDK.Data.SQLITE3.SQL
{
    public partial class TaxonomyObjectSQLBase
    {
        #region Standard CRUD Statements
        /// <summary>
        /// Returns SELECT * FROM WHERE 1 = 1
        /// </summary>
        internal static String SelectWhere1EQ1 = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_KEY, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   1 = 1";
        /// <summary>
        /// Returns INSERT Statement
        /// </summary>
        internal static String InsertInto = @"
            INSERT  INTO MDR_TAXONOMY_OBJECT (TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_KEY, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR)
            VALUES  (@TAX_KEY, @SUPER_KEY, @INDEX_NAME, @TARGET_MDR, @MDR_KEY, @MDR_SUPER_KEY, @MDR_LEXICON, @TAX_STANDARD, @SHORT_DESC, @AUTHOR)";
        /// <summary>
        /// Returns Update Statement By TaxKey
        /// </summary>
        internal static String UpdateByTaxKey = @"
            UPDATE  MDR_TAXONOMY_OBJECT
            SET     SUPER_KEY       = @SUPER_KEY, 
                    INDEX_NAME      = @INDEX_NAME,
                    TARGET_MDR      = @TARGET_MDR,
                    MDR_KEY         = @ MDR_KEY,
                    MDR_SUPER_KEY   = @MDR_SUPER_KEY,
                    MDR_LEXICON     = @MDR_LEXICON,
                    TAX_STANDARD    = @TAX_STANDARD,
                    SHORT_DESC      = @SHORT_DESC,
                    AUTHOR          = @AUTHOR
            WHERE   TAX_KEY         = @TAX_KEY";
        #endregion
        
        #region Maintenance Statements
        /// <summary>
        /// DELETE FROM MDR_TAXONOMY_OBJECT WHERE TAX_KEY = @TAX_KEY
        /// </summary>
        internal static String DeleteTaxonomyObjectByTaxKey = @"DELETE FROM MDR_TAXONOMY_OBJECT WHERE TAX_KEY = @TAX_KEY";
        /// <summary>
        /// DELETE FROM MDR_TAXONOMY_OBJECT WHERE SUPER_KEY = @SUPER_KEY
        /// </summary>
        internal static String DeleteTaxonomyObjectBySuperKey = @"DELETE FROM MDR_TAXONOMY_OBJECT WHERE SUPER_KEY = @SUPER_KEY";
        #endregion

        #region Index and Keyword Filters
        /// <summary>
        /// SELECT BY TAX_KEY
        /// </summary>
        internal static String SelectByTaxKey = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   TAX_KEY = @TAX_KEY";
        /// <summary>
        /// SELECT BY SUPER_KEY
        /// </summary>
        internal static String SelectBySuperKey = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   SUPER_KEY = @SUPER_KEY
            ORDER BY INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY";
        /// <summary>
        /// SELECT BY INDEX_NAME
        /// </summary>
        internal static String SelectByIndexName = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   INDEX_NAME = @INDEX_NAME
            ORDER BY INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY";
        /// <summary>
        /// SELECT BY MDR_KEY
        /// </summary>
        internal static String SelectByMDRKey = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   MDR_KEY = @MDR_KEY
            ORDER BY INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY";
        /// <summary>
        /// SELECT BY MDR_SUPER_KEY
        /// </summary>
        internal static String SelectByMDRSuperKey = @"
            SELECT  TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM    MDR_TAXONOMY_OBJECT
            WHERE   SUPER_KEY = @SUPER_KEY
            ORDER BY INDEX_NAME, TARGET_MDR, MDR_SUPER_KEY";

        #endregion

        #region DDL - Data Definition Language
        /// <summary>
        /// CREATE TABLE MDR_TAXONOMY_OBJECT
        /// </summary>
        internal static String CreateMasterTaxonomyObjectTable = @"
            CREATE TABLE MDR_TAXONOMY_OBJECT (
                TAX_KEY       VARCHAR (15)  CONSTRAINT PK_MDR_TAXONOMY_OBJECT_TAX_KEY PRIMARY KEY NOT NULL,
                SUPER_KEY     VARCHAR (15)  CONSTRAINT FK_MDR_TAXONOMY_OBJECT_SUPER_KEY REFERENCES MDR_TAXONOMY_OBJECT (TAX_KEY) ON DELETE CASCADE,
                INDEX_NAME    VARCHAR (35),
                TARGET_MDR    VARCHAR (65),
                MDR_KEY       VARCHAR (65)  NOT NULL,
                MDR_SUPER_KEY VARCHAR (65),
                MDR_LEXICON   VARCHAR (65)  NOT NULL,
                TAX_STANDARD  VARCHAR (65),
                SHORT_DESC    VARCHAR (512),
                AUTHOR        VARCHAR (255) 
            )";
        #endregion
    }
    /// <summary>
    /// Extension class. In the event you wish to extend this object or create your own scripts, 
    /// place them in this method and the code generator will not disrupt your changes. Not, if you 
    /// make your changes using the Arizona SDK
    /// </summary>
    public class TaxonomyObjectSQL : TaxonomyObjectSQLBase
    {
        /// <summary>
        /// Serialized UUID of current DTO
        /// </summary>
        internal static String SerialVersionUID = "00000000-0000-0000-0000-000000000000";
        /// <summary>
        /// Returns Composite Object Model By TNS
        /// </summary>
        internal static String GetCompositeModelByTNS = @"
            SELECT   TAX_KEY, SUPER_KEY, INDEX_NAME, TARGET_MDR, MDR_KEY, MDR_SUPER_KEY, MDR_LEXICON, TAX_STANDARD, SHORT_DESC, AUTHOR
            FROM     MDR_TAXONOMY_OBJECT
            WHERE    INDEX_NAME = 'A2Z-ENTITY'
            AND      MDR_SUPER_KEY = @MDR_SUPER_KEY
            ORDER BY MDR_KEY, MDR_LEXICON";
    }
}
