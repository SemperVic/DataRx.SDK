using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRx.SDK.Data.SQLITE3.SQL
{
    public static class MetadataCrud
    {
        #region Standard CRUD Statements
        internal static String SQLSelect = @"
                        SELECT  META_KEY, PARENT_KEY, LEXICON, DESCRIPTION, ORDINAL, ICON_REF, IS_HIDDEN, 
                                PARTITION, TARGET_TABLE, TARGET_COLUMN, META_SOURCE, LAST_MODIFIED_DATE
                        FROM    {0}
                        WHERE   1 = 1";

        internal static String SQLInsert = @"
                        INSERT  INTO {0} (META_KEY, PARENT_KEY, LEXICON, DESCRIPTION, ORDINAL, ICON_REF, IS_HIDDEN, PARTITION, TARGET_TABLE, TARGET_COLUMN, META_SOURCE, LAST_MODIFIED_DATE)
                        VALUES  (@META_KEY, @PARENT_KEY, @LEXICON, @DESCRIPTION, @ORDINAL, @ICON_REF, @IS_HIDDEN, @PARTITION, @TARGET_TABLE, @TARGET_COLUMN, @META_SOURCE, @LAST_MODIFIED_DATE)";

        internal static String SQLUpdate = @"
                        UPDATE  {0} 
                        SET     PARENT_KEY = @PARENT_KEY, 
                                LEXICON = @LEXICON, 
                                DESCRIPTION = @DESCRIPTION, 
                                ORDINAL = @ORDINAL, 
                                ICON_REF = @ICON_REF, 
                                IS_HIDDEN = @IS_HIDDEN, 
                                PARTITION = @PARTITION, 
                                TARGET_TABLE = @TARGET_TABLE, 
                                TARGET_COLUMN = @TARGET_COLUMN, 
                                META_SOURCE = @META_SOURCE, 
                                LAST_MODIFIED_DATE = @LAST_MODIFIED_DATE
                        WHERE   META_KEY = @META_KEY";


        #endregion



        #region Maintenance Statements
        internal static String SQLHide = @"DELETE FROM {0} WHERE META_KEY = @META_KEY";

        internal static String SQLDelete = @"DELETE FROM {0} WHERE META_KEY = @META_KEY";
        #endregion

        #region Metadata and Keyword Filters
        // None at this time
        #endregion
    }
}
