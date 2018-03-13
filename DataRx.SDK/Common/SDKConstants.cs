using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataRx.SDK.Common
{
    /// <summary>
    /// Data Access Object Factory Providers
    /// </summary>
    [DataContract]
    public class DAOFactoryProvider
    {
        /// <summary>
        /// Microsoft SQL Server
        /// </summary>
        public const String MSSQL2012 = "MSSQL";
        /// <summary>
        /// SQLite 3 Database
        /// </summary>
        public const String SQLITE3 = "SQLITE3";
        /// <summary>
        /// MySQL Database
        /// </summary>
        public const String MYSQL = "MYSQL";
        /// <summary>
        /// Mongo DB Document Database
        /// </summary>
        public const String MONGO = "MONGO";
        /// <summary>
        /// CouchDB Document Database
        /// </summary>
        public const String COUCH = "COUCH";
    }

    /// <summary>
    /// Used to help with the C# syntax minutia 
    /// </summary>
    public static class DotNetCodeConstants
    {
        public static String Tab = "\t";
        public static String Tab2 = "\t\t";
        public static String Tab3 = "\t\t\t";
        public static String Tab4 = "\t\t\t\t";
        public static String Tab5 = "\t\t\t\t\t";
        public static String Tab6 = "\t\t\t\t\t\t";
        public static String OpenBracketSpace = "{ ";
        public static String CloseBracketSpace = " }";
        public static String OpenBracket = "{";
        public static String CloseBracket = "}";
        public static String SingleQuote = "'";
        public static String DoubleQuote = "\"";
        public static String OpenParent = "( ";
        public static String CloseParent = " )";
        public static String SemiColon = ";";
        public static String Colon = ":";
        public static String Comma = ", ";
        public static String CodeComment = "// ";
        public static String DocumentComment = "/// ";
        public static String Space = " ";
        public static String ThisDot = "this.";
        public static String Return = "return";
        public static String EqualSign = " = ";
        public static String EqualsValue = " = value";
        public static String ToDo = "TODO: ";
        public static String OpenSummaryTag = DocumentComment + "<summary>";
        public static String CloseSummaryTag = DocumentComment + "</summary>";
    }

    /// <summary>
    /// Used to help with the Java syntax minutia 
    /// </summary>
    public static class JavaCodeConstants
    {
        public static String Tab = "\t";
        public static String Tab2 = "\t\t";
        public static String Tab3 = "\t\t\t";
        public static String Tab4 = "\t\t\t\t";
        public static String Tab5 = "\t\t\t\t\t";
        public static String Tab6 = "\t\t\t\t\t\t";
        public static String OpenBracketSpace = "{ ";
        public static String CloseBracketSpace = " }";
        public static String OpenBracket = "{";
        public static String CloseBracket = "}";
        public static String SingleQuote = "'";
        public static String DoubleQuote = "\"";
        public static String OpenParent = "( ";
        public static String CloseParent = " )";
        public static String SemiColon = ";";
        public static String Colon = ":";
        public static String Comma = ", ";
        public static String CodeComment = "// ";
        public static String DocumentComment = "/// ";
        public static String Space = " ";
        public static String ThisDot = "this.";
        public static String Return = "return";
        public static String EqualSign = " = ";
        public static String EqualsValue = " = value";
        public static String ToDo = "TODO: ";
        public static String OpenSummaryTag = DocumentComment + "<summary>";
        public static String CloseSummaryTag = DocumentComment + "</summary>";
    }

    public static class DB2RuntimeDataTypeConversion
    {
        #region .Net Conversion
        /// <summary>
        /// Converts MS SQL Server data type to .Net data type
        /// </summary>
        /// <param name="value">SQL Server Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String MSSQLToDotNet(String value)
        {
            //TODO: We need to take allow nulls into consideration in the future
            switch (value.ToLower())
            {
                case "bigint":
                    return "Int64";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "Byte[]";
                case "bit":
                    return "Boolean";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "String";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                    return "DateTime";
                case "time":
                    return "TimeSpan";

                case "decimal":
                case "money":
                case "smallmoney":
                    return "Decimal";

                case "float":
                    return "Double";

                case "int":
                    return "Int32";

                case "real":
                    return "Single";

                case "uniqueidentifier":
                    return "Guid";

                case "smallint":
                    return "Int16";

                case "tinyint":
                    return "Byte";

                case "variant":
                case "udt":
                    return "Object";

                case "structured":
                    return "datatable";

                case "datetimeoffset":
                    return "DateTimeOffset";

                default:
                    return "UNKNOWN DATA TYPE";
            }
        }
        /// <summary>
        /// Converts SQLite3 data types to .Net data types
        /// </summary>
        /// <param name="value">SQLite Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String SQLiteToDotNet(String value)
        {
            return value;
        }
        /// <summary>
        /// Converts MySQL data types to .Net data types
        /// </summary>
        /// <param name="value">SQLite Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String MySqlToDotNet(String value)
        {
            return value;
        }
        #endregion

        #region J2EE Conversion
        /// <summary>
        /// Converts MS SQL Server data type to .Net data type
        /// </summary>
        /// <param name="value">SQL Server Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String MSSQLToJava(String value)
        {
            //TODO: We need to take allow nulls into consideration in the future
            switch (value.ToLower())
            {
                case "bigint":
                    return "Int64";

                case "binary":
                case "image":
                case "timestamp":
                case "varbinary":
                    return "Byte[]";
                case "bit":
                    return "Boolean";

                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "String";

                case "datetime":
                case "smalldatetime":
                case "date":
                case "datetime2":
                    return "DateTime";
                case "time":
                    return "TimeSpan";

                case "decimal":
                case "money":
                case "smallmoney":
                    return "Decimal";

                case "float":
                    return "Double";

                case "int":
                    return "Int32";

                case "real":
                    return "Single";

                case "uniqueidentifier":
                    return "Guid";

                case "smallint":
                    return "Int16";

                case "tinyint":
                    return "Byte";

                case "variant":
                case "udt":
                    return "Object";

                case "structured":
                    return "datatable";

                case "datetimeoffset":
                    return "DateTimeOffset";

                default:
                    return "UNKNOWN DATA TYPE";
            }
        }
        /// <summary>
        /// Converts SQLite3 data types to .Net data types
        /// </summary>
        /// <param name="value">SQLite Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String SQLiteToJava(String value)
        {
            return value;
        }
        /// <summary>
        /// Converts MySQL data types to .Net data types
        /// </summary>
        /// <param name="value">SQLite Data Type</param>
        /// <returns>.Net Data Type</returns>
        public static String MySqlToJava(String value)
        {
            return value;
        }
        #endregion
    }
}
